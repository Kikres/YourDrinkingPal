using System.Collections.ObjectModel;

namespace DataLayer.Models.Domain
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
        public int FlavourId { get; set; }
        public Flavour? Flavour { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}