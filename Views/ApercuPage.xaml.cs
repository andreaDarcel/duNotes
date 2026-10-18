using duNotes.ViewModels;

namespace duNotes.Views;

public partial class ApercuPage : ContentPage
{
	public ApercuPage(ApercuViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}