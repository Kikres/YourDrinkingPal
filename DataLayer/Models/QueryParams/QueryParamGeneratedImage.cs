namespace DataLayer.Models.QueryParams;

public class QueryParamGeneratedImage
{
    public bool? Variations { get; set; }
    public bool? Drink { get; set; }

    public QueryParamGeneratedImage(bool includeAll)
    {
        if (includeAll)
        {
            Variations = true;
            Drink = true;
        }
    }
}