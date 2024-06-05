using InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain;
using InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Tests.Application.DomainModels
{
    public class SearchEngineOptimizationTests
    {
        [Fact]
        public void CreateNew_ValidParameters_CreatesInstance()
        {
            var seo = SearchEngineOptimization.CreateNew(SearchEngine.Google, "https://www.google.com", "test");

            Assert.NotNull(seo);
            Assert.Equal("https://www.google.co.uk/search?q=test&num=100", seo.SearchQueryUrl);
        }

        [Fact]
        public void CreateNew_InvalidSearchEngine_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => SearchEngineOptimization.CreateNew((SearchEngine)999, "https://www.google.com", "test"));
        }

        [Fact]
        public void CreateNew_InvalidUrl_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => SearchEngineOptimization.CreateNew(SearchEngine.Google, "invalid_url", "test"));
        }

        [Fact]
        public void CreateNew_EmptySearchTerm_ThrowsValidationException()
        {
            Assert.Throws<ValidationException>(() => SearchEngineOptimization.CreateNew(SearchEngine.Google, "https://www.google.com", ""));
        }

        [Fact]
        public void FindUrlPositions_ValidHtmlContent_ReturnsCorrectPositions()
        {
            var seo = SearchEngineOptimization.CreateNew(SearchEngine.Google, "https://www.google.com", "test");
            var htmlContent = "<div class=\"egMi0 kCrYT\"><a href=\"/url?q=https://www.google.com\">link1</a></div><div class=\"egMi0 kCrYT\"><a href=\"/url?q=https://www.google.com\">link2</a></div>";

            var positions = seo.FindUrlPositions(htmlContent);

            Assert.Equal(2, positions.Count);
            Assert.Equal(1, positions[0]);
            Assert.Equal(2, positions[1]);
        }
    }
}