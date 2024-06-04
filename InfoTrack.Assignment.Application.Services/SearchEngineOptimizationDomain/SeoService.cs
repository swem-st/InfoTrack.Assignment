using InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain;
using InfoTrack.Assignment.Application.DTO.SearchEngineOptimizationDomain;
using InfoTrack.Assignment.Application.ServicesAbstraction.SearchEngineOptimization;
using InfoTrack.Assignment.Core.Exceptions;

namespace InfoTrack.Assignment.Application.Services.SearchEngineOptimizationDomain;

public class SeoService : ISeoService
{
    private readonly HttpClient _httpClient;

    public SeoService(HttpClient httpClient )
    {
        _httpClient = httpClient;
    }

    public async Task<ICollection<int>> FetchSearchStatistic(SearchRequestDTO searchRequestDTO)
    {
        // The SearchEngineOptimization model currently handles both the creation of the search query URL and the processing of the search results.
        // This decision was made to keep the domain logic encapsulated within a single model, in line with Domain-Driven Design principles.
        // However, as the complexity of the business logic grows, it may be beneficial to separate these responsibilities into two distinct models (SearchQueryUrlBuilder/SearchResultProcessor).
        var searchEngineOptimization = SearchEngineOptimization.CreateNew(searchRequestDTO.SearchEngine,  searchRequestDTO.Url, searchRequestDTO.SearchTerm);

        try 
        {
            var searchResultHtmlAsString = await _httpClient.GetStringAsync(searchEngineOptimization.SearchQueryUrl);

            //A potential memory optimization(have to calculate memory usage...) for the future could be to use GetStreamAsync instead.
            var urlPositions = searchEngineOptimization.FindUrlPositions(searchResultHtmlAsString);

            return urlPositions;
        }
        catch (Exception ex)
        {
            //Add Logging for genuine exception.
            throw new SearchException($"An error occurred while attempting to fetch search statistic with the search term {searchRequestDTO.SearchTerm}.", searchRequestDTO.SearchEngine.ToString(), searchRequestDTO.Url, searchRequestDTO.SearchTerm);
        }
      
    }
}