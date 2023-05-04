using BusinessLayer.Models.DTO;

namespace ApplicationLayer.Models
{
    public class DrinkViewModel
    {
        public DrinkDto Drink { get; set; }
    }

    public class DrinkCreateViewModel
    {
        public DrinkCreateDto DrinkCreateDto { get; set; }
        public List<FlavourDto> Flavours { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<UnitDto> Units { get; set; }
        public List<GlassDto> Glasses { get; set; }
        public List<IngridientDto> Ingridients { get; set; }
        public List<GarnishDto> Garnishes { get; set; }
        public List<ColorDto> Colors { get; set; }
        public List<TransparencyDto> Transparencies { get; set; }
        public List<ToolDto> Equipment { get; set; }
    }

    public class DrinkPreviewViewModel
    {
        public DrinkDto Drink { get; set; }
        public GeneratedImageDto GeneratedImageDto { get; set; }
        public DrinkPublishDto DrinkPublishDto { get; set; }
    }
}