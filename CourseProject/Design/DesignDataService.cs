using System;
using System.Linq;
using System.Linq.Expressions;
using CourseProject.Model;
using System.Collections.Generic;

namespace CourseProject.Design
{
    public class DesignDataService : IDataService
    {
        private List<Client> _clients;
        private List<Refill> _refills;

        public DesignDataService()
        {
            _clients = new List<Client>();
            _refills = new List<Refill>();
            Client c = new Client()
            {
                ClientID = 1,
                Accounts = null,
                FirstName = "Nazar",
                LastName = "Matus",
                MiddleName = "Vovich",
                Password = "12345678",
                Phone = "0987655432",
                Username = "funky"
            };
            _clients.Add(c);
            Account a = new Account()
            {
                AccountID = 1,
                Client = c,
                ClientID = c.ClientID,
                Cash = 20,
                DebtCeiling = 0
            };
            Refill r = new Refill()
            {
                RefillID = 228,
                AccountID = a.AccountID,
                RefillTime = DateTime.Now,
                Cash = 100,
                Account = a
            };
            _refills.Add(r);
        }

        public IQueryable<T> All<T>() where T : class
        {
            if (typeof(T) == typeof(Client))
                return (IQueryable<T>)_clients.AsQueryable();
            if (typeof(T) == typeof(Refill))
                return (IQueryable<T>)_refills.AsQueryable();

            return null;
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {
            if (typeof(T) == typeof(Client))
                return (IQueryable<T>)_clients.AsQueryable();
            if (typeof(T) == typeof(Refill))
                return (IQueryable<T>)_refills.AsQueryable();

            return null;
        }

        public void Add<T>(T item) where T : class { }

        public void SaveChanges() { }

        public void Dispose() {}

        //public void GetData(Action<DataItem, Exception> callback)
        //{
        //    // Use this to create design time data

        //    var item = new DataItem("Welcome to MVVM Light [design]");
        //    callback(item, null);
        //}
    }
}