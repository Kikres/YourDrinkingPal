using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceUnit
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceUnit(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<UnitDto> GetAll() => _mapper.Map<List<Unit>, List<UnitDto>>(_context.Unit.GetAll(new QueryParamUnit(false)));

    public List<UnitDto> Take(int amount)
    {
        var objs = _context.Unit.GetAll(new QueryParamUnit(true)).Take(amount).ToList();
        return _mapper.Map<List<Unit>, List<UnitDto>>(objs);
    }

    public UnitDto? GetById(int id)
    {
        var obj = _context.Unit.GetById(id, new QueryParamUnit(true));
        return _mapper.Map<Unit?, UnitDto>(obj);
    }
}