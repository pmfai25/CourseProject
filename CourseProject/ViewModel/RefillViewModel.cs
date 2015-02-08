using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RefillViewModel : ViewModelBase
    {
        private Refill _refill;

        /// <summary>
        /// Initializes a new instance of the RefillViewModel class.
        /// </summary>
        public RefillViewModel(Refill refill)
        {
            _refill = refill;
        }

        /// <summary>
        /// The <see cref="RefillID" /> property's name.
        /// </summary>
        public const string RefillIDPropertyName = "RefillID";

        /// <summary>
        /// Sets and gets the RefillID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int RefillID
        {
            get
            {
                return _refill.RefillID;
            }

            set
            {
                if (_refill.RefillID == value)
                {
                    return;
                }

                _refill.RefillID = value;
                RaisePropertyChanged(RefillIDPropertyName);
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
                return _refill.AccountID;
            }

            set
            {
                if (_refill.AccountID == value)
                {
                    return;
                }

                _refill.AccountID = value;
                RaisePropertyChanged(AccountIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="RefillTime" /> property's name.
        /// </summary>
        public const string RefillTimePropertyName = "RefillTime";

        /// <summary>
        /// Sets and gets the RefillTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<System.DateTime> RefillTime
        {
            get
            {
                return _refill.RefillTime;
            }

            set
            {
                if (_refill.RefillTime == value)
                {
                    return;
                }

                _refill.RefillTime = value;
                RaisePropertyChanged(RefillTimePropertyName);
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
                return _refill.Cash;
            }

            set
            {
                if (_refill.Cash == value)
                {
                    return;
                }

                _refill.Cash = value;
                RaisePropertyChanged(CashPropertyName);
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
                return _refill.Account;
            }

            set
            {
                if (_refill.Account == value)
                {
                    return;
                }

                _refill.Account = value;
                RaisePropertyChanged(AccountPropertyName);
            }
        }
    }
}