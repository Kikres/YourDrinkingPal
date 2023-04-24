using System.Collections.ObjectModel;

namespace BusinessLayer.Models.DTO
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public int? TagId { get; set; }
        public TagDto? Tag { get; set; } = new TagDto();
        public int? FlavourId { get; set; }
        public FlavourDto? Flavour { get; set; } = new FlavourDto();
        public int? RecipeId { get; set; }
        public RecipeDto Recipe { get; set; } = new RecipeDto();
        public ICollection<MeasurementDto> Measurements { get; set; } = new List<MeasurementDto>();
    }
}