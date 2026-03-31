using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            Save();
        }

        public void Update(T item)
        {
            var property = item!.GetType().GetProperty("Id");
            if (property == null) return;

            int id = (int)property.GetValue(item)!;

            for (int i = 0; i < _items.Count; i++)
            {
                var currentProperty = _items[i]!.GetType().GetProperty("Id");
                if (currentProperty == null) continue;

                int currentId = (int)currentProperty.GetValue(_items[i])!;
                if (currentId == id)
                {
                    _items[i] = item;
                    Save();
                    return;
                }
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return;

            _items.Remove(item);
            Save();
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

                var parts = line.Split(',');

                if (typeof(T).Name == "User")
                {
                    var user = (T)Activator.CreateInstance(
                        typeof(T),
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2],
                        parts[3],
                        parts[4]
                    )!;

                    var type = user.GetType();

                    var fieldMajor = type.GetField("_major", BindingFlags.NonPublic | BindingFlags.Instance);
                    var fieldSkills = type.GetField("_skills", BindingFlags.NonPublic | BindingFlags.Instance);
                    var fieldAvailability = type.GetField("_availability", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (parts.Length > 5 && fieldMajor != null)
                        fieldMajor.SetValue(user, parts[5]);

                    if (parts.Length > 6 && fieldSkills != null)
                        fieldSkills.SetValue(user, parts[6]);

                    if (parts.Length > 7 && fieldAvailability != null)
                        fieldAvailability.SetValue(user, parts[7]);

                    items.Add(user);
                }
                else if (typeof(T).Name == "Job")
                {
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
                else if (typeof(T).Name == "Application")
                {
                    var application = (T)Activator.CreateInstance(
                        typeof(T),
                        int.Parse(parts[0]),
                        int.Parse(parts[1]),
                        int.Parse(parts[2]),
                        DateTime.Parse(parts[3])
                    )!;

                    var fieldStatus = application.GetType().GetField("_status", BindingFlags.NonPublic | BindingFlags.Instance);

                    if (parts.Length > 4 && fieldStatus != null)
                        fieldStatus.SetValue(application, parts[4]);

                    items.Add(application);
                }
            }

            return items;
        }
    }
}
