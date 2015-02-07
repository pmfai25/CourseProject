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

        public DesignDataService()
        {
            _clients = new List<Client>();
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
        }

        public IQueryable<T> All<T>() where T : class
        {
            if (typeof(T) == typeof(Client))
                return (IQueryable<T>)_clients.AsQueryable();

            return null;
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {
            if (typeof(T) == typeof(Client))
                return (IQueryable<T>)_clients.AsQueryable();

            return null;
        }

        public void Dispose() {}

        //public void GetData(Action<DataItem, Exception> callback)
        //{
        //    // Use this to create design time data

        //    var item = new DataItem("Welcome to MVVM Light [design]");
        //    callback(item, null);
        //}
    }
}