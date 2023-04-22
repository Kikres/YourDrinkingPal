namespace DataLayer.Models.QueryParams;

public class QueryParamFlavour
{
    public bool? Drinks { get; set; }

    public QueryParamFlavour(bool includeAll)
    {
        if (includeAll)
        {
            Drinks = true;
        }
    }
}