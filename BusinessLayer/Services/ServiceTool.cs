using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceTool
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceTool(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<ToolDto> GetAll() => _mapper.Map<List<Tool>, List<ToolDto>>(_context.Tool.GetAll(new QueryParamTool(false)));

    public List<ToolDto> Take(int amount)
    {
        var objs = _context.Tool.GetAll(new QueryParamTool(true)).Take(amount).ToList();
        return _mapper.Map<List<Tool>, List<ToolDto>>(objs);
    }

    public ToolDto? GetById(int id)
    {
        var obj = _context.Tool.GetById(id, new QueryParamTool(true));
        return _mapper.Map<Tool?, ToolDto>(obj);
    }
}