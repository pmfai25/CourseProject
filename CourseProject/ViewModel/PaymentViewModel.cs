using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;
using System.Linq;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PaymentViewModel : ViewModelBase
    {
        private Payment _payment;
        private IDataService _dataService;
        /// <summary>
        /// Initializes a new instance of the PaymentViewModel class.
        /// </summary>
        public PaymentViewModel(IDataService dataService, Payment payment)
        {
            _payment = payment;
            _dataService = dataService;
            //move next code to save command
            if (!_dataService.All<Payment>().Contains(_payment))
                PaymentTime = DateTime.Now;
        }

        /// <summary>
        /// Gets the PaymentID property.
        /// </summary>
        public int PaymentID
        {
            get
            {
                return _payment.PaymentID;
            }
        }

        /// <summary>
        /// The <see cref="OrderID" /> property's name.
        /// </summary>
        public const string OrderIDPropertyName = "OrderID";

        /// <summary>
        /// Sets and gets the OrderID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OrderID
        {
            get
            {
                return _payment.OrderID;
            }

            set
            {
                if (_payment.OrderID == value ||
                    value <= 0 ||
                    _dataService.All<InetOrder>()
                    .Where(o => o.InetOrderID == value)
                    .Count() < 1)
                {
                    return;
                }
                if (InetOrder != null)
                    InetOrder.Payments.Remove(_payment);
                InetOrder = _dataService.All<InetOrder>()
                    .Where(o => o.InetOrderID == value).Single();
                InetOrder.Payments.Add(_payment);
                RaisePropertyChanged(OrderIDPropertyName);
            }
        }

        /// <summary>
        /// Gets the PaymentTime property. 
        /// </summary>
        public Nullable<System.DateTime> PaymentTime
        {
            get
            {
                return _payment.PaymentTime;
            }

            protected set
            {
                _payment.PaymentTime = value;
            }
        }

        /// <summary>
        /// The <see cref="Cash" /> property's name.
        /// </summary>
        public const string CashPropertyName = "Cash";

        /// <summary>
        /// Sets and gets the Cash property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<decimal> Cash
        {
            get
            {
                return _payment.Cash;
            }

            set
            {
                if (_payment.Cash == value)
                {
                    return;
                }

                _payment.Cash = value;
                RaisePropertyChanged(CashPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="InetOrder" /> property's name.
        /// </summary>
        public const string InetOrderPropertyName = "InetOrder";

        /// <summary>
        /// Sets and gets the InetOrder property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public InetOrder InetOrder
        {
            get
            {
                return _payment.InetOrder;
            }

            protected set
            {
                if (_payment.InetOrder == value)
                {
                    return;
                }

                _payment.InetOrder = value;
                RaisePropertyChanged(InetOrderPropertyName);
            }
        }
    }
}