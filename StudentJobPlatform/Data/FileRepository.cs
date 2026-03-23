using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentJobPlatform.Data
{
    public class FileRepository<T> : IRepository<T>
    {
        private readonly string _filePath;
        private readonly List<T> _items;

        public FileRepository(string filePath)
        {
            _filePath = filePath;
            _items = LoadFromFile();
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
            var lines = _items.Select(item => item!.ToString()).ToList();
            File.WriteAllLines(_filePath, lines);
        }

        private List<T> LoadFromFile()
        {
            var items = new List<T>();

            if (!File.Exists(_filePath))
                return items;

            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (typeof(T).Name == "Job")
                {
                    var parts = line.Split(',');

                    var job = (T)Activator.CreateInstance(
                        typeof(T),
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2],
                        parts[3],
                        parts[4],
                        parts[5],
                        decimal.Parse(parts[6]),
                        int.Parse(parts[7])
                    )!;

                    items.Add(job);
                }
            }

            return items;
        }
    }
}