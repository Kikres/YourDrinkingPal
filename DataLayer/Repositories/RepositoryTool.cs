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
        _context.Tool.Add(tool);
        _context.SaveChanges();
        return tool;
    }

    public int Delete(Tool tool)
    {
        _context.Tool.Remove(tool);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Tool> tools)
    {
        foreach (Tool tool in tools) _context.Tool.Remove(tool);
        return _context.SaveChanges();
    }

    public int Update(Tool tool)
    {
        _context.Tool.Update(tool);
        return _context.SaveChanges();
    }

    private IQueryable<Tool> IncludeParameters(QueryParamTool queryParamTool, DbSet<Tool> context)
    {
        var query = context.AsQueryable();
        if (queryParamTool.Drinks != null) query = query.Include(o => o.Drinks);
        return query;
    }
}