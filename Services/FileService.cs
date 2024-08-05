using System;
using PhoneBoolWithFile1.Models;
using PhoneBoolWithFile1.Services;

namespace PhoneBoolWithFile1
{
    public class FileService
    {
        private readonly IContactStorage _contactStorage;

        public FileService()
        {
            _contactStorage = ChooseStorageMethod();
        }

        public IContactStorage ContactStorage => _contactStorage;

        private IContactStorage ChooseStorageMethod()
        {
            Console.WriteLine("Choose storage method:");
            Console.WriteLine("1. Plain Text File");
            Console.WriteLine("2. JSON File");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            return choice switch
            {
                1 => new FileContactStorage(),
                2 => new JsonContactStorage(),
                _ => throw new InvalidOperationException("Invalid choice")
            };
        }
    }
}