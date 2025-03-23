using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Welcome.Model;

namespace WelcomeExtended.Logger
{
    class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}][{_name}]");

            var message = formatter(state, exception);

            Console.WriteLine("- LOGGER -");
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{message}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();

            _logMessages[eventId.Id] = message;
        } // Log()

        public void PrintAllLogMessages()
        {
            if (_logMessages.Count == 0)
            {
                Console.WriteLine("No log messages have been found!");
                return;
            }

            Console.WriteLine("- ALL LOG MESSAGES -");
            foreach (var logMessage in _logMessages)
            {
                Console.WriteLine($"Error id {logMessage.Key}: {logMessage.Value}");
            }
            Console.WriteLine("- ALL LOG MESSAGES -");
        } // PrintAllLogMessages()

        public void PrintLogMessageById(int id)
        {
            if (_logMessages.Count <= id) { return; }
            Console.WriteLine($"Error id {id}: {_logMessages[id]}");
        } // DeleteLogMessageById()

        public void DeleteLogMessageById(int id)
        {
            _logMessages.TryRemove(id, out var value);
        } // DeleteLogMessageById()

        public void SaveAllLogMessages()
        {
            string path = "C:\\Users\\marty\\Desktop\\zad2_all_logs.txt";

            TextWriter tw = new StreamWriter(path, true); // The constructor automatically creates the file if it doesn't exist
            foreach (var logMessage in _logMessages)
            {
                tw.WriteLine($"Error id {logMessage.Key}: {logMessage.Value}");
            }
            tw.Close();
        } // SaveAllLogMessages()

        public static void LogSuccessfulLogin(User user)
        {
            string path = "C:\\Users\\marty\\Desktop\\zad3_successful_login.txt";

            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine($"User {user.Name} has logged on {user.Expires}");
            tw.Close();

        } // LogSuccessfulLogin()

        public static void LogUnsuccessfulLogin(string error, DateTime dateTime)
        {
            string path = "C:\\Users\\marty\\Desktop\\zad3_unsuccessful_login.txt";

            TextWriter tw = new StreamWriter(path, true);
            tw.WriteLine($"Unsuccessful login attempt on {dateTime}: {error}");
            tw.Close();
        } // LogUnsuccessfulLogin()
    }
}
