using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using AngleSharp.Dom;

namespace DevTools.Views.Pages.Pather;

public class CssSelector : IPather
{
    [StringSyntax("Regex")]
    private const string CSS_SELECTOR_REGEX = @"^(\w+|\*|\.|#|\[.*?\])+(\s+(\w+|\*|\[.*?\]|#|\.)(\s*[\w-]|[*#])*)*$";

    public string GetPath(IDocument document, int position)
    {
        throw new NotImplementedException();
    }

    public bool IsValid(string path)
    {
        return Regex.IsMatch(path, CSS_SELECTOR_REGEX);
    }

    public IReadOnlyList<INode> SelectAll(IDocument document, string selector)
    {
        IHtmlCollection<IElement> nodes = document.QuerySelectorAll(selector);

        return nodes.ToArray();
    }
}
