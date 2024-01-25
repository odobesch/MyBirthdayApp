using MyBirthdayApp.Data;
using MyBirthdayApp.ViewModel;

namespace MyBirthdayApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();        
	}
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();        
        GetPeople();
    }

    public void GetPeople()
    {
        using (var db = new DatabaseContext())
        {
            mainCollection.ItemsSource = db.GetAll().ToList();
        }
    }
}