using System.Collections.Generic;
using System.Linq;

namespace StudentJobPlatform.Data
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly List<T> _items = new List<T>();

        public List<T> GetAll() => _items;

        public T? GetById(int id)
        {
            return _items.FirstOrDefault(item =>
            {
                var prop = item!.GetType().GetProperty("Id");
                return prop != null && (int)prop.GetValue(item)! == id;
            });
        }

        public void Add(T item) => _items.Add(item);

        public void Update(T item) { }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
                _items.Remove(item);
        }

        public void Save() { }
    }
}