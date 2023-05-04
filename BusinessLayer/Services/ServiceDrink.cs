using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using BusinessLayer.Services.CommonServices;

namespace BusinessLayer.Services;

public class ServiceDrink
{
    private readonly IRepositoryDrink _repositoryDrink;
    private readonly IRepositoryRecipe _repositoryRecipe;
    private readonly IRepositoryIngridient _repositoryIngridient;
    private readonly IRepositoryUnit _repositoryUnit;
    private readonly IRepositoryStyle _repositoryStyle;
    private readonly IRepositoryTag _repositoryTag;
    private readonly IRepositoryFlavour _repositoryFlavour;
    private readonly IRepositoryTool _repositoryTool;
    private readonly IRepositoryColor _repositoryColor;
    private readonly IRepositoryTransparency _repositoryTransparency;
    private readonly IRepositoryGarnish _repositoryGarnish;
    private readonly IRepositoryGlass _repositoryGlass;
    private readonly IRepositoryGeneratedImage _repositoryGeneratedImage;
    private readonly IRepositoryUploadedImage _repositoryUploadedImage;
    private readonly IMapper _mapper;

    private readonly CommonServiceMidjourney _commonServiceMidjourney;

    public ServiceDrink(IMapper mapper,
                        IRepositoryDrink repositoryDrink,
                        IRepositoryRecipe repositoryRecipe,
                        IRepositoryIngridient repositoryIngridient,
                        IRepositoryUnit repositoryUnit,
                        IRepositoryStyle repositoryStyle,
                        IRepositoryTag repositoryTag,
                        IRepositoryFlavour repositoryFlavour,
                        IRepositoryTool repositoryTool,
                        CommonServiceMidjourney commonServiceMidjourney,
                        IRepositoryColor repositoryColor,
                        IRepositoryTransparency repositoryTransparency,
                        IRepositoryGarnish repositoryGarnish,
                        IRepositoryGlass repositoryGlass,
                        IRepositoryGeneratedImage repositoryGeneratedImage,
                        IRepositoryUploadedImage repositoryUploadedImage)
    {
        _mapper = mapper;
        _repositoryDrink = repositoryDrink;
        _repositoryRecipe = repositoryRecipe;
        _repositoryIngridient = repositoryIngridient;
        _repositoryUnit = repositoryUnit;
        _repositoryStyle = repositoryStyle;
        _repositoryTag = repositoryTag;
        _repositoryFlavour = repositoryFlavour;
        _repositoryTool = repositoryTool;
        _commonServiceMidjourney = commonServiceMidjourney;
        _repositoryColor = repositoryColor;
        _repositoryTransparency = repositoryTransparency;
        _repositoryGarnish = repositoryGarnish;
        _repositoryGlass = repositoryGlass;
        _repositoryGeneratedImage = repositoryGeneratedImage;
        _repositoryUploadedImage = repositoryUploadedImage;
    }

    //Fetch
    public List<DrinkDto> GetAll() => _mapper.Map<List<Drink>, List<DrinkDto>>(_repositoryDrink.GetAll(new QueryParamDrink(false)));

    public List<DrinkDto> Take(int amount, bool loadRoot = false)
    {
        var drinks = _repositoryDrink.GetAll(new QueryParamDrink(true)).Take(amount).ToList();

        if (loadRoot)
        {
            drinks = LoadDrinkRoot(drinks);
        }

        return _mapper.Map<List<Drink>, List<DrinkDto>>(drinks);
    }

    public DrinkDto? GetById(int id, bool loadRoot = false)
    {
        var drink = _repositoryDrink.GetById(id, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }

        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public DrinkDto? GetByImage(UploadedImageDto imgDto, bool loadRoot = false)
    {
        var drink = _repositoryDrink.GetByImageId(imgDto.Id, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }
        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public DrinkDto? GetByUrlSlug(string urlSlug, bool loadRoot = false)
    {
        var drink = _repositoryDrink.GetByUrlSlug(urlSlug, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }
        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public DrinkDto PublishDrink(DrinkPublishDto drinkPublishDto)
    {
        var uploadedImage = _repositoryUploadedImage.GetById(drinkPublishDto.ImageId);
        var drink = _repositoryDrink.GetById(drinkPublishDto.DrinkId, new QueryParamDrink(false));

        drink.UploadedImage = uploadedImage;
        drink.IsPublished = true;

        _repositoryDrink.Update(drink);
        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public async Task<DrinkDto?> Create(DrinkCreateDto drinkCreateDto)
    {
        //Verify
        var tag = _repositoryTag.GetById(drinkCreateDto.TagId, new QueryParamTag(false));
        var flavour = _repositoryFlavour.GetById(drinkCreateDto.FlavourId, new QueryParamFlavour(false));
        var color = _repositoryColor.GetById(drinkCreateDto.Style.ColorId, new QueryParamColor(false));
        var transparency = _repositoryTransparency.GetById(drinkCreateDto.Style.TransparencyId, new QueryParamTransparency(false));
        var glass = _repositoryGlass.GetById(drinkCreateDto.Style.GlassId, new QueryParamGlass(false));
        var garnish = _repositoryGarnish.GetById(drinkCreateDto.Style.GarnishId, new QueryParamGarnish(false));
        if (tag == null || flavour == null || color == null || transparency == null || glass == null || garnish == null) return null;

        //Build
        var drink = _mapper.Map<DrinkCreateDto, Drink>(drinkCreateDto);
        drink.UrlSlug = drink.Name.ToLower().Trim().Replace(" ", "-");
        drink.Recipe.Equipment = drink.Recipe.Equipment.Select(x => _repositoryTool.GetById(x.Id, new QueryParamTool(false))).ToList();
        drink.Tag = tag;
        drink.Flavour = flavour;
        drink.Style.Transparency = transparency;
        drink.Style.Color = color;
        drink.Style.Garnish = garnish;
        drink.Style.Glass = glass;

        _repositoryDrink.Create(drink);

        //Generate Image
        var generationResponseDto = await _commonServiceMidjourney.SendDrinkImageGenerationRequest(drink.Style);
        if (!generationResponseDto.Success) return null;

        var generatedImage = new GeneratedImage()
        {
            Drink = drink,
            Content = "",
            OriginatingMessageId = generationResponseDto.MessageId,
            CreatedAt = DateTime.Now
        };
        _repositoryGeneratedImage.Create(generatedImage);

        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public bool UserIsOwner(ApplicationUser user, int id)
    {
        var drink = _repositoryDrink.GetById(id, new QueryParamDrink(true));

        if (drink == null || drink.Creator.Id != user.Id) return false;

        return true;
    }

    public bool IsPublished(int id)
    {
        var drink = _repositoryDrink.GetById(id, new QueryParamDrink(false));
        return drink.IsPublished;
    }

    private List<Drink> LoadDrinkRoot(IEnumerable<Drink> drinks)
    {
        foreach (var drink in drinks)
        {
            drink.Recipe = _repositoryRecipe.GetById(drink.RecipeId, new QueryParamRecipe(true));
            drink.Style = _repositoryStyle.GetById(drink.StyleId, new QueryParamStyle(true));

            foreach (var measurement in drink.Recipe.Measurements)
            {
                measurement.Ingridient = _repositoryIngridient.GetById(measurement.IngridientId, new QueryParamIngridient(false));
                measurement.Unit = _repositoryUnit.GetById(measurement.UnitId, new QueryParamUnit(false));
            }
        }
        return drinks.ToList();
    }
}