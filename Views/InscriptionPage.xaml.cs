using duNotes.ViewModels;

namespace duNotes.Views;

public partial class InscriptionPage : ContentPage
{
	public InscriptionPage(InscriptionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}