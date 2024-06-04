namespace InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain.Constants;

public enum SearchEngine
{
    // We use bigger values that allows us to insert new Engines in the future without disrupting the existing order. 
    Bing = 10,
    Google = 20,
    Yahoo = 30
}