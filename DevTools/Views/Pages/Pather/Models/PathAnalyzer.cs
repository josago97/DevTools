using System.Text.RegularExpressions;

namespace DevTools.Views.Pages.Pather.Models;

public class PathAnalyzer
{
    private static readonly Regex CSS_SELECTOR_REGEX = new (@"^\/");
    private static readonly Regex XPATH_REGEX = new(@"^\/");

    public PathType Analyze(string path)
    {
        return PathType.XPath;
    }
}
