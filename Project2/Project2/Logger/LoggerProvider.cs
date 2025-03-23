using System;
using Microsoft.Extensions.Logging;
using WelcomeExtended.Logger;

namespace WelcomeExtended.Logger
{
    class LoggerProvider : ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new HashLogger(categoryName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
