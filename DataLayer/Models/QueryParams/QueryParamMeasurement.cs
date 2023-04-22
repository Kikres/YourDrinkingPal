namespace DataLayer.Models.QueryParams;

public class QueryParamMeasurement
{
    public bool? Ingridient { get; set; }
    public bool? Unit { get; set; }

    public QueryParamMeasurement(bool includeAll)
    {
        if (includeAll)
        {
            Ingridient = true;
            Unit = true;
        }
    }
}