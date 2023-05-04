using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceIngridient
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceIngridient(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<IngridientDto> GetAll() => _mapper.Map<List<Ingridient>, List<IngridientDto>>(_context.Ingridient.GetAll(new QueryParamIngridient(false)));

    public List<IngridientDto> Take(int amount)
    {
        var flavours = _context.Ingridient.GetAll(new QueryParamIngridient(true)).Take(amount).ToList();
        return _mapper.Map<List<Ingridient>, List<IngridientDto>>(flavours);
    }

    public IngridientDto? GetById(int id)
    {
        var drink = _context.Ingridient.GetById(id, new QueryParamIngridient(true));
        return _mapper.Map<Ingridient?, IngridientDto>(drink);
    }
}