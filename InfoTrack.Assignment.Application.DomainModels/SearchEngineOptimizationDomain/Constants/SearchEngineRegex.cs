namespace InfoTrack.Assignment.Application.DomainModels.SearchEngineOptimizationDomain.Constants;

public class SearchEngineRegex
{
    public const string Bing = @"<a class=""tilk"" href=""http(.*?)""";
    public const string Google = @"(?<=<div class=""egMi0 kCrYT""><a href=""/url\?q=)[^""]*";
    public const string Yahoo = @"<a href=""(.*?)""";

}