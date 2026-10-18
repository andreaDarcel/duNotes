using duNotes.ViewModels;

namespace duNotes.Views;

public partial class DetailDocumentPage : ContentPage
{
	public DetailDocumentPage(DetailDocumentViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}