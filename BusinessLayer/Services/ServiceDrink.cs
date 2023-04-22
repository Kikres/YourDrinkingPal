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
    private readonly IMapper _mapper;

    public ServiceDrink(IRepositoryDrink repositoryDrink, IMapper mapper)
    {
        _mapper = mapper;
        _repositoryDrink = repositoryDrink;
    }

    //Fetch
    public List<DrinkDto> GetAll() => _mapper.Map<List<Drink>, List<DrinkDto>>(_repositoryDrink.GetAll(new QueryParamDrink(false)));

    public List<DrinkDto> Take(int amount)
    {
        var drinks = _repositoryDrink.GetAll(new QueryParamDrink(false)).Take(amount).ToList();

        foreach (var drink in drinks)
        {
            drink.Recipe
        }

        return _mapper.Map<List<Drink>, List<DrinkDto>>(drinks);
    }

    public DrinkDto GetById(int id)
    {
        var drink = _repositoryDrink.GetById(id, new QueryParamDrink(true));

        return _mapper.Map<Drink?, DrinkDto>(drink);
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