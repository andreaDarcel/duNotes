using duNotes.Views; // <-- Indispensable pour reconnaître RecherchePage, ApercuPage, etc.
using Microsoft.Extensions.DependencyInjection;

namespace duNotes;

public partial class AppShell : Shell
{
	public AppShell(IServiceProvider services)
	{
		InitializeComponent();
		ConnexionShellContent.ContentTemplate = new DataTemplate(() => services.GetRequiredService<ConnexionPage>());
		AccueilShellContent.ContentTemplate = new DataTemplate(() => services.GetRequiredService<AccueilPage>());
		ExplorerShellContent.ContentTemplate = new DataTemplate(() => services.GetRequiredService<ExplorerPage>());
		DepotShellContent.ContentTemplate = new DataTemplate(() => services.GetRequiredService<DepotPage>());
		HorsLigneShellContent.ContentTemplate = new DataTemplate(() => services.GetRequiredService<HorsLignePage>());

		Routing.RegisterRoute(nameof(ConnexionPage), typeof(ConnexionPage));
		Routing.RegisterRoute(nameof(InscriptionPage), typeof(InscriptionPage));
		Routing.RegisterRoute(nameof(RecherchePage), typeof(RecherchePage));
		Routing.RegisterRoute(nameof(DetailDocumentPage), typeof(DetailDocumentPage));
		Routing.RegisterRoute(nameof(ApercuPage), typeof(ApercuPage));
		Routing.RegisterRoute(nameof(NotationPage), typeof(NotationPage));
	}
}