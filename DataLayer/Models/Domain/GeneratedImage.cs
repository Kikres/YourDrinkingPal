using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Domain
{
    public class GeneratedImage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string OriginatingMessageId { get; set; }
        public string? OriginalUrl { get; set; }
        public bool? IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DoneAt { get; set; }
        public List<UploadedImage> Variations { get; set; }

        [ForeignKey(nameof(Drink))]
        public int DrinkId { get; set; }

        public Drink? Drink { get; set; }
    }
}