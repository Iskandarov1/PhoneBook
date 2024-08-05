using System.Collections.Generic;
using System.IO;
using PhoneBoolWithFile1.Models;

namespace PhoneBoolWithFile1.Services
{
    public class FileContactStorage : IContactStorage
    {
        public void Save(string fileName, List<Contact> contacts)
        {
            EnsureDirectoryExists(fileName);

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var contact in contacts)
                {
                    sw.WriteLine($"{contact.Name},{contact.PhoneNumber}");
                }
            }
        }

        public void Append(string fileName, Contact contact)
        {
            EnsureDirectoryExists(fileName);

            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine($"{contact.Name},{contact.PhoneNumber}");
            }
        }

        public List<Contact> Read(string fileName)
        {
            var contacts = new List<Contact>();
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            contacts.Add(new Contact { Name = parts[0], PhoneNumber = parts[1] });
                        }
                    }
                }
            }
            return contacts;
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