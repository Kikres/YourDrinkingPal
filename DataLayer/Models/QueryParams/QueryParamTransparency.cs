namespace DataLayer.Models.QueryParams;

public class QueryParamTransparency
{
    public bool? Styles { get; set; }

    public QueryParamTransparency(bool includeAll)
    {
        if (includeAll)
        {
            Styles = true;
        }
    }
}