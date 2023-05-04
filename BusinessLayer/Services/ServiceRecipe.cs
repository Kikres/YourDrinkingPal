using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceRecipe
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceRecipe(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<RecipeDto> GetAll() => _mapper.Map<List<Recipe>, List<RecipeDto>>(_context.Recipe.GetAll(new QueryParamRecipe(false)));

    public List<RecipeDto> Take(int amount)
    {
        var flavours = _context.Recipe.GetAll(new QueryParamRecipe(true)).Take(amount).ToList();
        return _mapper.Map<List<Recipe>, List<RecipeDto>>(flavours);
    }

    public RecipeDto? GetById(int id)
    {
        var drink = _context.Recipe.GetById(id, new QueryParamRecipe(true));
        return _mapper.Map<Recipe?, RecipeDto>(drink);
    }
}