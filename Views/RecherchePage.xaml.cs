using duNotes.ViewModels;

namespace duNotes.Views;

public partial class RecherchePage : ContentPage
{
	public RecherchePage(RechercheViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}