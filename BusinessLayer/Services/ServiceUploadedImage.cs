using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.Domain;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceUploadedImage
{
    private readonly IMapper _mapper;
    private readonly IContext _context;

    public ServiceUploadedImage(IMapper mapper, IContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Fetch
    public List<UploadedImageDto> GetAll() => _mapper.Map<List<UploadedImage>, List<UploadedImageDto>>(_context.UploadedImage.GetAll());

    public List<UploadedImageDto> Take(int amount)
    {
        var images = _context.UploadedImage.GetAll().Take(amount).ToList();
        return _mapper.Map<List<UploadedImage>, List<UploadedImageDto>>(images);
    }

    public UploadedImageDto? GetById(int id)
    {
        var image = _context.UploadedImage.GetById(id);
        return _mapper.Map<UploadedImage?, UploadedImageDto>(image);
    }

    public UploadedImageDto? GetByName(string name)
    {
        var image = _context.UploadedImage.GetByName(name);
        return _mapper.Map<UploadedImage?, UploadedImageDto>(image);
    }

    public bool Exists(int id) => _context.UploadedImage.GetById(id) != null;
}