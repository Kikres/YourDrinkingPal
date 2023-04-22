using System.Collections.ObjectModel;

namespace DataLayer.Models.Domain
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Garnish { get; set; }
        public int GlassId { get; set; }
        public Glass? Glass { get; set; }
        public List<Tool> Equipment { get; set; } = new List<Tool>();
        public List<Measurement> Measurements { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}