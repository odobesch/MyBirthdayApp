using MyBirthdayApp.Models;
using MyBirthdayApp.ViewModel;

namespace MyBirthdayApp.Views;

public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    public EditPage(Person p, EditViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        idEntry.Text = p.Id.ToString();
        firstNameEntry.Text = p.FirstName;
        lastNameEntry.Text = p.LastName;
        dobPicker.Date = p.Dob.Date;
        emailEntry.Text = p.Email;
        phoneEntry.Text = p.Phone;
    }
}