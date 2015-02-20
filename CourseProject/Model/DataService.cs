using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CourseProject.Model
{
    public class DataService : IDataService
    {
        private InetProviderEntities _entities;

        public DataService()
        {
            _entities = new InetProviderEntities();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return _entities.Set<T>();
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {
            IQueryable<T> result = _entities.Set<T>();
            foreach (var item in include)
            {
                result = result.Include(item);
            }
            return result;
        }

        public void Add<T>(T item) where T : class 
        {

            _entities.Set<T>().Add(item);
        }

        public void SaveChanges()
        {
            _entities.SaveChanges();
        }

        public void Dispose()
        {
            if (_entities != null) _entities.Dispose();
        }

        //public void GetData(Action<DataItem, Exception> callback)
        //{
        //    // Use this to connect to the actual data service

        //    var item = new DataItem("Welcome to MVVM Light");
        //    callback(item, null);
        //}
    }
}