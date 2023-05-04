namespace DataLayer.Models.Domain
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}