namespace DataLayer.Models.QueryParams;

public class QueryParamStyle
{
    public bool? Glass { get; set; }
    public bool? Garnish { get; set; }
    public bool? Color { get; set; }
    public bool? Transparency { get; set; }

    public QueryParamStyle(bool includeAll)
    {
        if (includeAll)
        {
            Glass = true;
            Garnish = true;
            Color = true;
            Transparency = true;
        }
    }
}