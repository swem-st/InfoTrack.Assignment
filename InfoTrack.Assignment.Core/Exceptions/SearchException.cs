namespace InfoTrack.Assignment.Core.Exceptions;

public class SearchException : Exception
{
    public SearchException(string message, string searchEngine, string url, string searchTerm)
        : base(message)
    {
        SearchEngine = searchEngine;
        SearchUrl = url;
        SearchTerm = searchTerm;
    }

    public string SearchEngine { get; }
    public string SearchUrl { get; }
    public string SearchTerm { get; }
}
