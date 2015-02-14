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
    public class ClientItemViewModel : TreeViewItemViewModel
    {
        private Client _client;

        /// <summary>
        /// Initializes a new instance of the ClientTreeViewModel class.
        /// </summary>
        public ClientItemViewModel(Client client) : base(null, true)
        {
            _client = client;
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", _client.LastName, _client.FirstName, _client.MiddleName);
            }
        }

        protected override void LoadChildren()
        {
            foreach (Account account in _client.Accounts)
                base.Children.Add(new AccountItemViewModel(account, this));
        }
    }
}