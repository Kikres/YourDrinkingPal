using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Models.Domain;

namespace BusinessLayer.Data;

public class DtoMappings : Profile
{
    public DtoMappings()
    {
        CreateMap<Color, ColorDto>().ReverseMap();

        CreateMap<Drink, DrinkDto>().ReverseMap();
        CreateMap<Drink, DrinkCreateDto>().ReverseMap();
        CreateMap<Drink, DrinkPublishDto>().ReverseMap();

        CreateMap<Flavour, FlavourDto>().ReverseMap();

        CreateMap<Garnish, GarnishDto>().ReverseMap();

        CreateMap<Glass, GlassDto>().ReverseMap();

        CreateMap<UploadedImage, UploadedImageDto>().ReverseMap();

        CreateMap<GeneratedImage, GeneratedImageDto>().ReverseMap();
        CreateMap<GeneratedImage, GeneratedImageCreateDto>().ReverseMap();

        CreateMap<Ingridient, IngridientDto>().ReverseMap();

        CreateMap<Instruction, InstructionDto>().ReverseMap();

        CreateMap<Measurement, MeasurementDto>().ReverseMap();

        CreateMap<Recipe, RecipeDto>().ReverseMap();

        CreateMap<Style, StyleDto>().ReverseMap();

        CreateMap<Tag, TagDto>().ReverseMap();

        CreateMap<Tool, ToolDto>().ReverseMap();

        CreateMap<Transparency, TransparencyDto>().ReverseMap();

        CreateMap<Unit, UnitDto>().ReverseMap();

        //CreateMap<Client, ClientUpdateDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}