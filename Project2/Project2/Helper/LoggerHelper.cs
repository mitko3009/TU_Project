using Microsoft.Extensions.Logging;
using WelcomeExtended.Logger;

namespace WelcomeExtended.Helper
{
    class LoggerHelper
    {

        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());

            return loggerFactory.CreateLogger(categoryName);
        }

    }
}
