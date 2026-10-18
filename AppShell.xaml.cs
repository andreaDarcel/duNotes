using duNotes.Views;

namespace duNotes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ConnexionPage), typeof(ConnexionPage));
		Routing.RegisterRoute(nameof(InscriptionPage), typeof(InscriptionPage));
		Routing.RegisterRoute(nameof(DetailDocumentPage), typeof(DetailDocumentPage));
		Routing.RegisterRoute(nameof(NotationPage), typeof(NotationPage));
	}
}