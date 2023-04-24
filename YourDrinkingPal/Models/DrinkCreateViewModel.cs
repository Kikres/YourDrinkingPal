using BusinessLayer.Models.DTO;

namespace ApplicationLayer.Models
{
    public class DrinkCreateViewModel
    {
        public DrinkDto Drink { get; set; }
        public IEnumerable<FlavourDto> Flavours { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<UnitDto> Units { get; set; }
        public IEnumerable<GlassDto> Glasses { get; set; }
        public IEnumerable<IngridientDto> Ingridients { get; set; }
        public IEnumerable<string> Garnishes { get; set; }
    }
}