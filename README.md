# PhoneBook Application

## Overview

The PhoneBook application is a simple console-based contacts manager written in C#. It allows users to create, read, update, and delete contacts stored in a file. The application demonstrates the use of interfaces for file operations and logging, promoting modular and maintainable code.

## Features

- **Create Contact**: Add a new contact to the phone book.
- **Read Contacts**: Display all contacts stored in the phone book.
- **Update Contact**: Update the phone number of an existing contact.
- **Delete Contact**: Remove a contact from the phone book.
- **Logging**: Log important actions and display menu options to the user.

## Structure

The project consists of the following files:

- `Program.cs`: The main entry point of the application. Contains the main loop and user interaction logic.
- `FileService.cs`: Implements file operations (read, write, append, delete, exists) through the `IFileService` interface.
- `LoggingService.cs`: Implements logging operations through the `ILoggingService` interface.
- `IFileService.cs`: Interface defining file operations.
- `ILoggingService.cs`: Interface defining logging operations.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)

### Running the Application

1. Clone the repository:
    ```sh
    git clone https://github.com/Iskandarov1/PhoneBook.git
    cd PhoneBook
    ```

2. Build the project:
    ```sh
    dotnet build
    ```

3. Run the application:
    ```sh
    dotnet run
    ```

### Usage

Upon running the application, you will be presented with a menu:

```
PhoneBook Menu:
1. Create Contact
2. Read Contacts
3. Update Contact
4. Delete Contact
5. Exit
Select an option:
```

- **Create Contact**: Follow the prompts to enter the name and phone number of the new contact.
- **Read Contacts**: Display all contacts stored in the phone book.
- **Update Contact**: Enter the name of the contact to update and provide the new phone number.
- **Delete Contact**: Enter the name of the contact to delete.

### Example

#### Creating a Contact
```
Enter Name: John Doe
Enter Phone Number: 123-456-7890
Contact John Doe created successfully.
```

#### Reading Contacts
```
Contacts:
John Doe,123-456-7890
```

#### Updating a Contact
```
Enter the name of the contact to update: John Doe
Enter new Phone Number: 098-765-4321
Contact John Doe updated successfully.
```

#### Deleting a Contact
```
Enter the name of the contact to delete: John Doe
Contact John Doe deleted successfully.
```

## Implementation Details

### Interfaces

#### IFileService.cs
Defines the methods for file operations:
```csharp
public interface IFileService
{
    void Save(string fileName, string data);
    void Append(string fileName, string data);
    string Read(string fileName);
    void Delete(string fileName);
    bool Exists(string fileName);
}
```

#### ILoggingService.cs
Defines the methods for logging operations:
```csharp
public interface ILoggingService
{
    void LogInformation(string message);
    void OptionsToChoose();
}
```

### FileService.cs
Implements `IFileService` for file operations using the `System.IO` namespace:
```csharp
public class FileService : IFileService
{
    private const string filePath = "path/to/your/file.txt";
    
    public FileService()
    {
        EnsureFileExists();
    }

    private void EnsureFileExists()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
    }

    public void Save(string fileName, string data)
    {
        File.WriteAllText(fileName, data);
    }

    public void Append(string fileName, string data)
    {
        using (StreamWriter sw = File.AppendText(fileName))
        {
            sw.Write(data);
        }
    }

    public string Read(string fileName)
    {
        return File.ReadAllText(fileName);
    }

    public void Delete(string fileName)
    {
        File.Delete(fileName);
    }

    public bool Exists(string fileName)
    {
        return File.Exists(fileName);
    }
}
```

### LoggingServices.cs
Implements `ILoggingService` for logging operations:
```csharp
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
```

## Contributing

Contributions are welcome! Please submit a pull request or open an issue to discuss changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
