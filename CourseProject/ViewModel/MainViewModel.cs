using GalaSoft.MvvmLight;
using CourseProject.Model;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using CourseProject.ViewModel.TreeView;
using Microsoft.Practices.ServiceLocation;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IDataService _dataService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _modelNames = new ObservableCollection<string>() { "Client", "Tariff", "Address" };
            _clients = ServiceLocator.Current.GetInstance<ClientTreeViewModel>();
        }

        /// <summary>
        /// The <see cref="Clients" /> property's name.
        /// </summary>
        public const string ClientsPropertyName = "Clients";

        private ClientTreeViewModel _clients;

        /// <summary>
        /// Sets and gets the Clients property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ClientTreeViewModel Clients
        {
            get
            {
                return _clients;
            }

            set
            {
                if (_clients == value)
                {
                    return;
                }

                _clients = value;
                RaisePropertyChanged(ClientsPropertyName);
            }
        }

        private ObservableCollection<string> _modelNames;

        /// <summary>
        /// Gets the ModelNames property. 
        /// </summary>
        public ObservableCollection<string> ModelNames
        {
            get
            {
                return _modelNames;
            }
        }

        /// <summary>
        /// The <see cref="SelectedModel" /> property's name.
        /// </summary>
        public const string SelectedModelPropertyName = "SelectedModel";

        private string _selectedModel;

        /// <summary>
        /// Sets and gets the SelectedModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SelectedModel
        {
            get
            {
                return _selectedModel;
            }

            set
            {
                if (_selectedModel == value)
                {
                    return;
                }
                if (value == "Client")
                {
                    SelectedModelCollection = Clients;
                }
                //if (value == "Tariff")
                //{

                //}

                _selectedModel = value;
                RaisePropertyChanged(SelectedModelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SelectedModelCollection" /> property's name.
        /// </summary>
        public const string SelectedModelCollectionPropertyName = "SelectedModelCollection";

        private ViewModelBase _selectedModelCollection;

        /// <summary>
        /// Sets and gets the SelectedModelCollection property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ViewModelBase SelectedModelCollection
        {
            get
            {
                return _selectedModelCollection;
            }

            set
            {
                if (_selectedModelCollection == value)
                {
                    return;
                }

                _selectedModelCollection = value;
                RaisePropertyChanged(SelectedModelCollectionPropertyName);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}