using InfoTrack.Assignment.Application.DTO.SearchEngineOptimizationDomain;

namespace InfoTrack.Assignment.Application.ServicesAbstraction.SearchEngineOptimization;

public interface ISeoService
{
    Task<ICollection<int>> FetchSearchStatistic(SearchRequestDTO searchRequestDTO);
}