using CourseProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PasswordSecurity;
using System.Collections.Generic;
using System.Linq;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EmployeeViewModel : ViewModelBase
    {
        private IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the EmployeeViewModel class.
        /// </summary>
        public EmployeeViewModel(IDataService dataService)
        {
            _employee = new Employee();
            _dataService = dataService;
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
                RaisePropertyChanged(LastNamePropertyName);
                RaisePropertyChanged(FirstNamePropertyName);
                RaisePropertyChanged(MiddleNamePropertyName);
                RaisePropertyChanged(PhonePropertyName);
            }
        }

        /// <summary>
        /// Gets the EmployeeID property.
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return _employee.EmployeeID;
            }
        }

        /// <summary>
        /// The <see cref="PositionID" /> property's name.
        /// </summary>
        public const string PositionIDPropertyName = "PositionID";

        /// <summary>
        /// Sets and gets the PositionID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PositionID
        {
            get
            {
                return _employee.PositionID;
            }

            set
            {
                if (_employee.PositionID == value ||
                    value <= 0 ||
                    _dataService.All<Position>()
                    .Where(p => p.PositionID == value)
                    .Count() < 1)
                {
                    return;
                }
                if (Position != null)
                    Position.Employees.Remove(_employee);
                Position = _dataService.All<Position>()
                    .Where(p => p.PositionID == value).Single();
                Position.Employees.Add(_employee);
                RaisePropertyChanged(PositionIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FirstName" /> property's name.
        /// </summary>
        public const string FirstNamePropertyName = "FirstName";

        /// <summary>
        /// Sets and gets the FirstName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FirstName
        {
            get
            {
                return _employee.FirstName;
            }

            set
            {
                if (_employee.FirstName == value)
                {
                    return;
                }

                _employee.FirstName = value;
                RaisePropertyChanged(FirstNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="MiddleName" /> property's name.
        /// </summary>
        public const string MiddleNamePropertyName = "MiddleName";

        /// <summary>
        /// Sets and gets the MiddleName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MiddleName
        {
            get
            {
                return _employee.MiddleName;
            }

            set
            {
                if (_employee.MiddleName == value)
                {
                    return;
                }

                _employee.MiddleName = value;
                RaisePropertyChanged(MiddleNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="LastName" /> property's name.
        /// </summary>
        public const string LastNamePropertyName = "LastName";

        /// <summary>
        /// Sets and gets the LastName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LastName
        {
            get
            {
                return _employee.LastName;
            }

            set
            {
                if (_employee.LastName == value)
                {
                    return;
                }

                _employee.LastName = value;
                RaisePropertyChanged(LastNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Phone" /> property's name.
        /// </summary>
        public const string PhonePropertyName = "Phone";

        /// <summary>
        /// Sets and gets the Phone property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Phone
        {
            get
            {
                return _employee.Phone;
            }

            set
            {
                if (_employee.Phone == value)
                {
                    return;
                }

                _employee.Phone = value;
                RaisePropertyChanged(PhonePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Username" /> property's name.
        /// </summary>
        public const string UsernamePropertyName = "Username";

        /// <summary>
        /// Sets and gets the Username property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Username
        {
            get
            {
                return _employee.Username;
            }

            set
            {
                if (_employee.Username == value)
                {
                    return;
                }

                _employee.Username = value;
                RaisePropertyChanged(UsernamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            protected get
            {
                return _employee.Password;
            }

            set
            {
                _employee.Password = PasswordHash.CreateHash(value);
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        private RelayCommand _saveCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand
                    ?? (_saveCommand = new RelayCommand(
                    () =>
                    {
                        if (!SaveCommand.CanExecute(null))
                        {
                            return;
                        }

                        _dataService.SaveChanges();
                    },
                    () => true));
            }
        }

        /// <summary>
        /// The <see cref="Position" /> property's name.
        /// </summary>
        public const string PositionPropertyName = "Position";

        /// <summary>
        /// Sets and gets the Position property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Position Position
        {
            get
            {
                return _employee.Position;
            }

            protected set
            {
                if (_employee.Position == value)
                {
                    return;
                }

                _employee.Position = value;
                RaisePropertyChanged(PositionPropertyName);
            }
        }

        /// <summary>
        /// Gets the InetOrdersCreated property.
        /// </summary>
        public ICollection<InetOrder> InetOrdersCreated
        {
            get
            {
                return _employee.InetOrders;
            }
        }

        /// <summary>
        /// Gets the InetOrdersUpdated property. 
        /// </summary>
        public ICollection<InetOrder> InetOrdersUpdated
        {
            get
            {
                return _employee.InetOrders1;
            }
        }
    }
}