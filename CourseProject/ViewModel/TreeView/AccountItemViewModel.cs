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
    public class AccountItemViewModel : TreeViewItemViewModel
    {
        private Account _account;

        /// <summary>
        /// Initializes a new instance of the AccountTreeViewModel class.
        /// </summary>
        public AccountItemViewModel(Account account, ClientItemViewModel parrentClient)
            : base(parrentClient, true)
        {
            _account = account;
        }

        public int AccountID
        {
            get
            {
                return _account.AccountID;
            }
        }

        public override object Instance
        {
            get
            {
                return _account;
            }
        }

        protected override void LoadChildren()
        {
            foreach (InetOrder order in _account.InetOrders)
                base.Children.Add(new InetOrderItemViewModel(order, this));
        }
    }
}