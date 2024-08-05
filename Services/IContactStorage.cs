using System.Collections.Generic;
using PhoneBoolWithFile1.Models;

namespace PhoneBoolWithFile1.Services
{
    public interface IContactStorage
    {
        void Save(string fileName, List<Contact> contacts);
        void Append(string fileName, Contact contact);
        List<Contact> Read(string fileName);
        bool Exists(string fileName);
    }
}