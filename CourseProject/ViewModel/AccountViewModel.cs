using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;
using System.Linq;
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
        private IDataService _dataService;
        /// <summary>
        /// Initializes a new instance of the AccountViewModel class.
        /// </summary>
        public AccountViewModel(IDataService dataService, Account account)
        {
            _dataService = dataService;
            _account = account;
            //if (dataService.All<Account>().Contains<Account>(account))
            //{
            //    //make a copy here, not just new
            //    _account = new Account();
            //}
            //else
            //    _account = account;
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
                if (_account.AccountID == value ||
                    value <= 0 ||
                    _dataService.All<Account>()
                    .Where<Account>(a => a.AccountID == value)
                    .Count<Account>() > 0)
                {
                    return;
                }
                
                _account.AccountID = value;
                RaisePropertyChanged(AccountIDPropertyName);

                foreach (var refill in Refills)
                {
                    refill.AccountID = value;
                }
                
                foreach (var inetOrder in InetOrders)
                {
                    inetOrder.AccountID = value;
                }
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
                if (_account.ClientID == value ||
                    value <= 0 ||
                    _dataService.All<Client>()
                    .Where<Client>(c => c.ClientID == value)
                    .Count<Client>() < 1)
                {
                    return;
                }

                _account.ClientID = value;
                RaisePropertyChanged(ClientIDPropertyName);
////////////////// need test!!!
                if (Client != null)
                    Client.Accounts.Remove(_account);

                Client = _dataService.All<Client>().
                    Where<Client>(c => c.ClientID == value).Single<Client>();
                Client.Accounts.Add(_account);
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

            protected set
            {
                if (_account.Cash == value ||
                    value < DebtCeiling)
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
                if (value > _account.Cash)
                    value = _account.Cash;
                if (_account.DebtCeiling == value ||
                    value > 0)
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

            protected set
            {
                if (_account.Refills == value)
                {
                    return;
                }

                _account.Refills = value;
                RaisePropertyChanged(RefillsPropertyName);
            }
        }

        public bool RefillCash();
        public bool PayCash();
    }
}