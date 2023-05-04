using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceTag
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceTag(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<TagDto> GetAll() => _mapper.Map<List<Tag>, List<TagDto>>(_context.Tag.GetAll(new QueryParamTag(false)));

    public List<TagDto> Take(int amount)
    {
        var flavours = _context.Tag.GetAll(new QueryParamTag(true)).Take(amount).ToList();
        return _mapper.Map<List<Tag>, List<TagDto>>(flavours);
    }

    public TagDto? GetById(int id)
    {
        var drink = _context.Tag.GetById(id, new QueryParamTag(true));
        return _mapper.Map<Tag?, TagDto>(drink);
    }
}