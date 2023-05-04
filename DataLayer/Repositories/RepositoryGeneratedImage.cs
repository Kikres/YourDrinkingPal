using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories;

public interface IRepositoryGeneratedImage
{
    GeneratedImage Create(GeneratedImage GeneratedImage);

    int Delete(GeneratedImage GeneratedImage);

    int Delete(IEnumerable<GeneratedImage> GeneratedImages);

    List<GeneratedImage> GetAll(QueryParamGeneratedImage queryParamGeneratedImage);

    GeneratedImage? GetByDrinkId(int id, QueryParamGeneratedImage queryParamGeneratedImage);

    GeneratedImage? GetById(int id, QueryParamGeneratedImage queryParamGeneratedImage);

    GeneratedImage? GetByOriginatingMessageId(string id, QueryParamGeneratedImage queryParamGeneratedImage);

    int Update(GeneratedImage GeneratedImage);
}

public class RepositoryGeneratedImage : IRepositoryGeneratedImage
{
    private readonly ApplicationDbContext _context;

    public RepositoryGeneratedImage(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<GeneratedImage> GetAll(QueryParamGeneratedImage queryParamGeneratedImage) => IncludeParameters(queryParamGeneratedImage, _context.GeneratedImage).ToList();

    public GeneratedImage? GetById(int id, QueryParamGeneratedImage queryParamGeneratedImage) => IncludeParameters(queryParamGeneratedImage, _context.GeneratedImage).FirstOrDefault(o => o.Id == id);

    public GeneratedImage? GetByOriginatingMessageId(string id, QueryParamGeneratedImage queryParamGeneratedImage) => IncludeParameters(queryParamGeneratedImage, _context.GeneratedImage).FirstOrDefault(o => o.OriginatingMessageId == id);

    public GeneratedImage? GetByDrinkId(int id, QueryParamGeneratedImage queryParamGeneratedImage) => IncludeParameters(queryParamGeneratedImage, _context.GeneratedImage).FirstOrDefault(o => o.DrinkId == id);

    //Manipulate
    public GeneratedImage Create(GeneratedImage GeneratedImage)
    {
        try
        {
            _context.GeneratedImage.Add(GeneratedImage);
            _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
        return GeneratedImage;
    }

    public int Delete(GeneratedImage GeneratedImage)
    {
        try
        {
            _context.GeneratedImage.Remove(GeneratedImage);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Delete(IEnumerable<GeneratedImage> GeneratedImages)
    {
        try
        {
            foreach (GeneratedImage GeneratedImage in GeneratedImages) _context.GeneratedImage.Remove(GeneratedImage);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    public int Update(GeneratedImage GeneratedImage)
    {
        try
        {
            _context.GeneratedImage.Update(GeneratedImage);
            return _context.SaveChanges();
        }
        catch (Exception e) { throw new DbUpdateException(e.Message); }
    }

    private IQueryable<GeneratedImage> IncludeParameters(QueryParamGeneratedImage queryParamGeneratedImage, DbSet<GeneratedImage> context)
    {
        var query = context.AsQueryable();
        if (queryParamGeneratedImage.Variations != null) query = query.Include(o => o.Variations);
        if (queryParamGeneratedImage.Drink != null) query = query.Include(o => o.Drink);
        return query;
    }
}