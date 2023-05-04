using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceIngridient
{
    private readonly IMapper _mapper;
    private readonly IRepositoryIngridient _repositoryIngridient;

    public ServiceIngridient(IMapper mapper, IRepositoryIngridient repositoryIngridient)
    {
        _mapper = mapper;
        _repositoryIngridient = repositoryIngridient;
    }

    //Fetch
    public List<IngridientDto> GetAll() => _mapper.Map<List<Ingridient>, List<IngridientDto>>(_repositoryIngridient.GetAll(new QueryParamIngridient(false)));

    public List<IngridientDto> Take(int amount)
    {
        var flavours = _repositoryIngridient.GetAll(new QueryParamIngridient(true)).Take(amount).ToList();
        return _mapper.Map<List<Ingridient>, List<IngridientDto>>(flavours);
    }

    public IngridientDto? GetById(int id)
    {
        var drink = _repositoryIngridient.GetById(id, new QueryParamIngridient(true));
        return _mapper.Map<Ingridient?, IngridientDto>(drink);
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