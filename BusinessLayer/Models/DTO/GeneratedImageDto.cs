using DataLayer.Models.Domain;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models.DTO
{
    public class GeneratedImageDto
    {
        public int Id { get; set; }
        public string OriginatingMessageId { get; set; }
        public string OriginalUrl { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DoneAt { get; set; }
        public List<UploadedImageDto> Variations { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
    }

    public class GeneratedImageCreateDto
    {
        public string Content { get; set; }
        public string OriginatingMessageId { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DoneAt { get; set; }
    }
}