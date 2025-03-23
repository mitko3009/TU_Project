using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeExtended.Helper;
using WelcomeExtended.Logger;
using Welcome.Model;

namespace WelcomeExtended.Others
{
    class Delegates
    {

        public static readonly HashLogger logger = new HashLogger("Hello");

        public static void Log(string error)
        {
            logger.LogError(error);
        } // Log()

        public static void Log2(string error)
        {
            Console.WriteLine("- DELEGATES -");
            Console.WriteLine($"{error}");
            Console.WriteLine("- DELEGATES -");
        } // Log2()

        public static void PrintAll()
        {
            // if (logger is HashLogger hashLogger) hashLogger.PrintAllLogMessages();
            logger.PrintAllLogMessages();
        } // PrintAll()

        public static void PrintById(int id)
        {
            logger.PrintLogMessageById(id);
        } // PrintById()

        public static void DeleteById(int id)
        {
            logger.DeleteLogMessageById(id);
        } // DeleteById()

        public static void SaveAll()
        {
            logger.SaveAllLogMessages();
        } // SaveAll()

        public static void LogSuccessfulLogin(User user)
        {
            HashLogger.LogSuccessfulLogin(user);
        } // LogSuccessfulLogin()

        public static void LogUnsuccessfulLogin(string error, DateTime dateTime)
        {
            logger.LogError(error);
            HashLogger.LogUnsuccessfulLogin(error, dateTime);
        } // LogUnsuccessfulLogin()

    }
}
