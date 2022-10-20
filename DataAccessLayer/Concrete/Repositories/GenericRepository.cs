using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _Object;           // T değerine karşılık gelen sınıfın yerini tutar

        public GenericRepository()
        {
            _Object = c.Set<T>();
        }

        public void Delete(T p)
        {
            _Object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            _Object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _Object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _Object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
