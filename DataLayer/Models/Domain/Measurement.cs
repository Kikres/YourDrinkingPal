using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Domain
{
    public class Measurement
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Ingridient))]
        public int IngridientId { get; set; }

        public Ingridient Ingridient { get; set; }

        [ForeignKey(nameof(Unit))]
        public int UnitId { get; set; }

        public Unit Unit { get; set; }
        public decimal? Amount { get; set; }
    }
}