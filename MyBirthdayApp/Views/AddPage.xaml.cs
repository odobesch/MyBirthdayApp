using MyBirthdayApp.ViewModel;
using System.Runtime.CompilerServices;

namespace MyBirthdayApp.Views;

public partial class AddPage : ContentPage
{
    public AddPage(AddViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }    
}