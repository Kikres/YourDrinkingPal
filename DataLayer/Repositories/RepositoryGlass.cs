using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryGlass
{
    Glass Create(Glass glass);

    int Delete(Glass glass);

    int Delete(IEnumerable<Glass> obj);

    List<Glass> GetAll(QueryParamGlass queryParamGlass);

    Glass? GetById(int id, QueryParamGlass queryParamGlass);

    int Update(Glass glass);
}

public class RepositoryGlass : IRepositoryGlass
{
    private readonly ApplicationDbContext _context;

    public RepositoryGlass(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Glass> GetAll(QueryParamGlass queryParamGlass) => IncludeParameters(queryParamGlass, _context.Glass).ToList();

    public Glass? GetById(int id, QueryParamGlass queryParamGlass) => IncludeParameters(queryParamGlass, _context.Glass).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Glass Create(Glass glass)
    {
        _context.Glass.Add(glass);
        _context.SaveChanges();
        return glass;
    }

    public int Delete(Glass glass)
    {
        _context.Glass.Remove(glass);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Glass> obj)
    {
        foreach (Glass glass in obj) _context.Glass.Remove(glass);
        return _context.SaveChanges();
    }

    public int Update(Glass glass)
    {
        _context.Glass.Update(glass);
        return _context.SaveChanges();
    }

    private IQueryable<Glass> IncludeParameters(QueryParamGlass queryParamGlass, DbSet<Glass> context)
    {
        var query = context.AsQueryable();
        if (queryParamGlass.Drinks != null) query = query.Include(o => o.Drinks);
        return query;
    }
}