using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryStyle
{
    Style Create(Style style);

    int Delete(Style style);

    int Delete(IEnumerable<Style> styles);

    List<Style> GetAll(QueryParamStyle queryParamStyle);

    Style? GetById(int id, QueryParamStyle queryParamStyle);

    int Update(Style style);
}

public class RepositoryStyle : IRepositoryStyle
{
    private readonly ApplicationDbContext _context;

    public RepositoryStyle(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Style> GetAll(QueryParamStyle queryParamStyle) => IncludeParameters(queryParamStyle, _context.Style).ToList();

    public Style? GetById(int id, QueryParamStyle queryParamStyle) => IncludeParameters(queryParamStyle, _context.Style).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Style Create(Style style)
    {
        try
        {
            _context.Style.Add(style);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return style;
    }

    public int Delete(Style style)
    {
        try
        {
            _context.Style.Remove(style);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Delete(IEnumerable<Style> styles)
    {
        try
        {
            foreach (Style style in styles) _context.Style.Remove(style);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(Style style)
    {
        try
        {
            _context.Style.Update(style);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<Style> IncludeParameters(QueryParamStyle queryParamStyle, DbSet<Style> context)
    {
        var query = context.AsQueryable();
        if (queryParamStyle.Glass != null) query = query.Include(o => o.Glass);
        if (queryParamStyle.Garnish != null) query = query.Include(o => o.Garnish);
        if (queryParamStyle.Color != null) query = query.Include(o => o.Color);
        if (queryParamStyle.Transparency != null) query = query.Include(o => o.Transparency);
        return query;
    }
}