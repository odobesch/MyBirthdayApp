using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBirthdayApp.Data;
using MyBirthdayApp.Models;

namespace MyBirthdayApp.ViewModel
{
    [QueryProperty(nameof(Person), nameof(Person))]
    public partial class DeleteViewModel : ObservableObject
    {
        DatabaseContext _db;

        [ObservableProperty]
        Person person;

        [RelayCommand]
        public async Task Delete(Person p)
        {
            using (var _db = new DatabaseContext())
            {
                _db.Delete(p.Id);
                //Items = _db.GetAll();
            }
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task Cancel(Person p)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
