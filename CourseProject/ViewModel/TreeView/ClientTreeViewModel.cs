using CourseProject.Model;
using CourseProject.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using System.Collections.ObjectModel;

namespace CourseProject.ViewModel.TreeView
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ClientTreeViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private ClientViewModel _clientVM;
        private AccountViewModel _accountVM;
        private InetOrderViewModel _inetOrderVM;

        /// <summary>
        /// Initializes a new instance of the FilteredClientsViewModel class.
        /// </summary>
        public ClientTreeViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _clientVM = ServiceLocator.Current.GetInstance<ClientViewModel>();
            _accountVM = ServiceLocator.Current.GetInstance<AccountViewModel>();
            _inetOrderVM = ServiceLocator.Current.GetInstance<InetOrderViewModel>();
        }

        /// <summary>
        /// The <see cref="Clients" /> property's name.
        /// </summary>
        public const string ClientsPropertyName = "Clients";

        private ObservableCollection<ClientItemViewModel> _clients =
            new ObservableCollection<ClientItemViewModel>();

        /// <summary>
        /// Sets and gets the Clients property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ClientItemViewModel> Clients
        {
            get
            {
                _clients.Clear();
                foreach (var c in _dataService.All<Client>())
                {
                    _clients.Add(new ClientItemViewModel(c));
                }
                return _clients;
            }

            //set
            //{
            //    if (_clients == value)
            //    {
            //        return;
            //    }

            //    _clients = value;
            //    RaisePropertyChanged(ClientsPropertyName);
            //}
        }

        /// <summary>
        /// The <see cref="SelectedItem" /> property's name.
        /// </summary>
        public const string SelectedItemPropertyName = "SelectedItem";

        //private ViewModelBase _selectedItem;

        /// <summary>
        /// Sets and gets the SelectedItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ViewModelBase SelectedItem
        {
            get
            {
                TreeViewItemViewModel selected = null;
                foreach (var c in _clients)
                {
                    selected = c.FindSelected();
                    if (selected != null)
                        break;
                }
                if (selected == null || selected.Instance == null)
                    return null;
                var instance = selected.Instance;
                var t = selected.GetType();
                if (selected.GetType() == typeof(ClientItemViewModel))
                {
                    _clientVM.Client = (Client)instance;
                    return _clientVM;
                }
                if (selected.GetType() == typeof(AccountItemViewModel))
                {
                    _accountVM.Account = (Account)instance;
                    return _accountVM;
                }
                if (selected.GetType() == typeof(InetOrderItemViewModel))
                {
                    _inetOrderVM.InetOrder = (InetOrder)instance;
                    return _inetOrderVM;
                }
                return null;
            }
        }

        private RelayCommand _selectItemCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SelectItemCommand
        {
            get
            {
                return _selectItemCommand
                    ?? (_selectItemCommand = new RelayCommand(
                    () =>
                    {
                        RaisePropertyChanged(SelectedItemPropertyName);
                    }));
            }
        }
    }
}