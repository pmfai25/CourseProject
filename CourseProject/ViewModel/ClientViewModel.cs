using CourseProject.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using PasswordSecurity;
using System.Linq;
using GalaSoft.MvvmLight.CommandWpf;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ClientViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private Client _backUp;

        /// <summary>
        /// Initializes a new instance of the ClientViewModel class.
        /// </summary>
        public ClientViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _client = new Client();
        }

        private Client Copy(Client client)
        {
            Client result = new Client();
            result.ClientID = client.ClientID;
            result.FirstName = client.FirstName;
            result.LastName = client.LastName;
            result.MiddleName = client.MiddleName;
            result.Password = client.Password;
            result.Phone = client.Phone;
            result.Username = client.Username;
            result.Accounts = client.Accounts;
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
        /// The <see cref="Client" /> property's name.
        /// </summary>
        public const string ClientPropertyName = "Client";

        private Client _client;

        /// <summary>
        /// Sets and gets the Client property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Client Client
        {
            get
            {
                return _client;
            }

            set
            {
                if (_client == value || !IsSaved)
                {
                    return;
                }

                _client = value;
                if (_dataService.All<Client>()
                    .Where(c => c.ClientID == _client.ClientID)
                    .Count() > 0)
                {
                    _backUp = Copy(_client);
                    IsSaved = true;
                }
                else
                {
                    IsSaved = false;
                }
                RaisePropertyChanged(ClientPropertyName);
                RaisePropertyChanged(LastNamePropertyName);
                RaisePropertyChanged(FirstNamePropertyName);
                RaisePropertyChanged(MiddleNamePropertyName);
                RaisePropertyChanged(PhonePropertyName);
            }
        }

        /// <summary>
        /// Gets the ClientID property.
        /// </summary>
        public int ClientID
        {
            get
            {
                return _client.ClientID;
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
                return _client.FirstName;
            }

            set
            {
                if (_client.FirstName == value)
                {
                    return;
                }

                _client.FirstName = value;
                IsSaved = false;
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
                return _client.MiddleName;
            }

            set
            {
                if (_client.MiddleName == value)
                {
                    return;
                }

                _client.MiddleName = value;
                IsSaved = false;
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
                return _client.LastName;
            }

            set
            {
                if (_client.LastName == value)
                {
                    return;
                }

                _client.LastName = value;
                IsSaved = false;
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
                return _client.Phone;
            }

            set
            {
                if (_client.Phone == value)
                {
                    return;
                }

                _client.Phone = value;
                IsSaved = false;
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
                return _client.Username;
            }

            set
            {
                if (_client.Username == value)
                {
                    return;
                }

                _client.Username = value;
                IsSaved = false;
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
                return _client.Password;
            }

            set
            {
                _client.Password = PasswordHash.CreateHash(value);
                IsSaved = false;
                RaisePropertyChanged(PasswordPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Accounts" /> property's name.
        /// </summary>
        public const string AccountsPropertyName = "Accounts";

        /// <summary>
        /// Sets and gets the Accounts property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ICollection<Account> Accounts
        {
            get
            {
                return _client.Accounts;
            }

            protected set
            {
                if (_client.Accounts == value)
                {
                    return;
                }

                _client.Accounts = value;
                IsSaved = false;
                RaisePropertyChanged(AccountsPropertyName);
            }
        }

    }
}