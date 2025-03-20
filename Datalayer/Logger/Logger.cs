using DataLayer.Database;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Logger
{
    public class Logger
    {
        public readonly DatabaseContext _context;


        public Logger(DatabaseContext context)
        {
            _context = context;
        }

        public void Log(string level, string message, string exception = null)
        {
            var logEntry = new DatabaseLog
            {
                Timestamp = DateTime.Now,
                Level = level,
                Message = message
            };

            _context.Logs.Add(logEntry);
            _context.SaveChanges();  // Save to database
        }
    }
}
