using duNotes.ViewModels;

namespace duNotes.Views;

public partial class NotationPage : ContentPage
{
	public NotationPage(NotationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}