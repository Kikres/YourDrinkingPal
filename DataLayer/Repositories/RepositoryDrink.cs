using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryDrink
{
    Drink Create(Drink drink);

    int Delete(Drink drink);

    int Delete(IEnumerable<Drink> drinks);

    List<Drink> GetAll(QueryParamDrink queryParamDrink);

    Drink? GetById(int id, QueryParamDrink queryParamDrink);

    Drink? GetByUrlSlug(string urlSlug, QueryParamDrink queryParamDrink);

    int Update(Drink drink);
}

public class RepositoryDrink : IRepositoryDrink
{
    private readonly ApplicationDbContext _context;

    public RepositoryDrink(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Drink> GetAll(QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).ToList();

    public Drink? GetById(int id, QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).FirstOrDefault(o => o.Id == id);

    public Drink? GetByUrlSlug(string urlSlug, QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).FirstOrDefault(o => o.UrlSlug == urlSlug);

    //Manipulate
    public Drink Create(Drink drink)
    {
        _context.Drink.Add(drink);
        _context.SaveChanges();
        return drink;
    }

    public int Delete(Drink drink)
    {
        _context.Drink.Remove(drink);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Drink> drinks)
    {
        foreach (Drink drink in drinks) _context.Drink.Remove(drink);
        return _context.SaveChanges();
    }

    public int Update(Drink drink)
    {
        _context.Drink.Update(drink);
        return _context.SaveChanges();
    }

    private IQueryable<Drink> IncludeParameters(QueryParamDrink queryParamDrink, DbSet<Drink> context)
    {
        var query = context.AsQueryable();
        if (queryParamDrink.Tag != null) query = query.Include(o => o.Tag);
        if (queryParamDrink.Flavour != null) query = query.Include(o => o.Flavour);
        if (queryParamDrink.Recepie != null) query = query.Include(o => o.Recipe);
        return query;
    }
}