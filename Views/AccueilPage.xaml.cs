using duNotes.ViewModels;

namespace duNotes.Views;

public partial class AccueilPage : ContentPage
{
	public AccueilPage(AccueilViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}