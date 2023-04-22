using DataLayer.Models.Domain;

namespace DataLayer.Models.QueryParams;

public class QueryParamGlass
{
    public bool? Drinks { get; set; }

    public QueryParamGlass(bool includeAll)
    {
        if (includeAll)
        {
            Drinks = true;
        }
    }
}