using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryIngridient
{
    Ingridient Create(Ingridient ingridient);

    int Delete(IEnumerable<Ingridient> ingridients);

    int Delete(Ingridient ingridient);

    List<Ingridient> GetAll(QueryParamIngridient queryParamIngridient);

    Ingridient GetById(int id, QueryParamIngridient queryParamIngridient);

    int Update(Ingridient ingridient);
}

public class RepositoryIngridient : IRepositoryIngridient
{
    private readonly ApplicationDbContext _context;

    public RepositoryIngridient(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Ingridient> GetAll(QueryParamIngridient queryParamIngridient) => IncludeParameters(queryParamIngridient, _context.Ingridient).ToList();

    public Ingridient GetById(int id, QueryParamIngridient queryParamIngridient) => IncludeParameters(queryParamIngridient, _context.Ingridient).First(o => o.Id == id);

    //Manipulate
    public Ingridient Create(Ingridient ingridient)
    {
        _context.Ingridient.Add(ingridient);
        _context.SaveChanges();
        return ingridient;
    }

    public int Delete(Ingridient ingridient)
    {
        _context.Ingridient.Remove(ingridient);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Ingridient> ingridients)
    {
        foreach (Ingridient ingridient in ingridients) _context.Ingridient.Remove(ingridient);
        return _context.SaveChanges();
    }

    public int Update(Ingridient ingridient)
    {
        _context.Ingridient.Update(ingridient);
        return _context.SaveChanges();
    }

    private IQueryable<Ingridient> IncludeParameters(QueryParamIngridient queryParamIngridient, DbSet<Ingridient> context)
    {
        var query = context.AsQueryable();
        if (queryParamIngridient.Measurements != null) query = query.Include(o => o.Measurements);
        return query;
    }
}