using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace Business_Layer.Services;

public class ServiceFlavour
{
    private readonly IMapper _mapper;
    private readonly IRepositoryFlavour _repositoryFlavour;

    public ServiceFlavour(IMapper mapper, IRepositoryFlavour repositoryFlavour)
    {
        _mapper = mapper;
        _repositoryFlavour = repositoryFlavour;
    }

    //Fetch
    public List<FlavourDto> GetAll() => _mapper.Map<List<Flavour>, List<FlavourDto>>(_repositoryFlavour.GetAll(new QueryParamFlavour(false)));

    public List<FlavourDto> Take(int amount)
    {
        var flavours = _repositoryFlavour.GetAll(new QueryParamFlavour(true)).Take(amount).ToList();
        return _mapper.Map<List<Flavour>, List<FlavourDto>>(flavours);
    }

    public FlavourDto? GetById(int id)
    {
        var drink = _repositoryFlavour.GetById(id, new QueryParamFlavour(true));
        return _mapper.Map<Flavour?, FlavourDto>(drink);
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