﻿using CourseProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FilteredClientsViewModel : ViewModelBase
    {
        private IDataService _dataService;
        /// <summary>
        /// Initializes a new instance of the FilteredClientsViewModel class.
        /// </summary>
        public FilteredClientsViewModel(IDataService dataService)
        {
            _dataService = dataService;
            //_clients = clients;
        }

        /// <summary>
        /// The <see cref="Clients" /> property's name.
        /// </summary>
        public const string ClientsPropertyName = "Clients";

        private ObservableCollection<ClientViewModel> _clients =
            new ObservableCollection<ClientViewModel>();

        /// <summary>
        /// Sets and gets the Clients property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                _clients.Clear();
                foreach (var c in _dataService.All<Client>())
                {
                    _clients.Add(new ClientViewModel(c));
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

        private ViewModelBase _selectedItem;

        /// <summary>
        /// Sets and gets the SelectedItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ViewModelBase SelectedItem
        {
            get
            {
                foreach(var c in _clients)
                {
                    _selectedItem = c.FindSelected();
                    if (_selectedItem != null)
                        return _selectedItem;
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