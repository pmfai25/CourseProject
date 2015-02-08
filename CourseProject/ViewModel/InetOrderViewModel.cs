using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class InetOrderViewModel : ViewModelBase
    {
        private InetOrder _inetOrder;

        /// <summary>
        /// Initializes a new instance of the InetOrderViewModel class.
        /// </summary>
        public InetOrderViewModel(InetOrder inetOrder)
        {
            _inetOrder = inetOrder;
        }

        /// <summary>
        /// The <see cref="InetOrderID" /> property's name.
        /// </summary>
        public const string InetOrderIDPropertyName = "InetOrderID";

        /// <summary>
        /// Sets and gets the InetOrderID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int InetOrderID
        {
            get
            {
                return _inetOrder.InetOrderID;
            }

            set
            {
                if (_inetOrder.InetOrderID == value)
                {
                    return;
                }

                _inetOrder.InetOrderID = value;
                RaisePropertyChanged(InetOrderIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AccountID" /> property's name.
        /// </summary>
        public const string AccountIDPropertyName = "AccountID";

        /// <summary>
        /// Sets and gets the AccountID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int AccountID
        {
            get
            {
                return _inetOrder.AccountID;
            }

            set
            {
                if (_inetOrder.AccountID == value)
                {
                    return;
                }

                _inetOrder.AccountID = value;
                RaisePropertyChanged(AccountIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TariffID" /> property's name.
        /// </summary>
        public const string TariffIDPropertyName = "TariffID";

        /// <summary>
        /// Sets and gets the TariffID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<int> TariffID
        {
            get
            {
                return _inetOrder.TariffID;
            }

            set
            {
                if (_inetOrder.TariffID == value)
                {
                    return;
                }

                _inetOrder.TariffID = value;
                RaisePropertyChanged(TariffIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="StartDate" /> property's name.
        /// </summary>
        public const string StartDatePropertyName = "StartDate";

        /// <summary>
        /// Sets and gets the StartDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<System.DateTime> StartDate
        {
            get
            {
                return _inetOrder.StartDate;
            }

            set
            {
                if (_inetOrder.StartDate == value)
                {
                    return;
                }

                _inetOrder.StartDate = value;
                RaisePropertyChanged(StartDatePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FinishDate" /> property's name.
        /// </summary>
        public const string FinishDatePropertyName = "FinishDate";

        /// <summary>
        /// Sets and gets the FinishDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<System.DateTime> FinishDate
        {
            get
            {
                return _inetOrder.FinishDate;
            }

            set
            {
                if (_inetOrder.FinishDate == value)
                {
                    return;
                }

                _inetOrder.FinishDate = value;
                RaisePropertyChanged(FinishDatePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsActual" /> property's name.
        /// </summary>
        public const string IsActualPropertyName = "IsActual";

        /// <summary>
        /// Sets and gets the IsActual property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<bool> IsActual
        {
            get
            {
                return _inetOrder.IsActual;
            }

            set
            {
                if (_inetOrder.IsActual == value)
                {
                    return;
                }

                _inetOrder.IsActual = value;
                RaisePropertyChanged(IsActualPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AutomaticPayment" /> property's name.
        /// </summary>
        public const string AutomaticPaymentPropertyName = "AutomaticPayment";

        /// <summary>
        /// Sets and gets the AutomaticPayment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<bool> AutomaticPayment
        {
            get
            {
                return _inetOrder.AutomaticPayment;
            }

            set
            {
                if (_inetOrder.AutomaticPayment == value)
                {
                    return;
                }

                _inetOrder.AutomaticPayment = value;
                RaisePropertyChanged(AutomaticPaymentPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CreatedBy" /> property's name.
        /// </summary>
        public const string CreatedByPropertyName = "CreatedBy";

        /// <summary>
        /// Sets and gets the CreatedBy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<int> CreatedBy
        {
            get
            {
                return _inetOrder.CreatedBy;
            }

            set
            {
                if (_inetOrder.CreatedBy == value)
                {
                    return;
                }

                _inetOrder.CreatedBy = value;
                RaisePropertyChanged(CreatedByPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CreatedAt" /> property's name.
        /// </summary>
        public const string CreatedAtPropertyName = "CreatedAt";

        /// <summary>
        /// Sets and gets the CreatedAt property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<System.DateTime> CreatedAt
        {
            get
            {
                return _inetOrder.CreatedAt;
            }

            set
            {
                if (_inetOrder.CreatedAt == value)
                {
                    return;
                }

                _inetOrder.CreatedAt = value;
                RaisePropertyChanged(CreatedAtPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="UpdatedBy" /> property's name.
        /// </summary>
        public const string UpdatedByPropertyName = "UpdatedBy";

        /// <summary>
        /// Sets and gets the UpdatedBy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<int> UpdatedBy
        {
            get
            {
                return _inetOrder.UpdatedBy;
            }

            set
            {
                if (_inetOrder.UpdatedBy == value)
                {
                    return;
                }

                _inetOrder.UpdatedBy = value;
                RaisePropertyChanged(UpdatedByPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="UpdatedAt" /> property's name.
        /// </summary>
        public const string UpdatedAtPropertyName = "UpdatedAt";

        /// <summary>
        /// Sets and gets the UpdatedAt property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<System.DateTime> UpdatedAt
        {
            get
            {
                return _inetOrder.UpdatedAt;
            }

            set
            {
                if (_inetOrder.UpdatedAt == value)
                {
                    return;
                }

                _inetOrder.UpdatedAt = value;
                RaisePropertyChanged(UpdatedAtPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AddressID" /> property's name.
        /// </summary>
        public const string AddressIDPropertyName = "AddressID";

        /// <summary>
        /// Sets and gets the AddressID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<int> AddressID
        {
            get
            {
                return _inetOrder.AddressID;
            }

            set
            {
                if (_inetOrder.AddressID == value)
                {
                    return;
                }

                _inetOrder.AddressID = value;
                RaisePropertyChanged(AddressIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Account" /> property's name.
        /// </summary>
        public const string AccountPropertyName = "Account";

        /// <summary>
        /// Sets and gets the Account property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Account Account
        {
            get
            {
                return _inetOrder.Account;
            }

            set
            {
                if (_inetOrder.Account == value)
                {
                    return;
                }

                _inetOrder.Account = value;
                RaisePropertyChanged(AccountPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Address" /> property's name.
        /// </summary>
        public const string AddressPropertyName = "Address";

        /// <summary>
        /// Sets and gets the Address property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Address Address
        {
            get
            {
                return _inetOrder.Address;
            }

            set
            {
                if (_inetOrder.Address == value)
                {
                    return;
                }

                _inetOrder.Address = value;
                RaisePropertyChanged(AddressPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="EmployeeCreated" /> property's name.
        /// </summary>
        public const string EmployeeCreatedPropertyName = "EmployeeCreated";

        /// <summary>
        /// Sets and gets the EmployeeCreated property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Employee EmployeeCreated
        {
            get
            {
                return _inetOrder.Employee;
            }

            set
            {
                if (_inetOrder.Employee == value)
                {
                    return;
                }

                _inetOrder.Employee = value;
                RaisePropertyChanged(EmployeeCreatedPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="EmployeeUpdated" /> property's name.
        /// </summary>
        public const string EmployeeUpdatedPropertyName = "EmployeeUpdated";

        /// <summary>
        /// Sets and gets the EmployeeUpdated property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Employee EmployeeUpdated
        {
            get
            {
                return _inetOrder.Employee1;
            }

            set
            {
                if (_inetOrder.Employee1 == value)
                {
                    return;
                }

                _inetOrder.Employee1 = value;
                RaisePropertyChanged(EmployeeUpdatedPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Tariff" /> property's name.
        /// </summary>
        public const string TariffPropertyName = "Tariff";

        /// <summary>
        /// Sets and gets the Tariff property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Tariff Tariff
        {
            get
            {
                return _inetOrder.Tariff;
            }

            set
            {
                if (_inetOrder.Tariff == value)
                {
                    return;
                }

                _inetOrder.Tariff = value;
                RaisePropertyChanged(TariffPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Payments" /> property's name.
        /// </summary>
        public const string PaymentsPropertyName = "Payments";

        /// <summary>
        /// Sets and gets the Payments property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual ICollection<Payment> Payments
        {
            get
            {
                return _inetOrder.Payments;
            }

            set
            {
                if (_inetOrder.Payments == value)
                {
                    return;
                }

                _inetOrder.Payments = value;
                RaisePropertyChanged(PaymentsPropertyName);
            }
        }
    }
}