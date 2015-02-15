using CourseProject.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;

namespace CourseProject.ViewModel.TreeView
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EmployeeTreeViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private EmployeeViewModel _employeeVM;
        private InetOrderViewModel _inetOrderVM;

        /// <summary>
        /// Initializes a new instance of the EmployeeTreeViewModel class.
        /// </summary>
        public EmployeeTreeViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _employeeVM = ServiceLocator.Current.GetInstance<EmployeeViewModel>();
            _inetOrderVM = ServiceLocator.Current.GetInstance<InetOrderViewModel>();
        }

        /// <summary>
        /// The <see cref="Employees" /> property's name.
        /// </summary>
        public const string EmployeesPropertyName = "Employees";

        private List<EmployeeItemViewModel> _employees =
            new List<EmployeeItemViewModel>();


        /// <summary>
        /// Sets and gets the Employees property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<EmployeeItemViewModel> Employees
        {
            get
            {
                _employees.Clear();
                foreach (var e in _dataService.All<Employee>())
                {
                    _employees.Add(new EmployeeItemViewModel(e));
                }
                return _employees;
            }

            //set
            //{
            //    if (_employees == value)
            //    {
            //        return;
            //    }

            //    _employees = value;
            //    RaisePropertyChanged(EmployeesPropertyName);
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
                foreach (var e in _employees)
                {
                    selected = e.FindSelected();
                    if (selected != null)
                        break;
                }
                if (selected == null || selected.Instance == null)
                    return null;
                var instance = selected.Instance;
                var t = selected.GetType();
                if (selected.GetType() == typeof(EmployeeItemViewModel))
                {
                    _employeeVM.Employee = (Employee)instance;
                    return _employeeVM;
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