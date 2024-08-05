using PhoneBoolWithFile1.Models;
using PhoneBoolWithFile1.Services;
using System;

namespace PhoneBoolWithFile1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();
            IContactStorage contactStorage = fileService.ContactStorage;
            ILoggingService loggingService = new LoggingServices();
            ContactService contactService = new ContactService(contactStorage, loggingService);

            loggingService.LogInformation("PhoneBook Application Started");

            string fileName = GetFileName(contactStorage);

            if (!contactStorage.Exists(fileName))
            {
                contactStorage.Save(fileName, new System.Collections.Generic.List<Contact>());
            }

            while (true)
            {
                loggingService.OptionsToChoose();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        contactService.CreateContact(fileName);
                        break;
                    case 2:
                        contactService.ReadContacts(fileName);
                        break;
                    case 3:
                        contactService.UpdateContact(fileName);
                        break;
                    case 4:
                        contactService.DeleteContact(fileName);
                        break;
                    case 5:
                        loggingService.LogInformation("PhoneBook Application Ended");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static string GetFileName(IContactStorage contactStorage)
        {
            return contactStorage is JsonContactStorage ? 
                "/Users/iskandarovs/RiderProjects/ConsoleApp4/ConsoleApp4/contacts.json" : 
                "/Users/iskandarovs/RiderProjects/ConsoleApp4/ConsoleApp4/contacts.txt";
        }
    }
}
