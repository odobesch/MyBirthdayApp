using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MyBirthdayApp.Data;
using MyBirthdayApp.Models;
using MyBirthdayApp.Views;

namespace MyBirthdayApp.ViewModel
{
    [QueryProperty(nameof(Person), nameof(Person))]
    public partial class EditViewModel : ObservableObject
    {
        DatabaseContext _db;

        [ObservableProperty]
        public int _editId;

        [ObservableProperty]
        public string _editFirstName;

        [ObservableProperty]
        public string _editLastName;

        [ObservableProperty]
        public string _editEmail;

        [ObservableProperty]
        public string _editPhone;

        [ObservableProperty]
        public DateTime _editDob;       

        [RelayCommand]
        public async Task Edit()
        {
            Person p = new()
            {
                Id = EditId,
                FirstName = EditFirstName,
                LastName = EditLastName,
                Email = EditEmail,
                Phone = EditPhone,
                Dob = EditDob
            };

            using (var _db = new DatabaseContext())
            {
                var result = _db.Update(p);
            }           
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public void Clear()
        {
           EditFirstName = string.Empty;
            EditLastName = string.Empty;
            EditEmail = string.Empty;
            EditPhone = string.Empty;
            EditDob = DateTime.MinValue;            
        }
    }
}
