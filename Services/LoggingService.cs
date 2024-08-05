using System;

namespace PhoneBoolWithFile1.Services
{
    public class LoggingServices : ILoggingService
    {
        public void OptionsToChoose()
        {
            Console.WriteLine("\nPhoneBook Menu:");
            Console.WriteLine("1. Create Contact");
            Console.WriteLine("2. Read Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
        }

        public void LogInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}