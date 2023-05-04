namespace DataLayer.Models.QueryParams;

public class QueryParamColor
{
    public bool? Styles { get; set; }

    public QueryParamColor(bool includeAll)
    {
        if (includeAll)
        {
            Styles = true;
        }
    }
}