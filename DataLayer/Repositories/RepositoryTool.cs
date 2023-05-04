using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryTool
{
    Tool Create(Tool tool);

    int Delete(IEnumerable<Tool> tools);

    int Delete(Tool tool);

    List<Tool> GetAll(QueryParamTool queryParamTool);

    Tool? GetById(int id, QueryParamTool queryParamTool);

    int Update(Tool tool);
}

public class RepositoryTool : IRepositoryTool
{
    private readonly ApplicationDbContext _context;

    public RepositoryTool(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Tool> GetAll(QueryParamTool queryParamTool) => IncludeParameters(queryParamTool, _context.Tool).ToList();

    public Tool? GetById(int id, QueryParamTool queryParamTool) => IncludeParameters(queryParamTool, _context.Tool).FirstOrDefault(o => o.Id == id);

    //Manipulate
    public Tool Create(Tool tool)
    {
        try
        {
            _context.Tool.Add(tool);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return tool;
    }

    public int Delete(Tool tool)
    {
        try
        {
            _context.Tool.Remove(tool);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Delete(IEnumerable<Tool> tools)
    {
        try
        {
            foreach (Tool tool in tools) _context.Tool.Remove(tool);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(Tool tool)
    {
        try
        {
            _context.Tool.Update(tool);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<Tool> IncludeParameters(QueryParamTool queryParamTool, DbSet<Tool> context)
    {
        var query = context.AsQueryable();
        if (queryParamTool.Recipes != null) query = query.Include(o => o.Recipes);
        return query;
    }
}