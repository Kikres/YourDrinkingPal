using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;

namespace BusinessLayer.Services;

public class ServiceMeasurement
{
    private readonly IMapper _mapper;
    private readonly IRepositoryMeasurement _repositoryMeasurement;

    public ServiceMeasurement(IMapper mapper, IRepositoryMeasurement repositoryMeasurement)
    {
        _mapper = mapper;
        _repositoryMeasurement = repositoryMeasurement;
    }

    //Fetch
    public List<MeasurementDto> GetAll() => _mapper.Map<List<Measurement>, List<MeasurementDto>>(_repositoryMeasurement.GetAll(new QueryParamMeasurement(false)));

    public List<MeasurementDto> Take(int amount)
    {
        var objs = _repositoryMeasurement.GetAll(new QueryParamMeasurement(true)).Take(amount).ToList();
        return _mapper.Map<List<Measurement>, List<MeasurementDto>>(objs);
    }

    public MeasurementDto? GetById(int id)
    {
        var obj = _repositoryMeasurement.GetById(id, new QueryParamMeasurement(true));
        return _mapper.Map<Measurement?, MeasurementDto>(obj);
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