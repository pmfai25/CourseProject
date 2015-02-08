using CourseProject.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TariffViewModel : ViewModelBase
    {
        private Tariff _tariff;
        /// <summary>
        /// Initializes a new instance of the TariffViewModel class.
        /// </summary>
        public TariffViewModel(Tariff tariff)
        {
            _tariff = tariff;
        }

        /// <summary>
        /// The <see cref="TariffID" /> property's name.
        /// </summary>
        public const string TariffIDPropertyName = "TariffID";

        /// <summary>
        /// Sets and gets the TariffID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int TariffID
        {
            get
            {
                return _tariff.TariffID;
            }

            set
            {
                if (_tariff.TariffID == value)
                {
                    return;
                }

                _tariff.TariffID = value;
                RaisePropertyChanged(TariffIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TrafficLimit" /> property's name.
        /// </summary>
        public const string TrafficLimitPropertyName = "TrafficLimit";

        /// <summary>
        /// Sets and gets the TrafficLimit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<int> TrafficLimit
        {
            get
            {
                return _tariff.TrafficLimit;
            }

            set
            {
                if (_tariff.TrafficLimit == value)
                {
                    return;
                }

                _tariff.TrafficLimit = value;
                RaisePropertyChanged(TrafficLimitPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Speed" /> property's name.
        /// </summary>
        public const string SpeedPropertyName = "Speed";

        /// <summary>
        /// Sets and gets the Speed property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<int> Speed
        {
            get
            {
                return _tariff.Speed;
            }

            set
            {
                if (_tariff.Speed == value)
                {
                    return;
                }

                _tariff.Speed = value;
                RaisePropertyChanged(SpeedPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Price" /> property's name.
        /// </summary>
        public const string PricePropertyName = "Price";

        /// <summary>
        /// Sets and gets the Price property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<decimal> Price
        {
            get
            {
                return _tariff.Price;
            }

            set
            {
                if (_tariff.Price == value)
                {
                    return;
                }

                _tariff.Price = value;
                RaisePropertyChanged(PricePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TariffName" /> property's name.
        /// </summary>
        public const string TariffNamePropertyName = "TariffName";

        /// <summary>
        /// Sets and gets the TariffName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TariffName
        {
            get
            {
                return _tariff.TariffName;
            }

            set
            {
                if (_tariff.TariffName == value)
                {
                    return;
                }

                _tariff.TariffName = value;
                RaisePropertyChanged(TariffNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="InetOrders" /> property's name.
        /// </summary>
        public const string InetOrdersPropertyName = "InetOrders";

        /// <summary>
        /// Sets and gets the InetOrders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual ICollection<InetOrder> InetOrders
        {
            get
            {
                return _tariff.InetOrders;
            }

            set
            {
                if (_tariff.InetOrders == value)
                {
                    return;
                }

                _tariff.InetOrders = value;
                RaisePropertyChanged(InetOrdersPropertyName);
            }
        }
    }
}