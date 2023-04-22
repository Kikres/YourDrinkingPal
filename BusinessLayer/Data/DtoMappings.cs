using AutoMapper;
using BusinessLayer.Models.DTO;
using DataLayer.Models.Domain;

namespace Business_Layer.Data;

public class DtoMappings : Profile
{
    public DtoMappings()
    {
        CreateMap<Drink, DrinkDto>().ReverseMap();

        CreateMap<Flavour, FlavourDto>().ReverseMap();

        CreateMap<Glass, GlassDto>().ReverseMap();

        CreateMap<Ingridient, IngridientDto>().ReverseMap();

        CreateMap<Instruction, InstructionDto>().ReverseMap();

        CreateMap<Measurement, MeasurementDto>().ReverseMap();

        CreateMap<Recipe, RecipeDto>().ReverseMap();

        CreateMap<Tag, TagDto>().ReverseMap();

        CreateMap<Tool, ToolDto>().ReverseMap();

        CreateMap<Unit, UnitDto>().ReverseMap();

        //CreateMap<Client, ClientUpdateDto>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}