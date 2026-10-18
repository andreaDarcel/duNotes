using duNotes.ViewModels;

namespace duNotes.Views;

public partial class ConnexionPage : ContentPage
{
	public ConnexionPage(ConnexionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}