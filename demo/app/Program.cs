using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace finaltest
{
public static class SecurityVulnerabilities
{
    // Hardcoded credentials (Security Issue)
    static string username = "admin";
    static string password = "password123"; // BAD PRACTICE!

    static void Main()
    {
        Console.WriteLine("Welcome to the system!");

        // Calling multiple vulnerable methods
        InsecureLogin();
        ReadFile();
        ExecuteCommand();
        StoreSensitiveData();
        GenerateWeakRandomNumber();
    }

    // 🚨 Security Issue: Hardcoded credentials & insecure logging
    static void InsecureLogin()
    {
        Console.Write("Enter username: ");
        string inputUser = Console.ReadLine();
        Console.Write("Enter password: ");
        string inputPass = Console.ReadLine();

        if (inputUser == username && inputPass == password)
        {
            Console.WriteLine("Login Successful!");

            // 🚨 Insecure Logging: Logs sensitive data
            Console.WriteLine("User logged in with password: " + inputPass);
        }
        else
        {
            Console.WriteLine("Invalid Credentials!");
        }
    }

    // 🚨 Security Issue: Unhandled exception & unprotected file access
    static void ReadFile()
    {
        try
        {
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine(); // No validation

            string content = File.ReadAllText(filename); // No permission check
            Console.WriteLine("File Content: " + content);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }
    }

    // 🚨 Security Issue: Command Injection
    static void ExecuteCommand()
    {
        Console.Write("Enter command to execute: ");
        string userInput = Console.ReadLine(); // No validation

        Process.Start(userInput); // 🚨 Allows arbitrary command execution
    }

    // 🚨 Security Issue: Unencrypted Data Storage
    static void StoreSensitiveData()
    {
        string sensitiveInfo = "CreditCardNumber=1234-5678-9012-3456"; // Should be encrypted
        File.WriteAllText("sensitive_data.txt", sensitiveInfo); // Storing plaintext sensitive info
        Console.WriteLine("Sensitive data stored insecurely!");
    }

    // 🚨 Security Issue: Weak Random Number Generation
    static void GenerateWeakRandomNumber()
    {
        Random random = new Random();
        int weakRandom = random.Next(1000, 9999); // Weak for security purposes
        Console.WriteLine("Generated Weak Random Number: " + weakRandom);
    }
}
}