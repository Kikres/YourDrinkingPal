using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Domain
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Garnish { get; set; }

        [ForeignKey(nameof(Glass))]
        public int GlassId { get; set; }

        public Glass? Glass { get; set; }

        public List<Tool> Equipment { get; set; } = new List<Tool>();
        public List<Measurement> Measurements { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}