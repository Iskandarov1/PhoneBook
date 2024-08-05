using PhoneBoolWithFile1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBoolWithFile1.Services
{
    public class ContactService
    {
        private readonly IContactStorage _contactStorage;
        private readonly ILoggingService _loggingService;

        public ContactService(IContactStorage contactStorage, ILoggingService loggingService)
        {
            _contactStorage = contactStorage;
            _loggingService = loggingService;
        }

        public void CreateContact(string fileName)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            var newContact = new Contact { Name = name, PhoneNumber = phoneNumber };
            _contactStorage.Append(fileName, newContact);

            _loggingService.LogInformation($"Contact {name} created successfully.");
        }

        public void ReadContacts(string fileName)
        {
            var contacts = _contactStorage.Read(fileName);
            Console.WriteLine("\nContacts:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
        }

        public void UpdateContact(string fileName)
        {
            var contacts = _contactStorage.Read(fileName);

            Console.Write("Enter the name of the contact to update: ");
            string nameToUpdate = Console.ReadLine();

            var contact = contacts.FirstOrDefault(c => c.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                Console.Write("Enter new Phone Number: ");
                string newPhoneNumber = Console.ReadLine();

                contact.PhoneNumber = newPhoneNumber;
                _contactStorage.Save(fileName, contacts);

                _loggingService.LogInformation($"Contact {nameToUpdate} updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DeleteContact(string fileName)
        {
            var contacts = _contactStorage.Read(fileName);

            Console.Write("Enter the name of the contact to delete: ");
            string nameToDelete = Console.ReadLine();

            var contact = contacts.FirstOrDefault(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                contacts.Remove(contact);
                _contactStorage.Save(fileName, contacts);

                _loggingService.LogInformation($"Contact {nameToDelete} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
