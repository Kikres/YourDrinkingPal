namespace DataLayer.Models.QueryParams;

public class QueryParamTool
{
    public bool? Drinks { get; set; }

    public QueryParamTool(bool includeAll)
    {
        if (includeAll)
        {
            Drinks = true;
        }
    }
}