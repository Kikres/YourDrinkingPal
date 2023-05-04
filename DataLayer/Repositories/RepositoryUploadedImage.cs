using DataLayer.Data;
using DataLayer.Models.Domain;

namespace DataLayer.Repositories;

public interface IRepositoryUploadedImage
{
    UploadedImage Create(UploadedImage UploadedImage);

    int Delete(IEnumerable<UploadedImage> UploadedImages);

    int Delete(UploadedImage UploadedImage);

    List<UploadedImage> GetAll();

    UploadedImage? GetById(int id);

    UploadedImage? GetByName(string name);

    int Update(UploadedImage UploadedImage);
}

public class RepositoryUploadedImage : IRepositoryUploadedImage
{
    private readonly ApplicationDbContext _context;

    public RepositoryUploadedImage(ApplicationDbContext context)
    {
        _context = context;
    }

    //Fetch
    public List<UploadedImage> GetAll() => _context.UploadedImage.ToList();

    public UploadedImage? GetById(int id) => _context.UploadedImage.FirstOrDefault(o => o.Id == id);

    public UploadedImage? GetByName(string name) => _context.UploadedImage.FirstOrDefault(o => o.Name == name);

    //Manipulate
    public UploadedImage Create(UploadedImage UploadedImage)
    {
        _context.UploadedImage.Add(UploadedImage);
        _context.SaveChanges();
        return UploadedImage;
    }

    public int Delete(UploadedImage UploadedImage)
    {
        _context.UploadedImage.Remove(UploadedImage);
        return _context.SaveChanges();
    }

    public int Delete(IEnumerable<UploadedImage> UploadedImages)
    {
        foreach (UploadedImage UploadedImage in UploadedImages) _context.UploadedImage.Remove(UploadedImage);
        return _context.SaveChanges();
    }

    public int Update(UploadedImage UploadedImage)
    {
        _context.UploadedImage.Attach(UploadedImage);
        _context.UploadedImage.Update(UploadedImage);
        return _context.SaveChanges();
    }
}