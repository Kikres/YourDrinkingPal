using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceInstruction
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceInstruction(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<InstructionDto> GetAll() => _mapper.Map<List<Instruction>, List<InstructionDto>>(_context.Instruction.GetAll(new QueryParamInstruction(false)));

    public List<InstructionDto> Take(int amount)
    {
        var instructions = _context.Instruction.GetAll(new QueryParamInstruction(true)).Take(amount).ToList();
        return _mapper.Map<List<Instruction>, List<InstructionDto>>(instructions);
    }

    public InstructionDto? GetById(int id)
    {
        var instruction = _context.Instruction.GetById(id, new QueryParamInstruction(true));
        return _mapper.Map<Instruction?, InstructionDto>(instruction);
    }
}