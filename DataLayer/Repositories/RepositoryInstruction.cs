using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryInstruction
{
    Instruction Create(Instruction instruction);

    int Delete(IEnumerable<Instruction> instructions);

    int Delete(Instruction instruction);

    List<Instruction> GetAll(QueryParamInstruction queryParamInstruction);

    Instruction? GetById(int id, QueryParamInstruction queryParamInstruction);

    int Update(Instruction instruction);
}

public class RepositoryInstruction : IRepositoryInstruction
{
    private readonly ApplicationDbContext _context;

    public RepositoryInstruction(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Instruction> GetAll(QueryParamInstruction queryParamInstruction) => IncludeParameters(queryParamInstruction, _context.Instruction).ToList();

    public Instruction? GetById(int id, QueryParamInstruction queryParamInstruction) => IncludeParameters(queryParamInstruction, _context.Instruction).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Instruction Create(Instruction instruction)
    {
        _context.Instruction.Add(instruction);
        _context.SaveChanges();
        return instruction;
    }

    public int Delete(Instruction instruction)
    {
        _context.Instruction.Remove(instruction);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Instruction> instructions)
    {
        foreach (Instruction instruction in instructions) _context.Instruction.Remove(instruction);
        return _context.SaveChanges();
    }

    public int Update(Instruction instruction)
    {
        _context.Instruction.Update(instruction);
        return _context.SaveChanges();
    }

    private IQueryable<Instruction> IncludeParameters(QueryParamInstruction queryParamInstruction, DbSet<Instruction> context)
    {
        var query = context.AsQueryable();
        //if (queryParamInstruction.Measurements != null) query = query.Include(o => o.Measurements);
        return query;
    }
}