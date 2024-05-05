using System.Text.RegularExpressions;

namespace DevTools.Views.Pages.Pather.Models;

public abstract class Document
{
    private static readonly Regex JSON_REGEX = new Regex(@"^\s*(\{.*\}|\[.*\])", RegexOptions.Singleline);
    private static readonly Regex XML_REGEX = new Regex(@"^\s*<", RegexOptions.Singleline);

    public Language Language { get; protected set; }
    public string Content { get; protected set; }

    public static async Task<Document> CreateAsync(string content)
    {
        Document document = null;

        if (!string.IsNullOrEmpty(content))
        {
            try
            {
                if (XML_REGEX.IsMatch(content))
                {
                    document = new MarkedDocument(content);
                }
                else if (JSON_REGEX.IsMatch(content))
                {
                    document = new UnknownDocument(content);
                }
            }
            catch { }
        }
        
        document ??= new UnknownDocument(content);
        await document.InitAsync();

        return document;
    }

    public Document(string content)
    {
        Content = content;
    }

    protected virtual Task InitAsync()
    {
        return Task.CompletedTask;
    }
}
