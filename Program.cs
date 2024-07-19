using PhoneBoolWithFile1.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBoolWithFile1
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileService fileService = new FileService();
            ILoggingService loggingService = new LoggingServices();
            
            loggingService.LogInformation("PhoneBook Application Started");

            string fileName = "/Users/iskandarovs/RiderProjects/ConsoleApp4/ConsoleApp4/Text.rtf";

            if (!fileService.Exists(fileName))
            {
                fileService.Save(fileName, "Name,PhoneNumber\n");
            }
            
            while (true)
            {
                loggingService.OptionsToChoose();

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateContact(fileService, loggingService, fileName);
                        break;
                    case 2:
                        ReadContacts(fileService, loggingService, fileName);
                        break;
                    case 3:
                        UpdateContact(fileService, loggingService, fileName);
                        break;
                    case 4:
                        DeleteContact(fileService, loggingService, fileName);
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

        static void CreateContact(IFileService fileService, ILoggingService loggingService, string fileName)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            string newContact = $"{name},{phoneNumber}\n";
            fileService.Append(fileName, newContact);

            loggingService.LogInformation($"Contact {name} created successfully.");
        }

        static void ReadContacts(IFileService fileService, ILoggingService loggingService, string fileName)
        {
            string content = fileService.Read(fileName);
            Console.WriteLine("\nContacts:");
            Console.WriteLine(content);
        }

        static void UpdateContact(IFileService fileService, ILoggingService loggingService, string fileName)
        {
            string content = fileService.Read(fileName);
            
            var contacts = content.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            Console.Write("Enter the name of the contact to update: ");
            string nameToUpdate = Console.ReadLine();

            var contact = contacts.FirstOrDefault(c => c.StartsWith(nameToUpdate + ","));
            if (contact != null)
            {
                Console.Write("Enter new Phone Number: ");
                string newPhoneNumber = Console.ReadLine();

                contacts[contacts.IndexOf(contact)] = $"{nameToUpdate},{newPhoneNumber}";
                fileService.Save(fileName, string.Join("\n", contacts) + "\n");

                loggingService.LogInformation($"Contact {nameToUpdate} updated successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void DeleteContact(IFileService fileService, ILoggingService loggingService, string fileName)
        {
            string content = fileService.Read(fileName);
            var contacts = content.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToList();

            Console.Write("Enter the name of the contact to delete: ");
            string nameToDelete = Console.ReadLine();

            var contact = contacts.FirstOrDefault(c => c.StartsWith(nameToDelete + ","));
            if (contact != null)
            {
                contacts.Remove(contact);
                fileService.Save(fileName, string.Join("\n", contacts) + "\n");

                loggingService.LogInformation($"Contact {nameToDelete} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}
