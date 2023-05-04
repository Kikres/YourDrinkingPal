using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceGarnish
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceGarnish(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<GarnishDto> GetAll() => _mapper.Map<List<Garnish>, List<GarnishDto>>(_context.Garnish.GetAll(new QueryParamGarnish(false)));

    public List<GarnishDto> Take(int amount)
    {
        var garnish = _context.Garnish.GetAll(new QueryParamGarnish(true)).Take(amount).ToList();
        return _mapper.Map<List<Garnish>, List<GarnishDto>>(garnish);
    }

    public GarnishDto? GetById(int id)
    {
        var garnish = _context.Garnish.GetById(id, new QueryParamGarnish(true));
        return _mapper.Map<Garnish?, GarnishDto>(garnish);
    }
}