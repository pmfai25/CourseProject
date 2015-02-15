using CourseProject.Model;
using GalaSoft.MvvmLight;

namespace CourseProject.ViewModel.TreeView
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EmployeeItemViewModel : TreeViewItemViewModel
    {
        private Employee _employee;

        /// <summary>
        /// Initializes a new instance of the EmployeeItemViewModel class.
        /// </summary>
        public EmployeeItemViewModel(Employee employee) : base(null, true)
        {
            _employee = employee;
        }

        public override object Instance
        {
            get
            {
                return _employee;
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", _employee.LastName, _employee.FirstName, _employee.MiddleName);
            }
        }

        protected override void LoadChildren()
        {
            foreach (InetOrder order in _employee.InetOrders)
                base.Children.Add(new InetOrderItemViewModel(order, this));
        }
    }
}