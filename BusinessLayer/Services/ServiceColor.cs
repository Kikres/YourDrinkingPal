using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceColor
{
    private readonly IMapper _mapper;
    private readonly IRepositoryColor _repositoryColor;

    public ServiceColor(IMapper mapper, IRepositoryColor repositoryColor)
    {
        _mapper = mapper;
        _repositoryColor = repositoryColor;
    }

    //Fetch
    public List<ColorDto> GetAll() => _mapper.Map<List<Color>, List<ColorDto>>(_repositoryColor.GetAll(new QueryParamColor(false)));

    public List<ColorDto> Take(int amount)
    {
        var objs = _repositoryColor.GetAll(new QueryParamColor(true)).Take(amount).ToList();
        return _mapper.Map<List<Color>, List<ColorDto>>(objs);
    }

    public ColorDto? GetById(int id)
    {
        var obj = _repositoryColor.GetById(id, new QueryParamColor(true));
        return _mapper.Map<Color?, ColorDto>(obj);
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