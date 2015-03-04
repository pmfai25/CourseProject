using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.CommandWpf;

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
        private IDataService _dataService;
        private Account _backUp;

        public AccountViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _account = new Account();
        }

        private Account BackUp(Account account)
        {
            Account result = new Account();
            result.AccountID = account.AccountID;
            result.Cash = account.Cash;
            result.Client = account.Client;
            result.ClientID = account.ClientID;
            result.DebtCeiling = account.DebtCeiling;
            result.InetOrders = account.InetOrders;
            result.Refills = account.Refills;
            return result;
        }

        private Account Fill(ref Account account, Account filler)
        {
            account.AccountID = filler.AccountID;
            account.Cash = filler.Cash;
            account.Client = filler.Client;
            account.ClientID = filler.ClientID;
            account.DebtCeiling = filler.DebtCeiling;
            account.InetOrders = filler.InetOrders;
            account.Refills = filler.Refills;
            return account;
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
        /// The <see cref="Account" /> property's name.
        /// </summary>
        public const string AccountPropertyName = "Account";

        private Account _account;

        /// <summary>
        /// Sets and gets the Account property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Account Account
        {
            get
            {
                return _account;
            }

            set
            {
                if (!IsSaved)
                {
                    return;
                }
                _account = value;
                if (_dataService.All<Account>()
                    .Where(a => a.AccountID == _account.AccountID)
                    .Count() > 0)
                {
                    _backUp = BackUp(_account);
                    IsSaved = true;
                }
                else
                {
                    IsSaved = false;
                }
                RaisePropertyChanged(AccountPropertyName);
                RaisePropertyChanged(CashPropertyName);
                RaisePropertyChanged(DebtCeilingPropertyName);
            }
        }

        /// <summary>
        /// Gets the AccountID property.
        /// </summary>
        public int AccountID
        {
            get
            {
                return _account.AccountID;
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

            //set
            //{
            //    if (_account.ClientID == value ||
            //        value <= 0 ||
            //        _dataService.All<Client>()
            //        .Where(c => c.ClientID == value)
            //        .Count() < 1)
            //    {
            //        return;
            //    }
            //    if (Client != null)
            //        Client.Accounts.Remove(_account);
            //    Client = _dataService.All<Client>()
            //        .Where(c => c.ClientID == value).Single();
            //    Client.Accounts.Add(_account);
            //    RaisePropertyChanged(ClientIDPropertyName);
            //}
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
                IsSaved = false;
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
                if (value > 0)
                {
                    RaisePropertyChanged(DebtCeilingPropertyName);
                    return;
                }
                if (_account.DebtCeiling == value)
                {
                    return;
                }
                _account.DebtCeiling = value;
                IsSaved = false;
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
        public Client Client
        {
            get
            {
                return _account.Client;
            }

            protected set
            {
                if (_account.Client == value)
                {
                    return;
                }

                _account.Client = value;
                IsSaved = false;
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
        public ICollection<InetOrder> InetOrders
        {
            get
            {
                return _account.InetOrders;
            }

            protected set
            {
                if (_account.InetOrders == value)
                {
                    return;
                }

                _account.InetOrders = value;
                IsSaved = false;
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
        public ICollection<Refill> Refills
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
                IsSaved = false;
                RaisePropertyChanged(RefillsPropertyName);
            }
        }

        private RelayCommand _saveChangesCommand;

        /// <summary>
        /// Gets the SaveChangesCommand.
        /// </summary>
        public RelayCommand SaveChangesCommand
        {
            get
            {
                return _saveChangesCommand
                    ?? (_saveChangesCommand = new RelayCommand(
                    () =>
                    {
                        if (!SaveChangesCommand.CanExecute(null))
                        {
                            return;
                        }
                        if (_dataService.All<Account>()
                            .Where(a => a.ClientID == _account.AccountID)
                            .Count() < 1)
                        {
                            _dataService.Add<Account>(_account);
                        }
                        _dataService.SaveChanges();
                        IsSaved = true;
                    },
                    () => !IsSaved));
            }
        }

        private RelayCommand _cancelChangesCommand;

        /// <summary>
        /// Gets the CancelChangesCommand.
        /// </summary>
        public RelayCommand CancelChangesCommand
        {
            get
            {
                return _cancelChangesCommand
                    ?? (_cancelChangesCommand = new RelayCommand(
                    () =>
                    {
                        if (!CancelChangesCommand.CanExecute(null))
                        {
                            return;
                        }
                        IsSaved = true;
                        Account = Fill(ref _account, _backUp);
                    },
                    () => !IsSaved));
            }
        }

        private RelayCommand _addOrderCommand;

        /// <summary>
        /// Gets the AddOrderCommand.
        /// </summary>
        public RelayCommand AddOrderCommand
        {
            get
            {
                return _addOrderCommand
                    ?? (_addOrderCommand = new RelayCommand(
                    () =>
                    {
                        if (!AddOrderCommand.CanExecute(null))
                        {
                            return;
                        }

                        //InetOrders.Add(new InetOrder()
                        //    {
                        //        InetOrderID = _dataService.All<InetOrder>().Max(a => a.AccountID) +1,
                        //        CreatedAt = DateTime.Now,
                                
                        //    });
                    },
                    () => true));
            }
        }

        //public bool RefillCash(); //go to refill view
        //public bool PayCash();    //go to payment view
    }
}