using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LoginPage.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _fullName;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private string _message;
        private bool _hasError;

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(); }
        }

        public string Message
        {
            get => _message;
            set { _message = value; OnPropertyChanged(); }
        }

        public bool HasError
        {
            get => _hasError;
            set { _hasError = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand => new Command(OnRegister);

        private void OnRegister()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                Message = "Please fill in all fields.";
                HasError = true;
                return;
            }

            if (Password != ConfirmPassword)
            {
                Message = "Passwords do not match.";
                HasError = true;
                return;
            }

            // You can add more validation or registration logic here

            Message = "Registration successful!";
            HasError = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
