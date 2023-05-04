using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceTransparency
{
    private readonly IMapper _mapper;
    private readonly IRepositoryTransparency _repositoryTransparency;

    public ServiceTransparency(IMapper mapper, IRepositoryTransparency repositoryTransparency)
    {
        _mapper = mapper;
        _repositoryTransparency = repositoryTransparency;
    }

    //Fetch
    public List<TransparencyDto> GetAll() => _mapper.Map<List<Transparency>, List<TransparencyDto>>(_repositoryTransparency.GetAll(new QueryParamTransparency(false)));

    public List<TransparencyDto> Take(int amount)
    {
        var objs = _repositoryTransparency.GetAll(new QueryParamTransparency(true)).Take(amount).ToList();
        return _mapper.Map<List<Transparency>, List<TransparencyDto>>(objs);
    }

    public TransparencyDto? GetById(int id)
    {
        var obj = _repositoryTransparency.GetById(id, new QueryParamTransparency(true));
        return _mapper.Map<Transparency?, TransparencyDto>(obj);
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