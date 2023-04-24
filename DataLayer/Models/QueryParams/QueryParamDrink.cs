namespace DataLayer.Models.QueryParams;

public class QueryParamDrink
{
    public bool? Tag { get; set; }
    public bool? Flavour { get; set; }
    public bool? Recepie { get; set; }

    public QueryParamDrink(bool includeAll)
    {
        if (includeAll)
        {
            Tag = true;
            Flavour = true;
            Recepie = true;
        }
    }
}