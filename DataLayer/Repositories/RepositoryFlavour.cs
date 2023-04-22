using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryFlavour
{
    Flavour Create(Flavour flavour);

    int Delete(Flavour flavour);

    int Delete(IEnumerable<Flavour> flavours);

    List<Flavour> GetAll(QueryParamFlavour queryParamFlavour);

    Flavour? GetById(int id, QueryParamFlavour queryParamFlavour);

    int Update(Flavour flavour);
}

public class RepositoryFlavour : IRepositoryFlavour
{
    private readonly ApplicationDbContext _context;

    public RepositoryFlavour(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Flavour> GetAll(QueryParamFlavour queryParamFlavour) => IncludeParameters(queryParamFlavour, _context.Flavour).ToList();

    public Flavour? GetById(int id, QueryParamFlavour queryParamFlavour) => IncludeParameters(queryParamFlavour, _context.Flavour).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Flavour Create(Flavour flavour)
    {
        _context.Flavour.Add(flavour);
        _context.SaveChanges();
        return flavour;
    }

    public int Delete(Flavour flavour)
    {
        _context.Flavour.Remove(flavour);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Flavour> flavours)
    {
        foreach (Flavour flavour in flavours) _context.Flavour.Remove(flavour);
        return _context.SaveChanges();
    }

    public int Update(Flavour flavour)
    {
        _context.Flavour.Update(flavour);
        return _context.SaveChanges();
    }

    private IQueryable<Flavour> IncludeParameters(QueryParamFlavour queryParamFlavour, DbSet<Flavour> context)
    {
        var query = context.AsQueryable();
        if (queryParamFlavour.Drinks != null) query = query.Include(o => o.Drinks);
        return query;
    }
}