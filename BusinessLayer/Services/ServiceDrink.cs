using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using BusinessLayer.Services.CommonServices;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceDrink
{
    private readonly IMapper _mapper;
    private readonly IContext _context;
    private readonly CommonServiceMidjourney _commonServiceMidjourney;

    public ServiceDrink(IMapper mapper, IContext context, CommonServiceMidjourney commonServiceMidjourney)
    {
        _mapper = mapper;
        _context = context;
        _commonServiceMidjourney = commonServiceMidjourney;
    }

    //Fetch
    public List<DrinkDto> GetAll(bool loadRoot = false)
    {
        var drinks = _context.Drink.GetAll(new QueryParamDrink(false));

        if (loadRoot)
        {
            drinks = LoadDrinkRoot(drinks);
        }
        return _mapper.Map<List<Drink>, List<DrinkDto>>(drinks);
    }

    public List<DrinkDto> GetAllPublished(bool loadRoot = false)
    {
        var drinks = _context.Drink.GetAllPublished(new QueryParamDrink(false));

        if (loadRoot)
        {
            drinks = LoadDrinkRoot(drinks);
        }
        return _mapper.Map<List<Drink>, List<DrinkDto>>(drinks);
    }

    public List<DrinkDto> Take(int amount, bool loadRoot = false)
    {
        var drinks = _context.Drink.GetAll(new QueryParamDrink(true)).Take(amount).ToList();

        if (loadRoot)
        {
            drinks = LoadDrinkRoot(drinks);
        }

        return _mapper.Map<List<Drink>, List<DrinkDto>>(drinks);
    }

    public DrinkDto? GetById(int id, bool loadRoot = false)
    {
        var drink = _context.Drink.GetById(id, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }

        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public DrinkDto? GetByImage(UploadedImageDto imgDto, bool loadRoot = false)
    {
        var drink = _context.Drink.GetByImageId(imgDto.Id, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }
        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public DrinkDto? GetByUrlSlug(string urlSlug, bool loadRoot = false)
    {
        var drink = _context.Drink.GetByUrlSlug(urlSlug, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }
        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public DrinkDto PublishDrink(DrinkPublishDto drinkPublishDto)
    {
        var uploadedImage = _context.UploadedImage.GetById(drinkPublishDto.ImageId);
        var drink = _context.Drink.GetById(drinkPublishDto.DrinkId, new QueryParamDrink(false));

        drink.UploadedImage = uploadedImage;
        drink.IsPublished = true;

        _context.Drink.Update(drink);
        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public bool VerifyDrinkCreateDto(DrinkCreateDto drinkCreateDto)
    {
        var tag = _context.Tag.GetById(drinkCreateDto.TagId, new QueryParamTag(false));
        var flavour = _context.Flavour.GetById(drinkCreateDto.FlavourId, new QueryParamFlavour(false));
        var color = _context.Color.GetById(drinkCreateDto.Style.ColorId, new QueryParamColor(false));
        var transparency = _context.Transparency.GetById(drinkCreateDto.Style.TransparencyId, new QueryParamTransparency(false));
        var glass = _context.Glass.GetById(drinkCreateDto.Style.GlassId, new QueryParamGlass(false));
        var garnish = _context.Garnish.GetById(drinkCreateDto.Style.GarnishId, new QueryParamGarnish(false));
        var tools = drinkCreateDto.Recipe.Equipment.Select(x => _context.Tool.GetById(x.Id, new QueryParamTool(false)) == null);
        return !(tag == null || flavour == null || color == null || transparency == null || glass == null || garnish == null || tools != null);
    }

    public async Task<DrinkDto?> Create(DrinkCreateDto drinkCreateDto)
    {
        //Load
        var drink = _mapper.Map<DrinkCreateDto, Drink>(drinkCreateDto);
        var tag = _context.Tag.GetById(drinkCreateDto.TagId, new QueryParamTag(false));
        var flavour = _context.Flavour.GetById(drinkCreateDto.FlavourId, new QueryParamFlavour(false));
        var color = _context.Color.GetById(drinkCreateDto.Style.ColorId, new QueryParamColor(false));
        var transparency = _context.Transparency.GetById(drinkCreateDto.Style.TransparencyId, new QueryParamTransparency(false));
        var glass = _context.Glass.GetById(drinkCreateDto.Style.GlassId, new QueryParamGlass(false));
        var garnish = _context.Garnish.GetById(drinkCreateDto.Style.GarnishId, new QueryParamGarnish(false));
        var tools = drinkCreateDto.Recipe.Equipment.Select(x => _context.Tool.GetById(x.Id, new QueryParamTool(false)) == null);

        //Build
        drink.UrlSlug = drink.Name.ToLower().Trim().Replace(" ", "-");
        drink.Recipe.Equipment = drink.Recipe.Equipment.Select(x => _context.Tool.GetById(x.Id, new QueryParamTool(false))).ToList();
        drink.Tag = tag;
        drink.Flavour = flavour;
        drink.Style.Color = color;
        drink.Style.Transparency = transparency;
        drink.Style.Glass = glass;
        drink.Style.Garnish = garnish;
        _context.Drink.Create(drink);

        /*
           Vid problem skicka till följande till endpoint https://localhost:7132/api/GeneratedImage och använd den färdiga responsen:
           {
              "content": " Product photography of a Purple-cocktail, liquids opacity is semi-opaque Purple, garnished with cellery, high resolution photography, hyper-detailed, professional color grading, soft focus colourful modern kitchen background, standing on a white marble table with decorations around, white light, 35mm lens, f1.8, 8k --v 5 ",
              "imageUrl": "https://cdn.discordapp.com/attachments/1101171109375778836/1102691025656479804/Lorie_R._Whitmore_Product_photography_of_a_Purple-cocktail_liqu_fa5ca070-d245-4619-9cce-6165af02d7b2.png",
              "buttons": [
                "U1",
                "U2",
                "U3",
                "U4",
                "V1",
                "V2",
                "V3",
                "V4"
              ],
              "createdAt": "2023-05-01T20:20:27.865Z",
              "responseAt": "2023-05-01T20:20:28.163Z",
              "ref": "",
              "originatingMessageId": "oP9hmbXkV8dO12mnis8y",
              "buttonMessageId": "X3ZGVIQu2iDikGxRuqNd"
            }
        */

        var overrideGenerationRequest = false;
        MidjourneyResponseDto midjourneyResponseDto = overrideGenerationRequest ? new MidjourneyResponseDto
        {
            Success = true,
            CreatedAt = DateTime.Now,
            MessageId = "oP9hmbXkV8dO12mnis8y",
        } : await _commonServiceMidjourney.SendDrinkImageGenerationRequest(drink.Style);

        var generatedImage = new GeneratedImage()
        {
            Drink = drink,
            Content = "",
            OriginatingMessageId = midjourneyResponseDto.MessageId,
            CreatedAt = DateTime.Now
        };
        _context.GeneratedImage.Create(generatedImage);

        return _mapper.Map<Drink, DrinkDto>(drink);
    }

    public bool UserIsOwner(ApplicationUser user, int id)
    {
        var drink = _context.Drink.GetById(id, new QueryParamDrink(true));

        if (drink == null || drink.Creator.Id != user.Id) return false;

        return true;
    }

    public bool IsPublished(int id)
    {
        var drink = _context.Drink.GetById(id, new QueryParamDrink(false));
        return drink.IsPublished;
    }

    public bool ExistsByUrlSlug(string urlSlug)
    {
        var drink = _context.Drink.GetByUrlSlug(urlSlug, new QueryParamDrink(false));
        return drink != null;
    }

    private List<Drink> LoadDrinkRoot(IEnumerable<Drink> drinks)
    {
        foreach (var drink in drinks)
        {
            drink.Recipe = _context.Recipe.GetById(drink.RecipeId, new QueryParamRecipe(true));
            drink.Style = _context.Style.GetById(drink.StyleId, new QueryParamStyle(true));
            if (drink.UploadedImageId != null)
            {
                drink.UploadedImage = _context.UploadedImage.GetById((int)drink.UploadedImageId);
            }

            foreach (var measurement in drink.Recipe.Measurements)
            {
                measurement.Ingridient = _context.Ingridient.GetById(measurement.IngridientId, new QueryParamIngridient(false));
                measurement.Unit = _context.Unit.GetById(measurement.UnitId, new QueryParamUnit(false));
            }
        }
        return drinks.ToList();
    }
}