namespace DataLayer.Models.Domain
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
    }
}