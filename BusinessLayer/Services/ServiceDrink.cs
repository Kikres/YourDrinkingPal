using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace Business_Layer.Services;

public class ServiceDrink
{
    private readonly IRepositoryDrink _repositoryDrink;
    private readonly IRepositoryRecipe _repositoryRecipe;
    private readonly IRepositoryIngridient _repositoryIngridient;
    private readonly IRepositoryUnit _repositoryUnit;
    private readonly IMapper _mapper;

    public ServiceDrink(IMapper mapper, IRepositoryDrink repositoryDrink, IRepositoryRecipe repositoryRecipe, IRepositoryIngridient repositoryIngridient, IRepositoryUnit repositoryUnit)
    {
        _mapper = mapper;
        _repositoryDrink = repositoryDrink;
        _repositoryRecipe = repositoryRecipe;
        _repositoryIngridient = repositoryIngridient;
        _repositoryUnit = repositoryUnit;
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

        return _mapper.Map<Drink?, DrinkDto>(drink);
    }

    public DrinkDto? GetByUrlSlug(string urlSlug, bool loadRoot = false)
    {
        var drink = _repositoryDrink.GetByUrlSlug(urlSlug, new QueryParamDrink(true));
        if (drink == null) return null;
        if (loadRoot)
        {
            drink = LoadDrinkRoot(new List<Drink>() { drink }).First();
        }
        return _mapper.Map<Drink?, DrinkDto>(drink);
    }

    private List<Drink> LoadDrinkRoot(IEnumerable<Drink> drinks)
    {
        foreach (var drink in drinks)
        {
            drink.Recipe = _repositoryRecipe.GetById(drink.RecipeId, new QueryParamRecipe(true));
            foreach (var measurement in drink.Recipe.Measurements)
            {
                measurement.Ingridient = _repositoryIngridient.GetById(measurement.IngridientId, new QueryParamIngridient(false));
                measurement.Unit = _repositoryUnit.GetById(measurement.UnitId, new QueryParamUnit(false));
            }
        }
        return drinks.ToList();
    }

    //public ClientDto GetByName(string name) => _mapper.Map<Client?, ClientDto>(_repositoryClient.GetByName(name, new QueryParamClient()));

    ////Manipulate
    //public ClientDto Create(ClientCreateDto dto) => _mapper.Map<Client, ClientDto>(_repositoryClient.Create(_mapper.Map<ClientCreateDto, Client>(dto)));

    //public bool Delete(int clientId) => _repositoryClient.Delete(_repositoryClient.GetById(clientId, new QueryParamClient())) + _repositoryContract.Delete(_repositoryContract.GetAllByClient(clientId, new QueryParamConract())) > 0;

    //public bool Update(ClientUpdateDto dto)
    //{
    //    var client = _repositoryClient.GetById(dto.Id, new QueryParamClient(true));

    //    //Solved like this due to nullable int
    //    if (dto.OrganizationId == null) dto.OrganizationId = client.OrganizationId;

    //    return _repositoryClient.Update(_mapper.Map(dto, client)) > 0;
    //}

    ////Check
    //public bool ClientExists(int id) => _repositoryClient.GetById(id, new QueryParamClient()) != null;
}