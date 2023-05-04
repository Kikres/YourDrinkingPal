using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Domain
{
    public class Recipe
    {
        public int Id { get; set; }
        public List<Tool> Equipment { get; set; }
        public List<Measurement> Measurements { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}