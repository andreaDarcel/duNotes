using duNotes.ViewModels;

namespace duNotes.Views;

public partial class HorsLignePage : ContentPage
{
	public HorsLignePage(HorsLigneViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}