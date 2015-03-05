using CourseProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using PasswordSecurity;
using Microsoft.Practices.ServiceLocation;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UserViewModel : ViewModelBase
    {
        private IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the UserViewModel class.
        /// </summary>
        public UserViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _currentViewModel = this;
        }

        /// <summary>
        /// The <see cref="Employee" /> property's name.
        /// </summary>
        public const string EmployeePropertyName = "Employee";

        private Employee _employee;

        /// <summary>
        /// Sets and gets the Employee property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Employee Employee
        {
            get
            {
                return _employee;
            }

            set
            {
                if (_employee == value)
                {
                    return;
                }

                _employee = value;
                RaisePropertyChanged(EmployeePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Username" /> property's name.
        /// </summary>
        public const string UsernamePropertyName = "Username";

        private string _username;

        /// <summary>
        /// Sets the Username property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Username
        {
            set
            {
                if (_username == value)
                {
                    return;
                }

                _username = value;
                RaisePropertyChanged(UsernamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _password;

        /// <summary>
        /// Sets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            set
            {
                if (_password == value)
                {
                    return;
                }

                _password = value;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CurrentViewModel" /> property's name.
        /// </summary>
        public const string CurrentViewModelPropertyName = "CurrentViewModel";

        private ViewModelBase _currentViewModel;

        /// <summary>
        /// Sets and gets the CurrentViewModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }

            set
            {
                if (_currentViewModel == value)
                {
                    return;
                }

                _currentViewModel = value;
                RaisePropertyChanged(CurrentViewModelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsLoggedIn" /> property's name.
        /// </summary>
        public const string IsLoggedInPropertyName = "IsLoggedIn";

        private bool _isLoggedIn = false;

        /// <summary>
        /// Sets and gets the IsLoggedIn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return _isLoggedIn;
            }

            set
            {
                if (_isLoggedIn == value)
                {
                    return;
                }

                _isLoggedIn = value;
                RaisePropertyChanged(IsLoggedInPropertyName);
            }
        }

        private RelayCommand _logInCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand LogInCommand
        {
            get
            {
                return _logInCommand
                    ?? (_logInCommand = new RelayCommand(
                    () =>
                    {
                        if (!LogInCommand.CanExecute(null))
                        {
                            return;
                        }

                        Employee employee = _dataService.All<Employee>()
                            .Where(e => e.Username == _username).SingleOrDefault();
                        if (employee != null &&
                            PasswordHash.ValidatePassword(_password, employee.Password))
                        {
                            IsLoggedIn = true;
                            _employee = employee;
                            CurrentViewModel = ServiceLocator.Current.GetInstance<MainViewModel>();
                        }
                    },
                    () =>
                    {
                        return !string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password);
                    }));
            }
        }
    }
}