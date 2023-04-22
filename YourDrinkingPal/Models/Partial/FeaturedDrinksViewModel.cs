using BusinessLayer.Models.DTO;

namespace ApplicationLayer.Models.Partial
{
    public class FeaturedDrinksViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<DrinkDto> Drinks { get; set; }
    }
}