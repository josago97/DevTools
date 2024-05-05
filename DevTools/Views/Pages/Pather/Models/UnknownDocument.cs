namespace DevTools.Views.Pages.Pather.Models;

public class UnknownDocument : Document
{
    public UnknownDocument(string content) : base(content)
    {
        Language = Language.Unknown;
    }
}
