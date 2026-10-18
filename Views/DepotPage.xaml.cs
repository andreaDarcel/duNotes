using duNotes.ViewModels;

namespace duNotes.Views;

public partial class DepotPage : ContentPage
{
	public DepotPage(DepotViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}