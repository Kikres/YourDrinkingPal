namespace DataLayer.Models.Domain
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prompt { get; set; }
        public string HEX { get; set; }
        public List<Style> Styles { get; set; } = new List<Style>();
    }
}