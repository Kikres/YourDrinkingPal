namespace DataLayer.Models.QueryParams;

public class QueryParamTag
{
    public bool? Drinks { get; set; }

    public QueryParamTag(bool includeAll)
    {
        if (includeAll)
        {
            Drinks = true;
        }
    }
}