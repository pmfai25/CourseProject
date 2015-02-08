using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;

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
        /// <summary>
        /// Initializes a new instance of the PaymentViewModel class.
        /// </summary>
        public PaymentViewModel(Payment payment)
        {
            _payment = payment;
        }

        /// <summary>
        /// The <see cref="PaymentID" /> property's name.
        /// </summary>
        public const string PaymentIDPropertyName = "PaymentID";

        /// <summary>
        /// Sets and gets the PaymentID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PaymentID
        {
            get
            {
                return _payment.PaymentID;
            }

            set
            {
                if (_payment.PaymentID == value)
                {
                    return;
                }

                _payment.PaymentID = value;
                RaisePropertyChanged(PaymentIDPropertyName);
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
                if (_payment.OrderID == value)
                {
                    return;
                }

                _payment.OrderID = value;
                RaisePropertyChanged(OrderIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="PaymentTime" /> property's name.
        /// </summary>
        public const string PaymentTimePropertyName = "PaymentTime";

        /// <summary>
        /// Sets and gets the PaymentTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<System.DateTime> PaymentTime
        {
            get
            {
                return _payment.PaymentTime;
            }

            set
            {
                if (_payment.PaymentTime == value)
                {
                    return;
                }

                _payment.PaymentTime = value;
                RaisePropertyChanged(PaymentTimePropertyName);
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
        public virtual InetOrder InetOrder
        {
            get
            {
                return _payment.InetOrder;
            }

            set
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