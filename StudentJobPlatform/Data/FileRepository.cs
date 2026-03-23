using System.Collections.Generic;
using System.Linq;

namespace StudentJobPlatform.Data
{
    public class FileRepository<T> : IRepository<T>
    {
        private List<T> _items;

        public FileRepository()
        {
            _items = new List<T>();
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T? GetById(int id)
        {
            return _items.FirstOrDefault(item =>
            {
                var property = item!.GetType().GetProperty("Id");
                if (property == null) return false;

                int value = (int)property.GetValue(item)!;
                return value == id;
            });
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            // për këtë projekt, nuk ruajmë në file real
            // mjafton struktura për detyrë
        }
    }
}