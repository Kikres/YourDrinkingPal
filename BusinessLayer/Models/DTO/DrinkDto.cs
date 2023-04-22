using System.Collections.ObjectModel;

namespace BusinessLayer.Models.DTO
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public TagDto? Tag { get; set; }
        public FlavourDto? Flavour { get; set; }
        public GlassDto? Glass { get; set; }
        public List<ToolDto> Equipment { get; set; } = new List<ToolDto>();
        public RecipeDto Recepie { get; set; }
    }
}