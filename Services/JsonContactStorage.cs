using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PhoneBoolWithFile1.Models;

namespace PhoneBoolWithFile1.Services
{
    public class JsonContactStorage : IContactStorage
    {
        public void Save(string fileName, List<Contact> contacts)
        {
            EnsureDirectoryExists(fileName);

            var json = JsonSerializer.Serialize(contacts);
            File.WriteAllText(fileName, json);
        }

        public void Append(string fileName, Contact contact)
        {
            EnsureDirectoryExists(fileName);

            var contacts = Read(fileName);
            contacts.Add(contact);
            Save(fileName, contacts);
        }

        public List<Contact> Read(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return new List<Contact>();
            }

            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Contact>>(json);
        }

        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }

        private void EnsureDirectoryExists(string fileName)
        {
            var directory = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}