namespace DataLayer.Models.QueryParams;

public class QueryParamUnit
{
    public bool? Measurements { get; set; }

    public QueryParamUnit(bool includeAll)
    {
        if (includeAll)
        {
            Measurements = true;
        }
    }
}