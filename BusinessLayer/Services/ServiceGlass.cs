using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceGlass
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceGlass(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<GlassDto> GetAll() => _mapper.Map<List<Glass>, List<GlassDto>>(_context.Glass.GetAll(new QueryParamGlass(false)));

    public List<GlassDto> Take(int amount)
    {
        var flavours = _context.Glass.GetAll(new QueryParamGlass(true)).Take(amount).ToList();
        return _mapper.Map<List<Glass>, List<GlassDto>>(flavours);
    }

    public GlassDto? GetById(int id)
    {
        var drink = _context.Glass.GetById(id, new QueryParamGlass(true));
        return _mapper.Map<Glass?, GlassDto>(drink);
    }
}