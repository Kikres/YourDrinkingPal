using DataLayer.Models.Domain;

namespace DataLayer.Models.QueryParams;

public class QueryParamGlass
{
    public bool? Styles { get; set; }

    public QueryParamGlass(bool includeAll)
    {
        if (includeAll)
        {
            Styles = true;
        }
    }
}