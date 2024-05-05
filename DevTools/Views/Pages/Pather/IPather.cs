using AngleSharp.Dom;

namespace DevTools.Views.Pages.Pather;

public interface IPather
{
    string GetPath(IDocument document, int position);

    bool IsValid(string path);

    IReadOnlyList<INode> SelectAll(IDocument document, string path);
}
