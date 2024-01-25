using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBirthdayApp.Data;
using MyBirthdayApp.Models;
using MyBirthdayApp.Views;
using System.Collections.ObjectModel;

namespace MyBirthdayApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        DatabaseContext _db;

        [ObservableProperty]
        string text;

        //public List<Person> _items;
        [ObservableProperty]
        ObservableCollection<Person> _items;

        [ObservableProperty]
        private string _wholeName;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;  

        [RelayCommand]
        async Task Delete(Person p)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                [nameof(Person)] = p
            };
            Routing.RegisterRoute(nameof(DeletePage), typeof(DeletePage));
            await Shell.Current.GoToAsync(nameof(DeletePage), true, navigationParameter);
        }

        [RelayCommand]
        async Task Add()
        {
            await Shell.Current.GoToAsync(nameof(AddPage));
        }

        [RelayCommand]
        public async Task Edit(Person p)
        {
            Person person = new()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                Dob = p.Dob
            };

            await Shell.Current.Navigation.PushModalAsync(new EditPage(person, new EditViewModel()));            
        }

        [RelayCommand]
        public async Task Tap(Person p)
        {  
            Person person = new()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                Dob = p.Dob
            };

            await Shell.Current.Navigation.PushModalAsync(new DetailPage(person, new DetailViewModel()));
        }
    }
}
