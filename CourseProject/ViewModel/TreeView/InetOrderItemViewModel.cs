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
    public class InetOrderItemViewModel : TreeViewItemViewModel
    {
        private InetOrder _inetOrder;

        /// <summary>
        /// Initializes a new instance of the InetOrderTreeViewModel class.
        /// </summary>
        public InetOrderItemViewModel(InetOrder inetOrder, AccountItemViewModel parrentAccount)
            : base(parrentAccount, false)
        {
            _inetOrder = inetOrder;
        }

        public int InetOrderID
        {
            get
            {
                return _inetOrder.InetOrderID;
            }
        }

        public override object Instance
        {
            get
            {
                return _inetOrder;
            }
        }
    }
}