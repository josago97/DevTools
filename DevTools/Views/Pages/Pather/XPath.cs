using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using AngleSharp.Dom;
using AngleSharp.XPath;

namespace DevTools.Views.Pages.Pather;

public class XPath : IPather
{
    [StringSyntax("Regex")]
    private const string XPATH_REGEX = @"^\/(\/?[\w-]+)+(\[\d+\])?$";

    public string GetPath(IDocument document, int position)
    {
        throw new NotImplementedException();
    }

    public bool IsValid(string path)
    {
        return Regex.IsMatch(path, XPATH_REGEX);
    }

    public IReadOnlyList<INode> SelectAll(IDocument document, string selector)
    {
        return document.DocumentElement.SelectNodes(selector);
    }
}
