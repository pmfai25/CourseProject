using CourseProject.Model;
using GalaSoft.MvvmLight;
using PasswordSecurity;
using System.Collections.Generic;

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
        private Employee _employee;

        /// <summary>
        /// Initializes a new instance of the EmployeeViewModel class.
        /// </summary>
        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }

        /// <summary>
        /// The <see cref="EmployeeID" /> property's name.
        /// </summary>
        public const string EmployeeIDPropertyName = "EmployeeID";

        /// <summary>
        /// Sets and gets the EmployeeID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EmployeeID
        {
            get
            {
                return _employee.EmployeeID;
            }

            set
            {
                if (_employee.EmployeeID == value)
                {
                    return;
                }

                _employee.EmployeeID = value;
                RaisePropertyChanged(EmployeeIDPropertyName);
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
                if (_employee.PositionID == value)
                {
                    return;
                }

                _employee.PositionID = value;
                RaisePropertyChanged(PositionIDPropertyName);
                RaisePropertyChanged(PositionPropertyName);
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

        /// <summary>
        /// The <see cref="Position" /> property's name.
        /// </summary>
        public const string PositionPropertyName = "Position";

        /// <summary>
        /// Sets and gets the Position property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Position Position
        {
            get
            {
                return _employee.Position;
            }

            set
            {
                if (_employee.Position == value)
                {
                    return;
                }

                _employee.Position = value;
                RaisePropertyChanged(PositionPropertyName);
                RaisePropertyChanged(PositionIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="InetOrdersCreated" /> property's name.
        /// </summary>
        public const string InetOrdersCreatedPropertyName = "InetOrdersCreated";

        /// <summary>
        /// Sets and gets the InetOrdersCreated property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual ICollection<InetOrder> InetOrdersCreated
        {
            get
            {
                return _employee.InetOrders;
            }

            //protected set
            //{
            //    if (_employee.InetOrders == value)
            //    {
            //        return;
            //    }

            //    _employee.InetOrders = value;
            //    RaisePropertyChanged(InetOrdersCreatedPropertyName);
            //}
        }

        /// <summary>
        /// The <see cref="InetOrdersUpdated" /> property's name.
        /// </summary>
        public const string InetOrdersUpdatedPropertyName = "InetOrdersUpdated";

        /// <summary>
        /// Sets and gets the InetOrdersUpdated property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ICollection<InetOrder> InetOrdersUpdated
        {
            get
            {
                return _employee.InetOrders1;
            }

            //protected set
            //{
            //    if (_employee.InetOrders1 == value)
            //    {
            //        return;
            //    }

            //    _employee.InetOrders1 = value;
            //    RaisePropertyChanged(InetOrdersUpdatedPropertyName);
            //}
        }
    }
}