using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Domain
{
    public class Style
    {
        public int Id { get; set; }
        public bool HasIce { get; set; }

        [ForeignKey(nameof(Glass))]
        public int GlassId { get; set; }

        public Glass? Glass { get; set; }

        [ForeignKey(nameof(Garnish))]
        public int GarnishId { get; set; }

        public Garnish Garnish { get; set; }

        [ForeignKey(nameof(Color))]
        public int ColorId { get; set; }

        public Color Color { get; set; }

        [ForeignKey(nameof(Transparency))]
        public int TransparencyId { get; set; }

        public Transparency Transparency { get; set; }
    }
}