using AngleSharp.Dom;

namespace DevTools.Views.Pages.Pather;

public class JsonPath : IPather
{
    public string GetPath(IDocument document, int position)
    {
        throw new NotImplementedException();
    }

    public bool IsValid(string path)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<INode> SelectAll(IDocument document, string path)
    {
        throw new NotImplementedException();
    }
}
