namespace DataLayer.Models.QueryParams;

public class QueryParamRecipe
{
    public bool? Measurements { get; set; }
    public bool? Instructions { get; set; }
    public bool? Equipment { get; set; }

    public QueryParamRecipe(bool includeAll)
    {
        if (includeAll)
        {
            Measurements = true;
            Instructions = true;
            Equipment = true;
        }
    }
}