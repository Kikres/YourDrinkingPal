using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceColor
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceColor(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<ColorDto> GetAll() => _mapper.Map<List<Color>, List<ColorDto>>(_context.Color.GetAll(new QueryParamColor(false)));

    public List<ColorDto> Take(int amount)
    {
        var objs = _context.Color.GetAll(new QueryParamColor(true)).Take(amount).ToList();
        return _mapper.Map<List<Color>, List<ColorDto>>(objs);
    }

    public ColorDto? GetById(int id)
    {
        var obj = _context.Color.GetById(id, new QueryParamColor(true));
        return _mapper.Map<Color?, ColorDto>(obj);
    }
}