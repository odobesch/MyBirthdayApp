using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBirthdayApp.Data;
using MyBirthdayApp.Models;

namespace MyBirthdayApp.ViewModel
{
    [QueryProperty(nameof(Person), nameof(Person))]
    public partial class DetailViewModel : ObservableObject
    {
        DatabaseContext _db;

        [ObservableProperty]
        public int _detailId;

        [ObservableProperty]
        public string _detailFirstName;

        [ObservableProperty]
        public string _detailLastName;

        [ObservableProperty]
        public string _detailEmail;

        [ObservableProperty]
        public string _detailPhone;

        [ObservableProperty]
        public DateTime _detailDob;

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
