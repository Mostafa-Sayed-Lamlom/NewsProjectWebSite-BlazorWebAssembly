using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Repository
{
    public class MainRepository<T> : IMainInterface<T> where T : class
    {
        private readonly AppDbContext _db;
        public MainRepository(AppDbContext db)
        {
            _db = db;
        }
        public T Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
            return item;
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll(string include = "")
        {
            IQueryable<T> myQuery = _db.Set<T>();
            if(include != "")
            {
                myQuery = myQuery.Include(include);
            }
            return myQuery.ToList();
        }

        public T GetById(int id)
        {
            var item = _db.Set<T>().Find(id);
            return item;
        }

        public T UpdateById(T item)
        {
            DbSet<T> ts = _db.Set<T>();
            ts.Attach(item);
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return item;
        }
    }
}
