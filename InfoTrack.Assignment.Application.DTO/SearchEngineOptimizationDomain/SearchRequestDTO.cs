using InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain.Constants;

namespace InfoTrack.Assignment.Application.DTO.SearchEngineOptimizationDomain;

public class SearchRequestDTO
{
    public SearchEngine SearchEngine { get; set; }
    public string Url { get; set; }
    public string SearchTerm { get; set; }
}