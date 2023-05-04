using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceMeasurement
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceMeasurement(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<MeasurementDto> GetAll() => _mapper.Map<List<Measurement>, List<MeasurementDto>>(_context.Measurement.GetAll(new QueryParamMeasurement(false)));

    public List<MeasurementDto> Take(int amount)
    {
        var objs = _context.Measurement.GetAll(new QueryParamMeasurement(true)).Take(amount).ToList();
        return _mapper.Map<List<Measurement>, List<MeasurementDto>>(objs);
    }

    public MeasurementDto? GetById(int id)
    {
        var obj = _context.Measurement.GetById(id, new QueryParamMeasurement(true));
        return _mapper.Map<Measurement?, MeasurementDto>(obj);
    }

    //public ClientDto GetByName(string name) => _mapper.Map<Client?, ClientDto>(_context.Client.GetByName(name, new QueryParamClient()));

    ////Manipulate
    //public ClientDto Create(ClientCreateDto dto) => _mapper.Map<Client, ClientDto>(_context.Client.Create(_mapper.Map<ClientCreateDto, Client>(dto)));

    //public bool Delete(int clientId) => _context.Client.Delete(_context.Client.GetById(clientId, new QueryParamClient())) + _context.Contract.Delete(_context.Contract.GetAllByClient(clientId, new QueryParamConract())) > 0;

    //public bool Update(ClientUpdateDto dto)
    //{
    //    var client = _context.Client.GetById(dto.Id, new QueryParamClient(true));

    //    //Solved like this due to nullable int
    //    if (dto.OrganizationId == null) dto.OrganizationId = client.OrganizationId;

    //    return _context.Client.Update(_mapper.Map(dto, client)) > 0;
    //}

    ////Check
    //public bool ClientExists(int id) => _context.Client.GetById(id, new QueryParamClient()) != null;
}