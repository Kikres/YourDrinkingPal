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
    List<Drink> GetAllPublished(QueryParamDrink queryParamDrink);
    Drink? GetById(int id, QueryParamDrink queryParamDrink);
    Drink? GetByImageId(int uploadedImageId, QueryParamDrink queryParamDrink);
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
    public List<Drink> GetAllPublished(QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).Where(o => o.IsPublished).ToList();

    public Drink? GetById(int id, QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).FirstOrDefault(o => o.Id == id);

    public Drink? GetByImageId(int uploadedImageId, QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).FirstOrDefault(o => o.UploadedImageId == uploadedImageId);

    public Drink? GetByUrlSlug(string urlSlug, QueryParamDrink queryParamDrink) => IncludeParameters(queryParamDrink, _context.Drink).FirstOrDefault(o => o.UrlSlug == urlSlug);

    //Manipulate
    public Drink Create(Drink drink)
    {
        try
        {
            _context.Drink.Add(drink);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return drink;
    }

    public int Delete(Drink drink)
    {
        try
        {
            _context.Drink.Remove(drink);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Delete(IEnumerable<Drink> drinks)
    {
        try
        {
            foreach (Drink drink in drinks) _context.Drink.Remove(drink);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(Drink drink)
    {
        try
        {
            _context.Drink.Update(drink);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<Drink> IncludeParameters(QueryParamDrink queryParamDrink, DbSet<Drink> context)
    {
        var query = context.AsQueryable();
        if (queryParamDrink.Image != null) query = query.Include(o => o.UploadedImage);
        if (queryParamDrink.Tag != null) query = query.Include(o => o.Tag);
        if (queryParamDrink.Flavour != null) query = query.Include(o => o.Flavour);
        if (queryParamDrink.Style != null) query = query.Include(o => o.Style);
        return query;
    }
}