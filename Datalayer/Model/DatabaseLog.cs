using DataLayer.Database;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Security;

namespace DataLayer.Model
{
    public class DatabaseLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }

        public static void InsertLog(DatabaseContext context, DateTime timestamp, string level, string message)
        {
            context.Add<DatabaseLog>(new DatabaseLog()
            {
                Timestamp = timestamp,
                Level = level,
                Message = message
            });
            context.SaveChanges();
        } // InsertLog()
    }
}
