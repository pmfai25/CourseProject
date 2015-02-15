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
            _modelNames = new List<string>() { "Client", "Employee", "Tariff", "Address" };
            _clientTree = ServiceLocator.Current.GetInstance<ClientTreeViewModel>();
            _employeeTree = ServiceLocator.Current.GetInstance<EmployeeTreeViewModel>();
        }

        /// <summary>
        /// The <see cref="ClientTree" /> property's name.
        /// </summary>
        public const string ClientsPropertyName = "Clients";

        private ClientTreeViewModel _clientTree;

        /// <summary>
        /// Sets and gets the Clients property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ClientTreeViewModel ClientTree
        {
            get
            {
                return _clientTree;
            }

            set
            {
                if (_clientTree == value)
                {
                    return;
                }

                _clientTree = value;
                RaisePropertyChanged(ClientsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="EmployeeTree" /> property's name.
        /// </summary>
        public const string EmployeeTreePropertyName = "EmployeeTree";

        private EmployeeTreeViewModel _employeeTree;

        /// <summary>
        /// Sets and gets the EmployeeTree property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public EmployeeTreeViewModel EmployeeTree
        {
            get
            {
                return _employeeTree;
            }

            set
            {
                if (_employeeTree == value)
                {
                    return;
                }

                _employeeTree = value;
                RaisePropertyChanged(EmployeeTreePropertyName);
            }
        }

        private List<string> _modelNames;

        /// <summary>
        /// Gets the ModelNames property. 
        /// </summary>
        public List<string> ModelNames
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
                if (value == _modelNames[0])
                {
                    SelectedModelTree = _clientTree;
                }
                if (value == _modelNames[1])
                {
                    SelectedModelTree = _employeeTree;
                }

                _selectedModel = value;
                RaisePropertyChanged(SelectedModelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SelectedModelTree" /> property's name.
        /// </summary>
        public const string SelectedModelTreePropertyName = "SelectedModelTree";

        private ViewModelBase _selectedModelTree;

        /// <summary>
        /// Sets and gets the SelectedModelCollection property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ViewModelBase SelectedModelTree
        {
            get
            {
                return _selectedModelTree;
            }

            set
            {
                if (_selectedModelTree == value)
                {
                    return;
                }

                _selectedModelTree = value;
                RaisePropertyChanged(SelectedModelTreePropertyName);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}