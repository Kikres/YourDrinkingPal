namespace DataLayer.Models.QueryParams;

public class QueryParamIngridient
{
    public bool? Measurements { get; set; }

    public QueryParamIngridient(bool includeAll)
    {
        if (includeAll)
        {
            Measurements = true;
        }
    }
}