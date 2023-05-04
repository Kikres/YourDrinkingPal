using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryUnit
{
    Unit Create(Unit unit);

    int Delete(IEnumerable<Unit> units);

    int Delete(Unit unit);

    List<Unit> GetAll(QueryParamUnit queryParamUnit);

    Unit GetById(int id, QueryParamUnit queryParamUnit);

    int Update(Unit unit);
}

public class RepositoryUnit : IRepositoryUnit
{
    private readonly ApplicationDbContext _context;

    public RepositoryUnit(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Unit> GetAll(QueryParamUnit queryParamUnit) => IncludeParameters(queryParamUnit, _context.Unit).ToList();

    public Unit GetById(int id, QueryParamUnit queryParamUnit) => IncludeParameters(queryParamUnit, _context.Unit).First(o => o.Id == id);

    //Manipulate
    public Unit Create(Unit unit)
    {
        try
        {
            _context.Unit.Add(unit);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return unit;
    }

    public int Delete(Unit unit)
    {
        try
        {
            _context.Unit.Remove(unit);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Delete(IEnumerable<Unit> units)
    {
        try
        {
            foreach (Unit unit in units) _context.Unit.Remove(unit);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(Unit unit)
    {
        try
        {
            _context.Unit.Update(unit);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<Unit> IncludeParameters(QueryParamUnit queryParamUnit, DbSet<Unit> context)
    {
        var query = context.AsQueryable();
        if (queryParamUnit.Measurements != null) query = query.Include(o => o.Measurements);
        return query;
    }
}