using DataLayer.Models.Domain;

namespace DataLayer.Models.QueryParams;

public class QueryParamGlass
{
    public bool? Recipes { get; set; }

    public QueryParamGlass(bool includeAll)
    {
        if (includeAll)
        {
            Recipes = true;
        }
    }
}