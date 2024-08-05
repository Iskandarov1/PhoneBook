# PhoneBook Application

## Overview

The PhoneBook application is a console-based contacts manager written in C#. It allows users to create, read, update, and delete contacts stored in either a plain text file or a JSON file. The application demonstrates the use of interfaces and file handling, promoting modular and maintainable code.

## Features

- **Create Contact**: Add a new contact to the phone book.
- **Read Contacts**: Display all contacts stored in the phone book.
- **Update Contact**: Update the phone number of an existing contact.
- **Delete Contact**: Remove a contact from the phone book.
- **Logging**: Log important actions and display menu options to the user.

## Installation

1. Clone the repository:

    ```sh
    git clone https://github.com/Iskandarov1/PhoneBook.git
    cd PhoneBook
    ```

2. Open the project in your IDE (e.g., Rider, Visual Studio).

3. Build the project.

## Usage

1. Run the application. You will be prompted to choose the storage method:

    ```plaintext
    Choose storage method:
    1. Plain Text File
    2. JSON File
    Select an option:
    ```

2. Enter `1` for plain text file storage or `2` for JSON file storage.

3. Follow the menu to create, read, update, or delete contacts.

    ```plaintext
    PhoneBook Menu:
    1. Create Contact
    2. Read Contacts
    3. Update Contact
    4. Delete Contact
    5. Exit
    Select an option:
    ```

## Code Structure

- **Models**: Contains the `Contact` model.
- **Services**: Contains service classes and interfaces:
  - `IContactStorage`: Interface for contact storage operations.
  - `FileContactStorage`: Implementation of `IContactStorage` for plain text file storage.
  - `JsonContactStorage`: Implementation of `IContactStorage` for JSON file storage.
  - `ContactService`: Handles contact operations (create, read, update, delete).
  - `LoggingServices`: Handles logging.
- **FileService**: Chooses the appropriate storage mechanism based on user input.
- **Program**: The main entry point of the application.

## Example

Here's an example of how to use the PhoneBook application:

1. **Start the application**:

    ```plaintext
    Choose storage method:
    1. Plain Text File
    2. JSON File
    Select an option: 1
    ```

2. **Create a contact**:

    ```plaintext
    PhoneBook Menu:
    1. Create Contact
    2. Read Contacts
    3. Update Contact
    4. Delete Contact
    5. Exit
    Select an option: 1
    Enter Name: John Doe
    Enter Phone Number: 123456789
    Contact John Doe created successfully.
    ```

3. **Read contacts**:

    ```plaintext
    PhoneBook Menu:
    1. Create Contact
    2. Read Contacts
    3. Update Contact
    4. Delete Contact
    5. Exit
    Select an option: 2

    Contacts:
    Name: John Doe, Phone Number: 123456789
    ```

4. **Update a contact**:

    ```plaintext
    PhoneBook Menu:
    1. Create Contact
    2. Read Contacts
    3. Update Contact
    4. Delete Contact
    5. Exit
    Select an option: 3
    Enter the name of the contact to update: John Doe
    Enter new Phone Number: 987654321
    Contact John Doe updated successfully.
    ```

5. **Delete a contact**:

    ```plaintext
    PhoneBook Menu:
    1. Create Contact
    2. Read Contacts
    3. Update Contact
    4. Delete Contact
    5. Exit
    Select an option: 4
    Enter the name of the contact to delete: John Doe
    Contact John Doe deleted successfully.
    ```

6. **Exit the application**:

    ```plaintext
    PhoneBook Menu:
    1. Create Contact
    2. Read Contacts
    3. Update Contact
    4. Delete Contact
    5. Exit
    Select an option: 5
    PhoneBook Application Ended
    ```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
