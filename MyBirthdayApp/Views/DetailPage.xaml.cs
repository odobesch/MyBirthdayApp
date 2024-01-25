using MyBirthdayApp.Models;
using MyBirthdayApp.ViewModel;

namespace MyBirthdayApp.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    public DetailPage(Person p, DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        lbDetailId.Text = p.Id.ToString();
        lbDetailFirstName.Text = p.FirstName.ToString();
        lbDetailLastName.Text = p.LastName;
        lbDetailDob.Text = p.Dob.ToString();
        lbDetailEmail.Text = p.Email;
        lbDetailPhone.Text = p.Phone;
    }
}