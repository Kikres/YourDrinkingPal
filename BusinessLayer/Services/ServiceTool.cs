using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceTool
{
    private readonly IMapper _mapper;
    private readonly IRepositoryTool _repositoryTool;

    public ServiceTool(IMapper mapper, IRepositoryTool repositoryTool)
    {
        _mapper = mapper;
        _repositoryTool = repositoryTool;
    }

    //Fetch
    public List<ToolDto> GetAll() => _mapper.Map<List<Tool>, List<ToolDto>>(_repositoryTool.GetAll(new QueryParamTool(false)));

    public List<ToolDto> Take(int amount)
    {
        var objs = _repositoryTool.GetAll(new QueryParamTool(true)).Take(amount).ToList();
        return _mapper.Map<List<Tool>, List<ToolDto>>(objs);
    }

    public ToolDto? GetById(int id)
    {
        var obj = _repositoryTool.GetById(id, new QueryParamTool(true));
        return _mapper.Map<Tool?, ToolDto>(obj);
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