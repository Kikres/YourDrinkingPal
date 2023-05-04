namespace DataLayer.Models.QueryParams;

public class QueryParamDrink
{
    public bool? Image { get; set; }
    public bool? Tag { get; set; }
    public bool? Flavour { get; set; }
    public bool? Recepie { get; set; }
    public bool? Style { get; set; }
    public bool? Creator { get; set; }

    public QueryParamDrink(bool includeAll)
    {
        if (includeAll)
        {
            Image = true;
            Tag = true;
            Flavour = true;
            Recepie = true;
            Style = true;
            Creator = true;
        }
    }
}