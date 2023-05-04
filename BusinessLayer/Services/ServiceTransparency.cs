using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceTransparency
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceTransparency(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<TransparencyDto> GetAll() => _mapper.Map<List<Transparency>, List<TransparencyDto>>(_context.Transparency.GetAll(new QueryParamTransparency(false)));

    public List<TransparencyDto> Take(int amount)
    {
        var objs = _context.Transparency.GetAll(new QueryParamTransparency(true)).Take(amount).ToList();
        return _mapper.Map<List<Transparency>, List<TransparencyDto>>(objs);
    }

    public TransparencyDto? GetById(int id)
    {
        var obj = _context.Transparency.GetById(id, new QueryParamTransparency(true));
        return _mapper.Map<Transparency?, TransparencyDto>(obj);
    }
}