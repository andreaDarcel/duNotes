namespace duNotes;

public partial class App : Application
{
    private readonly IServiceProvider _services;

    public App(Services.DocumentService documentService, IServiceProvider services)
    {
        InitializeComponent();
        _services = services;
        _ = documentService.InitializeAsync();
    }

    protected override Window CreateWindow(IActivationState? activationState) => new(new AppShell(_services));
}