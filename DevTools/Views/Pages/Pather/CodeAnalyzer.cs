using System.Text.RegularExpressions;
using DevTools.Views.Pages.Pather.Models;

namespace DevTools.Views.Pages.Pather;

public class CodeAnalyzer
{
    private static readonly Regex JSON_REGEX = new Regex(@"^\s*(\{.*\}|\[.*\])\s*$", RegexOptions.Singleline);
    private static readonly Regex XML_REGEX = new Regex(@"^<\s*[\w:]+\s*.*?>.*?<\/\s*[\w:]+\s*>$", RegexOptions.Singleline);

    public Language RecognizeLanguage(string code)
    {
        Language language = default;// Language.Unknown;

        if (XML_REGEX.IsMatch(code))
        {
            language = Language.Xml;
        }
        else if (JSON_REGEX.IsMatch(code))
        {
            language = Language.Json;
        }

        return language;
    }
}
