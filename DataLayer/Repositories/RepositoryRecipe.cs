using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryRecipe
{
    Recipe Create(Recipe recipe);

    int Delete(IEnumerable<Recipe> recipes);

    int Delete(Recipe recipe);

    List<Recipe> GetAll(QueryParamRecipe queryParamRecipe);

    Recipe GetById(int id, QueryParamRecipe queryParamRecipe);

    int Update(Recipe recipe);
}

public class RepositoryRecipe : IRepositoryRecipe
{
    private readonly ApplicationDbContext _context;

    public RepositoryRecipe(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<Recipe> GetAll(QueryParamRecipe queryParamRecipe) => IncludeParameters(queryParamRecipe, _context.Recipe).ToList();

    public Recipe GetById(int id, QueryParamRecipe queryParamRecipe) => IncludeParameters(queryParamRecipe, _context.Recipe).First(o => o.Id == id);

    //Manipulate
    public Recipe Create(Recipe recipe)
    {
        _context.Recipe.Add(recipe);
        _context.SaveChanges();
        return recipe;
    }

    public int Delete(Recipe recipe)
    {
        _context.Recipe.Remove(recipe);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<Recipe> recipes)
    {
        foreach (Recipe recipe in recipes) _context.Recipe.Remove(recipe);
        return _context.SaveChanges();
    }

    public int Update(Recipe recipe)
    {
        _context.Recipe.Update(recipe);
        return _context.SaveChanges();
    }

    private IQueryable<Recipe> IncludeParameters(QueryParamRecipe queryParamRecipe, DbSet<Recipe> context)
    {
        var query = context.AsQueryable();
        if (queryParamRecipe.Measurements != null) query = query.Include(o => o.Measurements);
        if (queryParamRecipe.Instructions != null) query = query.Include(o => o.Instructions);
        if (queryParamRecipe.Equipment != null) query = query.Include(o => o.Equipment);
        return query;
    }
}