namespace DataLayer.Models.Domain
{
    public class UploadedImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? AltText { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? Uploaded { get; set; }
    }
}