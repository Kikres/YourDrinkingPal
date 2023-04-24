namespace DataLayer.Models.QueryParams;

public class QueryParamTool
{
    public bool? Recipes { get; set; }

    public QueryParamTool(bool includeAll)
    {
        if (includeAll)
        {
            Recipes = true;
        }
    }
}