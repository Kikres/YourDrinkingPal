using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceRecipe
{
    private readonly IMapper _mapper;
    private readonly IRepositoryRecipe _repositoryRecipe;

    public ServiceRecipe(IMapper mapper, IRepositoryRecipe repositoryRecipe)
    {
        _mapper = mapper;
        _repositoryRecipe = repositoryRecipe;
    }

    //Fetch
    public List<RecipeDto> GetAll() => _mapper.Map<List<Recipe>, List<RecipeDto>>(_repositoryRecipe.GetAll(new QueryParamRecipe(false)));

    public List<RecipeDto> Take(int amount)
    {
        var flavours = _repositoryRecipe.GetAll(new QueryParamRecipe(true)).Take(amount).ToList();
        return _mapper.Map<List<Recipe>, List<RecipeDto>>(flavours);
    }

    public RecipeDto? GetById(int id)
    {
        var drink = _repositoryRecipe.GetById(id, new QueryParamRecipe(true));
        return _mapper.Map<Recipe?, RecipeDto>(drink);
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