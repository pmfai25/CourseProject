using System;
using System.Linq;
using System.Linq.Expressions;
//using System.Text;
//using System.Collections.Generic;

namespace CourseProject.Model
{
    public interface IDataService : IDisposable
    {
        //void GetData(Action<DataItem, Exception> callback);
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class;
    }
}
