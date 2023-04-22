namespace DataLayer.Models.Domain
{
    public class Measurement
    {
        public int Id { get; set; }
        public int IngridientId { get; set; }
        public Ingridient Ingridient { get; set; }
        public int UnitId { get; set; }
        public Unit? Unit { get; set; }
        public decimal? Amount { get; set; }
    }
}