using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBirthdayApp.Data;
using MyBirthdayApp.Models;
using System.Text.RegularExpressions;

namespace MyBirthdayApp.ViewModel
{
    public partial class AddViewModel : ObservableObject
    {
        DatabaseContext _db;

        [ObservableProperty]
        public string _firstName;

        [ObservableProperty]
        public string _lastName;

        [ObservableProperty]
        public string _email;

        [ObservableProperty]
        public string _phoneNumber;

        [ObservableProperty]
        public DateTime _dob;

        [ObservableProperty]
        public bool _isEnabled;

        [ObservableProperty]
        public bool _isBusy;

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task Add()
        {
            var output = ValidateUserInput();
            if (output.Contains("OK"))
            {
                IsBusy = true;

                Person person = new()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Phone = PhoneNumber,
                    Dob = Dob
                };
                using (var _db = new DatabaseContext())
                {
                    _db.Insert(person);
                }
                IsBusy = false;
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                var alertMessage = string.Empty;
                foreach (var item in output)
                {
                    alertMessage += $"{item}\r\n";
                }
                await Application.Current.MainPage.DisplayAlert("Error", $"{alertMessage}", "Ok", "Cancel");
            }
        }

        private List<string> ValidateUserInput()
        {
            string message = "OK";
            List<string> outputList = new()
            {
                message
            };

            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(Email) || String.IsNullOrEmpty(PhoneNumber))
            {                
                message = "One of input is missing!";
                outputList.Clear();
                outputList.Add(message);
            }

            var nameRegexPattern = @"^[\p{L}'][ \p{L}'-]*[\p{L}]$";
            Match matchFirstName = Regex.Match(FirstName, nameRegexPattern, RegexOptions.IgnoreCase);
            if (!matchFirstName.Success)
            {
                outputList.Remove("OK");
                message = "First Name format is invalid!";
                outputList.Add(message);
            }
            Match matchLastName = Regex.Match(LastName, nameRegexPattern, RegexOptions.IgnoreCase);
            if (!matchLastName.Success)
            {
                outputList.Remove("OK");
                message = "Last Name format is invalid!";
                outputList.Add(message);
            }

            return outputList;
        }

        [RelayCommand]
        public void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            IsBusy = false;
        }
    }
}
