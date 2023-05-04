using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceStyle
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceStyle(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<StyleDto> GetAll() => _mapper.Map<List<Style>, List<StyleDto>>(_context.Style.GetAll(new QueryParamStyle(false)));

    public List<StyleDto> Take(int amount)
    {
        var objs = _context.Style.GetAll(new QueryParamStyle(true)).Take(amount).ToList();
        return _mapper.Map<List<Style>, List<StyleDto>>(objs);
    }

    public StyleDto? GetById(int id)
    {
        var obj = _context.Style.GetById(id, new QueryParamStyle(true));
        return _mapper.Map<Style?, StyleDto>(obj);
    }
}