using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceGarnish
{
    private readonly IMapper _mapper;
    private readonly IRepositoryGarnish _repositoryGarnish;

    public ServiceGarnish(IMapper mapper, IRepositoryGarnish repositoryGarnish)
    {
        _mapper = mapper;
        _repositoryGarnish = repositoryGarnish;
    }

    //Fetch
    public List<GarnishDto> GetAll() => _mapper.Map<List<Garnish>, List<GarnishDto>>(_repositoryGarnish.GetAll(new QueryParamGarnish(false)));

    public List<GarnishDto> Take(int amount)
    {
        var garnish = _repositoryGarnish.GetAll(new QueryParamGarnish(true)).Take(amount).ToList();
        return _mapper.Map<List<Garnish>, List<GarnishDto>>(garnish);
    }

    public GarnishDto? GetById(int id)
    {
        var garnish = _repositoryGarnish.GetById(id, new QueryParamGarnish(true));
        return _mapper.Map<Garnish?, GarnishDto>(garnish);
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