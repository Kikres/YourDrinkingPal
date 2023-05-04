using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryGarnish
{
    Garnish Create(Garnish garnish);

    int Delete(IEnumerable<Garnish> garnishs);

    int Delete(Garnish garnish);

    List<Garnish> GetAll(QueryParamGarnish queryParamGarnish);

    Garnish? GetById(int id, QueryParamGarnish queryParamGarnish);

    int Update(Garnish garnish);
}

public class RepositoryGarnish : IRepositoryGarnish
{
    private readonly ApplicationDbContext _context;

    public RepositoryGarnish(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Garnish> GetAll(QueryParamGarnish queryParamGarnish) => IncludeParameters(queryParamGarnish, _context.Garnish).ToList();

    public Garnish? GetById(int id, QueryParamGarnish queryParamGarnish) => IncludeParameters(queryParamGarnish, _context.Garnish).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Garnish Create(Garnish garnish)
    {
        _context.Garnish.Add(garnish);
        _context.SaveChanges();
        return garnish;
    }

    public int Delete(Garnish garnish)
    {
        _context.Garnish.Remove(garnish);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Garnish> garnishs)
    {
        foreach (Garnish garnish in garnishs) _context.Garnish.Remove(garnish);
        return _context.SaveChanges();
    }

    public int Update(Garnish garnish)
    {
        _context.Garnish.Update(garnish);
        return _context.SaveChanges();
    }

    private IQueryable<Garnish> IncludeParameters(QueryParamGarnish queryParamGarnish, DbSet<Garnish> context)
    {
        var query = context.AsQueryable();
        if (queryParamGarnish.Styles != null) query = query.Include(o => o.Styles);
        return query;
    }
}