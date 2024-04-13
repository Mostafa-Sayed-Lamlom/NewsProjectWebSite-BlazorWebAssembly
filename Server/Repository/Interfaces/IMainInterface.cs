using BlazorApp1.Shared.Models;

namespace BlazorApp1.Server.Repository.Interfaces
{
    public interface IMainInterface<T> where T : class
    {
        public IEnumerable<T> GetAll(string include = "");
        public T GetById(int id);
        public T Add(T item);
        public T UpdateById(T item);
        public void DeleteById(int id);
    }
}
