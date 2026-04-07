using System.Text.Json;

namespace StudentJobPlatform.Data
{
    public class FileRepository<T> : IRepository<T> where T : class
    {
        private readonly string _filePath;
        private readonly List<T> _items;

        public FileRepository(string filePath)
        {
            _filePath = filePath;

            if (string.IsNullOrWhiteSpace(_filePath))
                throw new ArgumentException("File path is invalid.");

            if (!File.Exists(_filePath))
            {
                try
                {
                    File.WriteAllText(_filePath, "[]");
                }
                catch
                {
                    Console.WriteLine("File nuk u gjet, po krijoj file të ri.");
                }
            }

            _items = LoadFromFile();
        }

        public List<T> GetAll()
        {
            return _items.ToList();
        }

        public T? GetById(int id)
        {
            var property = typeof(T).GetProperty("Id");
            if (property == null)
                return null;

            return _items.FirstOrDefault(item =>
            {
                var value = property.GetValue(item);
                return value != null && (int)value == id;
            });
        }

        public void Add(T item)
        {
            if (item == null)
                return;

            _items.Add(item);
        }

        public void Update(T item)
        {
            if (item == null)
                return;

            var property = typeof(T).GetProperty("Id");
            if (property == null)
                return;

            var value = property.GetValue(item);
            if (value == null)
                return;

            int id = (int)value;

            var existingItem = GetById(id);
            if (existingItem == null)
                return;

            int index = _items.IndexOf(existingItem);
            if (index >= 0)
            {
                _items[index] = item;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item == null)
                return;

            _items.Remove(item);
        }

        public void Save()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(_items, options);
                File.WriteAllText(_filePath, json);
            }
            catch
            {
                Console.WriteLine("Gabim gjatë ruajtjes së file.");
            }
        }

        private List<T> LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return new List<T>();

                string json = File.ReadAllText(_filePath);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<T>();

                var data = JsonSerializer.Deserialize<List<T>>(json);

                return data ?? new List<T>();
            }
            catch
            {
                Console.WriteLine("Gabim gjatë leximit të file. Po përdoret listë e zbrazët.");
                return new List<T>();
            }
        }
    }
}
