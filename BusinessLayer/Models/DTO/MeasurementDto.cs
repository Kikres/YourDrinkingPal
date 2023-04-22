namespace BusinessLayer.Models.DTO
{
    public class MeasurementDto
    {
        public int Id { get; set; }
        public IngridientDto Ingridient { get; set; }
        public UnitDto? Unit { get; set; }
        public decimal? Amount { get; set; }
    }
}