using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static class Logger
{
    public static void ShowFunction(string filePath = "", string functionName = "")
    {
        // Extract class name from file path
        string className = System.IO.Path.GetFileNameWithoutExtension(filePath);
        Debug($"Entered {className}.{functionName}");
    }

    public static void Info(string message) =>
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} [INFO] {message}");

    public static void Debug(string message)
    {
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} [DBUG]   {message}");
    }

    public static void Warn(string message) =>
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} [WARN]     {message}");

    public static void Error(string message)
    {
        Debugger.Break();
        Console.WriteLine($"{DateTime.Now:HH:mm:ss} [ERR!] !!! {message}");
    }
}
