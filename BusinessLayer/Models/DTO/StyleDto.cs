using DataLayer.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.Models.DTO
{
    public class StyleDto
    {
        public int Id { get; set; }
        public bool HasIce { get; set; }
        public int GlassId { get; set; }
        public GlassDto? Glass { get; set; }
        public int GarnishId { get; set; }
        public GarnishDto? Garnish { get; set; }
        public int ColorId { get; set; }
        public ColorDto? Color { get; set; }
        public int TransparencyId { get; set; }
        public TransparencyDto? Transparency { get; set; }
    }
}