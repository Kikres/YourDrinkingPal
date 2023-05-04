using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceFlavour
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceFlavour(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<FlavourDto> GetAll() => _mapper.Map<List<Flavour>, List<FlavourDto>>(_context.Flavour.GetAll(new QueryParamFlavour(false)));

    public List<FlavourDto> Take(int amount)
    {
        var flavours = _context.Flavour.GetAll(new QueryParamFlavour(true)).Take(amount).ToList();
        return _mapper.Map<List<Flavour>, List<FlavourDto>>(flavours);
    }

    public FlavourDto? GetById(int id)
    {
        var drink = _context.Flavour.GetById(id, new QueryParamFlavour(true));
        return _mapper.Map<Flavour?, FlavourDto>(drink);
    }
}