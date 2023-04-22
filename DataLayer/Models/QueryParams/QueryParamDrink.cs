namespace DataLayer.Models.QueryParams;

public class QueryParamDrink
{
    public bool? Tag { get; set; }
    public bool? Flavour { get; set; }
    public bool? Glass { get; set; }
    public bool? Equipment { get; set; }
    public bool? Recepie { get; set; }

    public QueryParamDrink(bool includeAll)
    {
        if (includeAll)
        {
            Tag = true;
            Flavour = true;
            Glass = true;
            Equipment = true;
            Recepie = true;
        }
    }
}