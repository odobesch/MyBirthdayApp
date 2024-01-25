using MyBirthdayApp.ViewModel;

namespace MyBirthdayApp.Views;

public partial class DeletePage : ContentPage
{
	public DeletePage(DeleteViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}