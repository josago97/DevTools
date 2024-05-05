using DevTools.Utilities;
using DevTools.Views.Pages.Pather.Components;
using DevTools.Views.Pages.Pather.Models;
using Microsoft.AspNetCore.Components;
using Path = DevTools.Views.Pages.Pather.Models.Path;

namespace DevTools.Views.Pages.Pather;

public partial class PatherPage
{
    private const string SAMPLE_PATH = "sample-data/xpath-selector";

    #region Sample

    private const string PATH_SAMPLE = "/empleados/empleado[nombre='Juan']/apellido";
    private const string CODE_SAMPLE = """   
        <empleados>
            <empleado>
                <nombre>Juan</nombre>
                <apellido>Gómez</apellido>
                <edad>30</edad>
                <departamento>Desarrollo</departamento>
            </empleado>
            <empleado>
                <nombre>María</nombre>
                <apellido>Rodríguez</apellido>
                <edad>35</edad>
                <departamento>Marketing</departamento>
            </empleado>
            <empleado>
                <nombre>Pedro</nombre>
                <apellido>López</apellido>
                <edad>28</edad>
                <departamento>Ventas</departamento>
            </empleado>
        </empleados>
        """;

    #endregion

    [Inject]
    public HttpClient HttpClient { get; set; }

    private Path Path { get; set; }
    private Document Document { get; set; }






    private CodeEditor CodeEditor { get; set; }

    //private string Path { get; set; }
    private InputDebounceTimer DebounceTimer { get; set; }
    private List<Match> Matches { get; set; }

    public PatherPage()
    {
        DebounceTimer = new();
        Matches = new();
    }
/*
    protected override void OnInitialized()
    {
        base.OnInitialized();

        DebounceTimer.Elapsed += OnDebounced;
    }*/

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && Document == null)
        {
            //InvokeAsync(LoadSample);
           // await Task.Delay(100);
           _ = LoadSample();
        }
    }

    private async Task LoadSample()
    {
        Task[] tasks = [LoadSamplePath(), LoadSampleDocument()];

        await Task.WhenAll(tasks);
    }

    private async Task LoadSamplePath()
    {
        string value = await HttpClient.GetStringAsync($"{SAMPLE_PATH}/path.txt");

        Path = new Path(PathType.XPath, value);
    }

    private async Task LoadSampleDocument()
    {
        string content = await HttpClient.GetStringAsync($"{SAMPLE_PATH}/sample.xml");
        Document = await Document.CreateAsync(content);
        await CodeEditor.ChangeDocument(Document);
    }

    private void OnDebounced()
    {
        Matches.Clear();

        if (string.IsNullOrEmpty(Path.Value)) return;

        try
        {
            if (Document is MarkedDocument markedDocument)
            {
                if (Path.Type == PathType.XPath)
                {
                    Matches = markedDocument.SelectByXpath(Path.Value);
                }
                else if (Path.Type == PathType.CssSelector)
                {
                    Matches = markedDocument.SelectByXpath(Path.Value);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}