namespace DataLayer.Models.Domain
{
    public class Flavour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Drink> Drinks { get; set; } = new List<Drink>();
    }
}