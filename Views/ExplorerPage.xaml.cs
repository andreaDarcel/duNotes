using duNotes.ViewModels;

namespace duNotes.Views;

public partial class ExplorerPage : ContentPage
{
	public ExplorerPage(ExplorerViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}