using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryTransparency
{
    Transparency Create(Transparency transparency);

    int Delete(IEnumerable<Transparency> transparencys);

    int Delete(Transparency transparency);

    List<Transparency> GetAll(QueryParamTransparency queryParamTransparency);

    Transparency? GetById(int id, QueryParamTransparency queryParamTransparency);

    int Update(Transparency transparency);
}

public class RepositoryTransparency : IRepositoryTransparency
{
    private readonly ApplicationDbContext _context;

    public RepositoryTransparency(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Transparency> GetAll(QueryParamTransparency queryParamTransparency) => IncludeParameters(queryParamTransparency, _context.Transparency).ToList();

    public Transparency? GetById(int id, QueryParamTransparency queryParamTransparency) => IncludeParameters(queryParamTransparency, _context.Transparency).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Transparency Create(Transparency transparency)
    {
        try
        {
            _context.Transparency.Add(transparency);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return transparency;
    }

    public int Delete(Transparency transparency)
    {
        try
        {
            _context.Transparency.Remove(transparency);
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Transparency> transparencys)
    {
        try
        {
            foreach (Transparency transparency in transparencys) _context.Transparency.Remove(transparency);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(Transparency transparency)
    {
        try
        {
            _context.Transparency.Update(transparency);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<Transparency> IncludeParameters(QueryParamTransparency queryParamTransparency, DbSet<Transparency> context)
    {
        var query = context.AsQueryable();
        if (queryParamTransparency.Styles != null) query = query.Include(o => o.Styles);
        return query;
    }
}