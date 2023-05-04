using DataLayer.Models.Domain;

namespace DataLayer.Models.QueryParams;

public class QueryParamGarnish
{
    public bool? Styles { get; set; }

    public QueryParamGarnish(bool includeAll)
    {
        if (includeAll)
        {
            Styles = true;
        }
    }
}