using System.Text.RegularExpressions;
using AngleSharp.Dom;
using AngleSharp.Xml.Parser;
using AngleSharp.XPath;

namespace DevTools.Views.Pages.Pather.Models;

public class MarkedDocument : Document
{
    public static readonly Regex HTML_REGEX = new(@"<\s*html\s*[^>]*?>");

    //private readonly HtmlParser _parser;
    //private readonly XmlParser _parser;
    private IDocument _document;

    public MarkedDocument(string content) : base(content)
    {
    }

    protected override async Task InitAsync()
    {
        XmlParser parser = new XmlParser(new XmlParserOptions()
        {
            IsKeepingSourceReferences = true
        });

        if (Content.Trim().StartsWith("<!DOCTYPE HTML", StringComparison.OrdinalIgnoreCase))
        {
            Language = Language.Html;
        }
        else
        {
            Language = Language.Xml;
        }

        _document = await parser.ParseDocumentAsync(Content);
    }

    public List<Match> SelectByXpath(string xpath)
    {
        IList<INode> nodes = _document.DocumentElement.SelectNodes(xpath);

        return ToMatches(nodes);
    }

    public List<Match> SelectBySelector(string selector)
    {
        IHtmlCollection<IElement> nodes = _document.QuerySelectorAll(selector);

        return ToMatches(nodes);
    }

    private List<Match> ToMatches(IEnumerable<INode> nodes)
    {
        List<Match> matches = new List<Match>();

        foreach (IElement node in nodes)
        {
            string outerHtml = node.OuterHtml;
            string innerHtml = node.InnerHtml;
            int start = node.SourceReference.Position.Index;
            int end = start + outerHtml.Length;

            matches.Add(new Match(start, end, outerHtml, innerHtml));
        }

        return matches;
    }
}
