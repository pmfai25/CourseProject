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
    public class AccountViewModel : ViewModelBase
    {
        private Account _account;
        /// <summary>
        /// Initializes a new instance of the AccountViewModel class.
        /// </summary>
        public AccountViewModel(Account account)
        {
            _account = account;
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
                return _account.AccountID;
            }

            set
            {
                if (_account.AccountID == value)
                {
                    return;
                }

                _account.AccountID = value;
                RaisePropertyChanged(AccountIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ClientID" /> property's name.
        /// </summary>
        public const string ClientIDPropertyName = "ClientID";

        /// <summary>
        /// Sets and gets the ClientID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ClientID
        {
            get
            {
                return _account.ClientID;
            }

            set
            {
                if (_account.ClientID == value)
                {
                    return;
                }

                _account.ClientID = value;
                RaisePropertyChanged(ClientIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Cash" /> property's name.
        /// </summary>
        public const string CashPropertyName = "Cash";

        /// <summary>
        /// Sets and gets the Cash property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<decimal> Cash
        {
            get
            {
                return _account.Cash;
            }

            set
            {
                if (_account.Cash == value)
                {
                    return;
                }

                _account.Cash = value;
                RaisePropertyChanged(CashPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DebtCeiling" /> property's name.
        /// </summary>
        public const string DebtCeilingPropertyName = "DebtCeiling";

        /// <summary>
        /// Sets and gets the DebtCeiling property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<decimal> DebtCeiling
        {
            get
            {
                return _account.DebtCeiling;
            }

            set
            {
                if (_account.DebtCeiling == value)
                {
                    return;
                }

                _account.DebtCeiling = value;
                RaisePropertyChanged(DebtCeilingPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Client" /> property's name.
        /// </summary>
        public const string ClientPropertyName = "Client";

        /// <summary>
        /// Sets and gets the Client property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual Client Client
        {
            get
            {
                return _account.Client;
            }

            set
            {
                if (_account.Client == value)
                {
                    return;
                }

                _account.Client = value;
                RaisePropertyChanged(ClientPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="InetOrders" /> property's name.
        /// </summary>
        public const string InetOrdersPropertyName = "InetOrders";

        /// <summary>
        /// Sets and gets the InetOrders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual ICollection<InetOrder> InetOrders
        {
            get
            {
                return _account.InetOrders;
            }

            set
            {
                if (_account.InetOrders == value)
                {
                    return;
                }

                _account.InetOrders = value;
                RaisePropertyChanged(InetOrdersPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Refills" /> property's name.
        /// </summary>
        public const string RefillsPropertyName = "Refills";

        /// <summary>
        /// Sets and gets the Refills property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual ICollection<Refill> Refills
        {
            get
            {
                return _account.Refills;
            }

            set
            {
                if (_account.Refills == value)
                {
                    return;
                }

                _account.Refills = value;
                RaisePropertyChanged(RefillsPropertyName);
            }
        }
    }
}