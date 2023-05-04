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
        public bool IsPublished { get; set; }

        [ForeignKey(nameof(UploadedImage))]
        public int? UploadedImageId { get; set; }

        public UploadedImage? UploadedImage { get; set; }

        [ForeignKey(nameof(Tag))]
        public int TagId { get; set; }

        public Tag? Tag { get; set; }

        [ForeignKey(nameof(Flavour))]
        public int FlavourId { get; set; }

        public Flavour? Flavour { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        public Recipe? Recipe { get; set; }

        [ForeignKey(nameof(Style))]
        public int StyleId { get; set; }

        public Style? Style { get; set; }

        [ForeignKey(nameof(Creator))]
        public string? CreatorId { get; set; }

        public ApplicationUser? Creator { get; set; }
    }
}