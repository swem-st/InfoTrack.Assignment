using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;
using InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain.Constants;

namespace InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain
{
    public class SearchEngineOptimization
    {
        //Request data
        private SearchEngine SearchEngine { get; init; }
        private string SearchUrl { get; init; }
        private string SearchTerm { get; init; }


        public string SearchQueryUrl { get; private set; }
        private string SearchEngineUrlsRegex { get; set; }

        public static SearchEngineOptimization CreateNew(SearchEngine searchEngine, string url, string searchTerm)
        {
            var result =  new SearchEngineOptimization
            {
                SearchEngine = searchEngine,
                SearchUrl = url,
                SearchTerm = searchTerm
            };

            Validate(result);

            result.CreateSearchQueryUrl();
            result.CreateSearchEngineUrlsRegex();

            return result;
        }

        public List<int> FindUrlPositions(string htmlContent)
        {
            var urlPositions = new List<int>();

            var matches = Regex.Matches(htmlContent, SearchEngineUrlsRegex);

            for (var index = 0; index < matches.Count; index++)
            {
                var match = matches[index];
                if (match.Groups[0].Value.Contains(SearchUrl))
                {
                    urlPositions.Add(index+1);
                }
            }

            return urlPositions;
        }

        private static void Validate(SearchEngineOptimization searchEngineOptimization)
        {
            var defaultErrorMessage = $"Failed to create {typeof(SearchEngineOptimization)}.";

            if (!Enum.IsDefined(typeof(SearchEngine), searchEngineOptimization.SearchEngine))
            {
                throw new ValidationException($"{defaultErrorMessage}. The SearchEngine must have a valid value.");
            }

            if (string.IsNullOrEmpty(searchEngineOptimization.SearchUrl) || !IsValidUrl(searchEngineOptimization.SearchUrl))
            {
                throw new ValidationException($"{defaultErrorMessage} have a valid value.");
            }

            if (string.IsNullOrEmpty(searchEngineOptimization.SearchTerm))
            {
                throw new ValidationException($"{defaultErrorMessage}. The SearchTerm must not be empty.");
            }
        }

        private static bool IsValidUrl(string url)
        {
            // Basic URL validation
            var regex = new Regex(@"^(https?://)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}(/.*)?$");
            return regex.IsMatch(url);
        }

        private void CreateSearchQueryUrl()
        {
            const int resultCount = 100;

            var searchQueryUrl =  SearchEngine switch
            {
                SearchEngine.Google => $"https://www.google.co.uk/search?q={HttpUtility.UrlEncode(SearchTerm)}&num={resultCount}",
                SearchEngine.Bing => $"https://www.bing.com/search?q={HttpUtility.UrlEncode(SearchTerm)}&count={resultCount}",
                SearchEngine.Yahoo => $"https://search.yahoo.com/search?p={HttpUtility.UrlEncode(SearchTerm)}&n={resultCount}",
                _ => throw new InvalidCastException($"Failed to create Search Query Url.")
            };

            SearchQueryUrl = searchQueryUrl;
        }

        private void CreateSearchEngineUrlsRegex()
        {
            var searchEngineUrlsRegex =  SearchEngine switch
            {
                SearchEngine.Bing => SearchEngineRegex.Bing,
                SearchEngine.Google => SearchEngineRegex.Google,
                SearchEngine.Yahoo => SearchEngineRegex.Yahoo,
                _ => throw new InvalidCastException("Failed to create SearchEngineUrlsRegex.")
            };

            SearchEngineUrlsRegex = searchEngineUrlsRegex;
        }
    }
}