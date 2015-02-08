using CourseProject.Model;
using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace CourseProject.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AddressViewModel : ViewModelBase
    {
        private Address _address;
        /// <summary>
        /// Initializes a new instance of the AddressViewModel class.
        /// </summary>
        public AddressViewModel(Address address)
        {
            _address = address;
        }

        /// <summary>
        /// The <see cref="AddressID" /> property's name.
        /// </summary>
        public const string AddressIDPropertyName = "AddressID";

        /// <summary>
        /// Sets and gets the AddressID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int AddressID
        {
            get
            {
                return _address.AddressID;
            }

            set
            {
                if (_address.AddressID == value)
                {
                    return;
                }

                _address.AddressID = value;
                RaisePropertyChanged(AddressIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="City" /> property's name.
        /// </summary>
        public const string CityPropertyName = "City";

        /// <summary>
        /// Sets and gets the City property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string City
        {
            get
            {
                return _address.City;
            }

            set
            {
                if (_address.City == value)
                {
                    return;
                }

                _address.City = value;
                RaisePropertyChanged(CityPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Street" /> property's name.
        /// </summary>
        public const string StreetPropertyName = "Street";

        /// <summary>
        /// Sets and gets the Street property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Street
        {
            get
            {
                return _address.Street;
            }

            set
            {
                if (_address.Street == value)
                {
                    return;
                }

                _address.Street = value;
                RaisePropertyChanged(StreetPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="StreetNumber" /> property's name.
        /// </summary>
        public const string StreetNumberPropertyName = "StreetNumber";

        /// <summary>
        /// Sets and gets the StreetNumber property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StreetNumber
        {
            get
            {
                return _address.StreetNumber;
            }

            set
            {
                if (_address.StreetNumber == value)
                {
                    return;
                }

                _address.StreetNumber = value;
                RaisePropertyChanged(StreetNumberPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Flat" /> property's name.
        /// </summary>
        public const string FlatPropertyName = "Flat";

        /// <summary>
        /// Sets and gets the Flat property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Flat
        {
            get
            {
                return _address.Flat;
            }

            set
            {
                if (_address.Flat == value)
                {
                    return;
                }

                _address.Flat = value;
                RaisePropertyChanged(FlatPropertyName);
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
                return _address.InetOrders;
            }

            set
            {
                if (_address.InetOrders == value)
                {
                    return;
                }

                _address.InetOrders = value;
                RaisePropertyChanged(InetOrdersPropertyName);
            }
        }
    }
}