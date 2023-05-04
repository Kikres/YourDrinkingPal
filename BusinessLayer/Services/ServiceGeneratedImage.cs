using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Repositories;
using DataLayer.Models.QueryParams;
using DataLayer.Models.Domain;
using System.Net;
using System.Drawing;
using BusinessLayer.Services.CommonServices;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using DataLayer;

namespace BusinessLayer.Services;

public class ServiceGeneratedImage
{
    private readonly IMapper _mapper;
    private readonly IContext _context;
    private readonly CommonServiceComputerVision _commonServiceComputerVision;
    private readonly CommonServiceMidjourney _commonServiceMidjourney;
    private readonly CommonServiceBlobStorage _commonServiceBlobStorage;

    public ServiceGeneratedImage(IMapper mapper, CommonServiceBlobStorage commonServiceBlobStorage, CommonServiceComputerVision commonServiceComputerVision, CommonServiceMidjourney commonServiceMidjourney, IContext context)
    {
        _mapper = mapper;
        _commonServiceBlobStorage = commonServiceBlobStorage;
        _commonServiceComputerVision = commonServiceComputerVision;
        _commonServiceMidjourney = commonServiceMidjourney;
        _context = context;
    }

    public async Task<GeneratedImageDto> ProcessImage(MidjourneyDto dto)
    {
        var generatedImage = _context.GeneratedImage.GetByOriginatingMessageId(dto.OriginatingMessageId, new QueryParamGeneratedImage(true));
        if (generatedImage == null) return null;

        generatedImage.OriginalUrl = dto.ImageUrl;
        if (generatedImage.Variations == null) generatedImage.Variations = new List<UploadedImage>();

        WebClient client = new WebClient();
        Stream stream = client.OpenRead(dto.ImageUrl);

        Bitmap originalBitmap = new Bitmap(stream);

        int width = originalBitmap.Width / 2;
        int height = originalBitmap.Height / 2;

        Bitmap topLeftBitmap = originalBitmap.Clone(new Rectangle(0, 0, width, height), originalBitmap.PixelFormat);
        Bitmap topRightBitmap = originalBitmap.Clone(new Rectangle(width, 0, width, height), originalBitmap.PixelFormat);
        Bitmap bottomLeftBitmap = originalBitmap.Clone(new Rectangle(0, height, width, height), originalBitmap.PixelFormat);
        Bitmap bottomRightBitmap = originalBitmap.Clone(new Rectangle(width, height, width, height), originalBitmap.PixelFormat);

        var variations = new List<UploadedImage>()
        {
            _commonServiceBlobStorage.UploadImage($"{generatedImage.OriginatingMessageId}-top-left.png", topLeftBitmap),
            _commonServiceBlobStorage.UploadImage($"{generatedImage.OriginatingMessageId}-top-right.png", topRightBitmap),
            _commonServiceBlobStorage.UploadImage($"{generatedImage.OriginatingMessageId}-bottom-left.png", bottomLeftBitmap),
            _commonServiceBlobStorage.UploadImage($"{generatedImage.OriginatingMessageId}-bottom-right.png", bottomRightBitmap)
         };

        //Inspect
        var style = _context.Style.GetById(generatedImage.Drink.StyleId, new QueryParamStyle(true));
        var countInvalid = 0;
        foreach (var variation in variations)
        {
            //Guard
            if (generatedImage.Variations.Count == 4) break;

            var analysis = await _commonServiceComputerVision.InspectImage(variation.ImageUrl);

            //var containsGlass = false;
            foreach (var obj in analysis.Objects)
            {
                if (obj.ObjectProperty.Contains("glass"))
                {
                    //Save identified glass
                    Bitmap analysisBitmap = originalBitmap.Clone(new Rectangle(obj.Rectangle.X, obj.Rectangle.Y, obj.Rectangle.W, obj.Rectangle.H), originalBitmap.PixelFormat);
                    var upload = _commonServiceBlobStorage.UploadImage($"{variation.Name}-{obj.ObjectProperty}.png", analysisBitmap);

                    //Example of color analysis
                    //var analysisGlass = await _commonServiceComputerVision.InspectImage(upload.ImageUrl);
                    //if (analysisGlass.Color.DominantColors.Any(o => o.ToLower().Contains(style.Color.Prompt.ToLower())))
                    //{
                    //    containsColor = true;
                    //}

                    //Keep
                    //_commonServiceBlobStorage.RemoveImage(upload.Name);
                    //containsGlass = true;
                }
            }

            //if (containsGlass)
            //{
            _context.UploadedImage.Create(variation);
            generatedImage.Variations.Add(variation);
            //}
            //else
            //{
            //    countInvalid++;
            //    _commonServiceBlobStorage.RemoveImage(variation.Name);
            //}
        }

        var requestNew = countInvalid > 0 && generatedImage.Variations.Count != 4;
        if (requestNew)
        {
            var generationResponseDto = await _commonServiceMidjourney.SendDrinkImageGenerationRequest(style);
            generatedImage.IsDone = false;
            generatedImage.OriginatingMessageId = generationResponseDto.MessageId;
        }
        else
        {
            generatedImage.IsDone = true;
            generatedImage.DoneAt = DateTime.Now;
        }

        _context.GeneratedImage.Update(generatedImage);

        return _mapper.Map<GeneratedImage, GeneratedImageDto>(generatedImage);
    }

    //Fetch
    public GeneratedImageDto GetByOriginatingMessageId(string id) => _mapper.Map<GeneratedImage, GeneratedImageDto>(_context.GeneratedImage.GetByOriginatingMessageId(id, new QueryParamGeneratedImage(true)));

    public GeneratedImageDto GetByDrinkId(int id) => _mapper.Map<GeneratedImage, GeneratedImageDto>(_context.GeneratedImage.GetByDrinkId(id, new QueryParamGeneratedImage(true)));

    public List<GeneratedImageDto> GetAll() => _mapper.Map<List<GeneratedImage>, List<GeneratedImageDto>>(_context.GeneratedImage.GetAll(new QueryParamGeneratedImage(false)));

    public List<GeneratedImageDto> Take(int amount)
    {
        var generatedImage = _context.GeneratedImage.GetAll(new QueryParamGeneratedImage(true)).Take(amount).ToList();
        return _mapper.Map<List<GeneratedImage>, List<GeneratedImageDto>>(generatedImage);
    }

    public GeneratedImageDto GetById(int id)
    {
        var generatedImage = _context.GeneratedImage.GetById(id, new QueryParamGeneratedImage(true));
        return _mapper.Map<GeneratedImage, GeneratedImageDto>(generatedImage);
    }
}