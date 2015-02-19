﻿using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;
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
    public class InetOrderViewModel : ViewModelBase
    {
        private InetOrder _inetOrder;
        private IDataService _dataService;
        private InetOrder _backUp;

        /// <summary>
        /// Initializes a new instance of the InetOrderViewModel class.
        /// </summary>
        //public InetOrderViewModel(IDataService dataService, InetOrder inetOrder)
        //{
        //    _inetOrder = inetOrder;
        //    _dataService = dataService;
        //    //move next code to save command
        //    if (_dataService.All<InetOrder>().Contains(_inetOrder))
        //    {
        //        _inetOrder.UpdatedAt = DateTime.Now;
        //        //EmployeeUpdated = current user
        //        return;
        //    }
        //    _inetOrder.CreatedAt = DateTime.Now;
        //    //EmployeeCreated = current user
        //}

        public InetOrderViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _inetOrder = new InetOrder();
        }

        private InetOrder Copy(InetOrder inetOrder)
        {
            InetOrder result = new InetOrder();
            result.Account = inetOrder.Account;
            result.AccountID = inetOrder.AccountID;
            result.Address = inetOrder.Address;
            result.AddressID = inetOrder.AddressID;
            result.AutomaticPayment = inetOrder.AutomaticPayment;
            result.CreatedAt = inetOrder.CreatedAt;
            result.CreatedBy = inetOrder.CreatedBy;
            result.Employee = inetOrder.Employee;
            result.Employee1 = inetOrder.Employee1;
            result.FinishDate = inetOrder.FinishDate;
            result.InetOrderID = inetOrder.InetOrderID;
            result.IsActual = inetOrder.IsActual;
            result.Payments = inetOrder.Payments;
            result.StartDate = inetOrder.StartDate;
            result.Tariff = inetOrder.Tariff;
            result.TariffID = inetOrder.TariffID;
            result.UpdatedAt = inetOrder.UpdatedAt;
            result.UpdatedBy = inetOrder.UpdatedBy;
            return result;
        }
        
        /// <summary>
        /// The <see cref="IsSaved" /> property's name.
        /// </summary>
        public const string IsSavedPropertyName = "IsSaved";

        private bool _isSaved = true;

        /// <summary>
        /// Sets and gets the IsSaved property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsSaved
        {
            get
            {
                return _isSaved;
            }

            protected set
            {
                if (_isSaved == value)
                {
                    return;
                }

                _isSaved = value;
                RaisePropertyChanged(IsSavedPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="InetOrder" /> property's name.
        /// </summary>
        public const string InetOrderPropertyName = "InetOrder";

        /// <summary>
        /// Sets and gets the InetOrder property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public InetOrder InetOrder
        {
            get
            {
                return _inetOrder;
            }

            set
            {
                if (_inetOrder == value || !IsSaved)
                {
                    return;
                }
                _inetOrder = value;
                if (_dataService.All<InetOrder>()
                    .Where(o => o.InetOrderID == _inetOrder.InetOrderID)
                    .Count() > 0)
                {
                    _backUp = Copy(_inetOrder);
                    IsSaved = true;
                }
                else
                {
                    IsSaved = false;
                }
                RaisePropertyChanged(InetOrderPropertyName);
                RaisePropertyChanged(StartDatePropertyName);
                RaisePropertyChanged(FinishDatePropertyName);
                RaisePropertyChanged(IsActualPropertyName);
                RaisePropertyChanged(AutomaticPaymentPropertyName);
                RaisePropertyChanged(EmployeeCreatedPropertyName);
                RaisePropertyChanged(EmployeeUpdatedPropertyName);
                RaisePropertyChanged(CreatedAtPropertyName);
                RaisePropertyChanged(CreatedByPropertyName);
                RaisePropertyChanged(UpdatedAtPropertyName);
                RaisePropertyChanged(UpdatedByPropertyName);
            }
        }

        /// <summary>
        /// Gets the InetOrderID property.
        /// </summary>
        public int InetOrderID
        {
            get
            {
                return _inetOrder.InetOrderID;
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

            //set
            //{
            //    if (_inetOrder.AccountID == value ||
            //        value <= 0 ||
            //        _dataService.All<Account>()
            //        .Where(a => a.AccountID == value)
            //        .Count() < 1)
            //    {
            //        return;
            //    }
            //    if (Account != null)
            //        Account.InetOrders.Remove(_inetOrder);
            //    Account = _dataService.All<Account>()
            //        .Where(a => a.AccountID == value).Single();
            //    Account.InetOrders.Add(_inetOrder);
            //    RaisePropertyChanged(AccountIDPropertyName);
            //}
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

            //set
            //{
            //    if (_inetOrder.TariffID == value ||
            //        value <= 0 ||
            //        _dataService.All<Tariff>()
            //        .Where(t => t.TariffID == value)
            //        .Count() < 1)
            //    {
            //        return;
            //    }
            //    if (Tariff != null)
            //        Tariff.InetOrders.Remove(_inetOrder);
            //    Tariff = _dataService.All<Tariff>()
            //        .Where(t => t.TariffID == value).Single();
            //    Tariff.InetOrders.Add(_inetOrder);
            //    RaisePropertyChanged(TariffIDPropertyName);
            //}
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
                IsSaved = false;
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
                IsSaved = false;
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
                return _inetOrder.IsActual = FinishDate > DateTime.Now;
            }

            protected set
            {
                if (_inetOrder.IsActual == value)
                {
                    return;
                }

                _inetOrder.IsActual = value;
                IsSaved = false;
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
                return _inetOrder.AutomaticPayment; // unable to save if null!
            }

            set
            {
                if (_inetOrder.AutomaticPayment == value)
                {
                    return;
                }

                _inetOrder.AutomaticPayment = value;
                IsSaved = false;
                RaisePropertyChanged(AutomaticPaymentPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CreatedBy" /> property's name.
        /// </summary>
        public const string CreatedByPropertyName = "CreatedBy";

        /// <summary>
        /// Gets the CreatedBy property.
        /// </summary>
        public Nullable<int> CreatedBy
        {
            get
            {
                return _inetOrder.CreatedBy;
            }
        }

        /// <summary>
        /// The <see cref="CreatedAt" /> property's name.
        /// </summary>
        public const string CreatedAtPropertyName = "CreatedAt";

        /// <summary>
        /// Gets the CreatedAt property. 
        /// </summary>
        public Nullable<System.DateTime> CreatedAt
        {
            get
            {
                if (_inetOrder.CreatedAt == null)
                    _inetOrder.CreatedAt = StartDate;
                return _inetOrder.CreatedAt;
            }
        }

        /// <summary>
        /// The <see cref="UpdatedBy" /> property's name.
        /// </summary>
        public const string UpdatedByPropertyName = "UpdatedBy";

        /// <summary>
        /// Gets the UpdatedBy property.
        /// </summary>
        public Nullable<int> UpdatedBy
        {
            get
            {
                return _inetOrder.UpdatedBy;
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

            protected set
            {
                if (_inetOrder.UpdatedAt == value)
                {
                    return;
                }

                _inetOrder.UpdatedAt = value;
                IsSaved = false;
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

            //set
            //{
            //    if (_inetOrder.AddressID == value ||
            //        value <= 0 ||
            //        _dataService.All<Address>()
            //        .Where(a => a.AddressID == value)
            //        .Count() < 1)
            //    {
            //        return;
            //    }
            //    if (Address != null)
            //        Address.InetOrders.Remove(_inetOrder);
            //    Address = _dataService.All<Address>()
            //        .Where(a => a.AddressID == value).Single();
            //    Address.InetOrders.Add(_inetOrder);
            //    RaisePropertyChanged(AddressIDPropertyName);
            //}
        }

        /// <summary>
        /// The <see cref="Account" /> property's name.
        /// </summary>
        public const string AccountPropertyName = "Account";

        /// <summary>
        /// Sets and gets the Account property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Account Account
        {
            get
            {
                return _inetOrder.Account;
            }

            protected set
            {
                if (_inetOrder.Account == value)
                {
                    return;
                }

                _inetOrder.Account = value;
                IsSaved = false;
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
        public Address Address
        {
            get
            {
                return _inetOrder.Address;
            }

            protected set
            {
                if (_inetOrder.Address == value)
                {
                    return;
                }

                _inetOrder.Address = value;
                IsSaved = false;
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
        public Employee EmployeeCreated
        {
            get
            {
                return _inetOrder.Employee;
            }

            private set
            {
                if (_inetOrder.Employee == value)
                {
                    return;
                }

                _inetOrder.Employee = value;
                IsSaved = false;
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
        public Employee EmployeeUpdated
        {
            get
            {
                return _inetOrder.Employee1;
            }

            protected set
            {
                if (_inetOrder.Employee1 == value)
                {
                    return;
                }

                _inetOrder.Employee1 = value;
                IsSaved = false;
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
        public Tariff Tariff
        {
            get
            {
                return _inetOrder.Tariff;
            }

            private set
            {
                if (_inetOrder.Tariff == value)
                {
                    return;
                }

                _inetOrder.Tariff = value;
                IsSaved = false;
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

            protected set
            {
                if (_inetOrder.Payments == value)
                {
                    return;
                }

                _inetOrder.Payments = value;
                IsSaved = false;
                RaisePropertyChanged(PaymentsPropertyName);
            }
        }
    }
}