using duNotes.Views; // <-- Indispensable pour reconnaître RecherchePage, ApercuPage, etc.

namespace duNotes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ConnexionPage), typeof(ConnexionPage));
		Routing.RegisterRoute(nameof(InscriptionPage), typeof(InscriptionPage));
		Routing.RegisterRoute(nameof(RecherchePage), typeof(RecherchePage));
		Routing.RegisterRoute(nameof(DetailDocumentPage), typeof(DetailDocumentPage));
		Routing.RegisterRoute(nameof(ApercuPage), typeof(ApercuPage));
		Routing.RegisterRoute(nameof(NotationPage), typeof(NotationPage));
	}
}