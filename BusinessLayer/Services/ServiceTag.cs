using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceTag
{
    private readonly IMapper _mapper;
    private readonly IRepositoryTag _repositoryTag;

    public ServiceTag(IMapper mapper, IRepositoryTag repositoryTag)
    {
        _mapper = mapper;
        _repositoryTag = repositoryTag;
    }

    //Fetch
    public List<TagDto> GetAll() => _mapper.Map<List<Tag>, List<TagDto>>(_repositoryTag.GetAll(new QueryParamTag(false)));

    public List<TagDto> Take(int amount)
    {
        var flavours = _repositoryTag.GetAll(new QueryParamTag(true)).Take(amount).ToList();
        return _mapper.Map<List<Tag>, List<TagDto>>(flavours);
    }

    public TagDto? GetById(int id)
    {
        var drink = _repositoryTag.GetById(id, new QueryParamTag(true));
        return _mapper.Map<Tag?, TagDto>(drink);
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