# MySQL Backup and Restore Application

This is a C# desktop application that allows users to easily back up and restore MySQL databases. The application also provides the ability to encrypt and decrypt backup files, adding an extra layer of security to your data. Additionally, it supports salting during encryption and decryption for enhanced protection.

## Features

- **Backup MySQL Database**: Allows the user to create a backup of their MySQL database.
- **Restore MySQL Database**: Restores a backup file to the specified MySQL server.
- **Encryption and Decryption**: The application can encrypt the backup files using AES encryption and can decrypt them when restoring.
- **Salting**: During encryption and decryption, a unique salt is applied to enhance security.
- **User-Friendly Interface**: Simple and intuitive UI for performing backup, restore, and encryption operations.
- **Cross-Platform**: Can be built and used on Windows with .NET Framework or .NET Core.

## Prerequisites

- **.NET Framework**: Ensure that you have .NET Framework 4.5+ installed on your system.
- **MySQL Server**: You need to have a MySQL server installed and configured for backup and restoration.
- **MySQL Connector for .NET**: Make sure the MySQL .NET Connector is installed and referenced in the project.

## Installation

1. Clone or download the repository.
2. Open the project in Visual Studio.
3. Build the project by selecting `Build > Build Solution`.
4. After a successful build, run the application.

## How to Use

### Backup a MySQL Database

1. Open the application.
2. Enter your MySQL server details (host, username, password, database name).
3. Choose a destination folder for saving the backup file.
4. Optionally, enable encryption and provide a password for encryption (this is required for decryption later).
5. Press the **Backup** button to start the backup process.

### Restore a MySQL Database

1. Open the application.
2. Select the backup file you want to restore.
3. If the backup file is encrypted, enter the encryption password.
4. Enter the MySQL server details (host, username, password).
5. Press the **Restore** button to begin the restore process.

### Encryption and Decryption

- During backup, the user has the option to encrypt the backup using a password. The backup file will be encrypted using AES encryption.
- When restoring the backup, the application will decrypt the file using the same password.
- Salting is applied during both encryption and decryption to ensure an additional layer of security.

## Code Structure

- **Form1.cs**: Main UI logic for interacting with the user.
- **MySQLHelper.cs**: Contains methods for connecting to MySQL and executing queries (backup and restore).
- **EncryptionHelper.cs**: Methods for handling encryption and decryption using AES, including salting.
- **BackupService.cs**: Logic to handle backup creation, file compression, and encryption.
- **RestoreService.cs**: Logic for restoring the database and handling decryption of backup files.

## Configuration

Make sure to configure the following settings before using the application:

- **MySQL Connection Settings**: Ensure that the MySQL server hostname, username, password, and database name are correctly set for backup and restore operations.
- **Encryption Settings**: Set a secure password for encrypting the backup file. This password will be required during the restore process.

## Dependencies

- **MySQL.Data**: NuGet package for connecting to MySQL databases.
- **System.Security.Cryptography**: For AES encryption and decryption.
- **.NET Framework 4.5+**: Required for building and running the application.

## Troubleshooting

- **Cannot connect to MySQL server**: Ensure that the MySQL server is running and the connection credentials are correct.
- **Decryption fails**: Ensure that you are using the correct password and salt during the decryption process.
- **Backup file is corrupted**: Make sure that the backup file is correctly created and not interrupted during the backup process.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a pull request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
