using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.Domain;

namespace BusinessLayer.Services;

public class ServiceUploadedImage
{
    private readonly IMapper _mapper;
    private readonly IRepositoryUploadedImage _repositoryUploadedImage;

    public ServiceUploadedImage(IMapper mapper, IRepositoryUploadedImage repositoryUploadedImage)
    {
        _mapper = mapper;
        _repositoryUploadedImage = repositoryUploadedImage;
    }

    //Fetch
    public List<UploadedImageDto> GetAll() => _mapper.Map<List<UploadedImage>, List<UploadedImageDto>>(_repositoryUploadedImage.GetAll());

    public List<UploadedImageDto> Take(int amount)
    {
        var images = _repositoryUploadedImage.GetAll().Take(amount).ToList();
        return _mapper.Map<List<UploadedImage>, List<UploadedImageDto>>(images);
    }

    public UploadedImageDto? GetById(int id)
    {
        var image = _repositoryUploadedImage.GetById(id);
        return _mapper.Map<UploadedImage?, UploadedImageDto>(image);
    }

    public UploadedImageDto? GetByName(string name)
    {
        var image = _repositoryUploadedImage.GetByName(name);
        return _mapper.Map<UploadedImage?, UploadedImageDto>(image);
    }

    public bool Exists(int id) => _repositoryUploadedImage.GetById(id) != null;
}