namespace InfoTrack.Assignment.Core.Helper;
public class HttpClientConfiguration
{
    /// <summary>
    /// Base url for the http client.
    /// </summary>
    public string BaseUrl { get; set; } = "https://www.google.com";

    /// <summary>
    /// Headers for the HttpRequestMessage.
    /// </summary>
    public Dictionary<string, string> DefaultRequestHeaders { get; set; } = new Dictionary<string, string>();
}