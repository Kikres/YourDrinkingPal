using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Domain
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public Tag Tag { get; set; }

        [ForeignKey(nameof(Flavour))]
        public int FlavourId { get; set; }

        public Flavour Flavour { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}