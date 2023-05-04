using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceUnit
{
    private readonly IMapper _mapper;
    private readonly IRepositoryUnit _repositoryUnit;

    public ServiceUnit(IMapper mapper, IRepositoryUnit repositoryUnit)
    {
        _mapper = mapper;
        _repositoryUnit = repositoryUnit;
    }

    //Fetch
    public List<UnitDto> GetAll() => _mapper.Map<List<Unit>, List<UnitDto>>(_repositoryUnit.GetAll(new QueryParamUnit(false)));

    public List<UnitDto> Take(int amount)
    {
        var objs = _repositoryUnit.GetAll(new QueryParamUnit(true)).Take(amount).ToList();
        return _mapper.Map<List<Unit>, List<UnitDto>>(objs);
    }

    public UnitDto? GetById(int id)
    {
        var obj = _repositoryUnit.GetById(id, new QueryParamUnit(true));
        return _mapper.Map<Unit?, UnitDto>(obj);
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