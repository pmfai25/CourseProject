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
    public class PositionViewModel : ViewModelBase
    {
        private Position _position;
        /// <summary>
        /// Initializes a new instance of the PositionViewModel class.
        /// </summary>
        public PositionViewModel(Position position)
        {
            _position = position;
        }

        /// <summary>
        /// The <see cref="PositionID" /> property's name.
        /// </summary>
        public const string PositionIDPropertyName = "PositionID";

        /// <summary>
        /// Sets and gets the PositionID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PositionID
        {
            get
            {
                return _position.PositionID;
            }

            set
            {
                if (_position.PositionID == value)
                {
                    return;
                }

                _position.PositionID = value;
                RaisePropertyChanged(PositionIDPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="PositionName" /> property's name.
        /// </summary>
        public const string PositionNamePropertyName = "PositionName";

        /// <summary>
        /// Sets and gets the PositionName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PositionName
        {
            get
            {
                return _position.PositionName;
            }

            set
            {
                if (_position.PositionName == value)
                {
                    return;
                }

                _position.PositionName = value;
                RaisePropertyChanged(PositionNamePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Salary" /> property's name.
        /// </summary>
        public const string SalaryPropertyName = "Salary";

        /// <summary>
        /// Sets and gets the Salary property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Nullable<decimal> Salary
        {
            get
            {
                return _position.Salary;
            }

            set
            {
                if (_position.Salary == value)
                {
                    return;
                }

                _position.Salary = value;
                RaisePropertyChanged(SalaryPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Employees" /> property's name.
        /// </summary>
        public const string EmployeesPropertyName = "Employees";

        /// <summary>
        /// Sets and gets the Employees property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public virtual ICollection<Employee> Employees
        {
            get
            {
                return _position.Employees;
            }

            //protected set
            //{
            //    if (_position.Employees == value)
            //    {
            //        return;
            //    }

            //    _position.Employees = value;
            //    RaisePropertyChanged(EmployeesPropertyName);
            //}
        }
    }
}