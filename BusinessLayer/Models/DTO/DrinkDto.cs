using DataLayer.Models.Domain;
using System.Collections.ObjectModel;

namespace BusinessLayer.Models.DTO
{
    public class DrinkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public int? UploadedImageId { get; set; }
        public UploadedImageDto? UploadedImage { get; set; }
        public int TagId { get; set; }
        public TagDto? Tag { get; set; }
        public int FlavourId { get; set; }
        public FlavourDto? Flavour { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto? Recipe { get; set; }
        public int StyleId { get; set; }
        public StyleDto? Style { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser? Creator { get; set; }
    }

    public class DrinkCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TagId { get; set; }
        public int FlavourId { get; set; }
        public RecipeDto Recipe { get; set; }
        public StyleDto Style { get; set; }
        public ApplicationUser? Creator { get; set; }
    }

    public class DrinkPublishDto
    {
        public int DrinkId { get; set; }
        public int ImageId { get; set; }
    }
}