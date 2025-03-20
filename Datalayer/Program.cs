using DataLayer.Database;
using System.Net.Security;
using System;
using DataLayer.Model;
using System.Linq;
using Welcome.Model;

namespace DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = UserType.Student
                });
                context.SaveChanges();

                var users = context.Users.ToList();

                
                Console.WriteLine("1: Print all users\n" +
                    "2: Add new user\n" +
                    "3: Delete user\n");
                int option = 0;
                bool isOptionValid = false;
                while (!isOptionValid)
                {
                    Console.Write("Please choose an option: ");
                    string input = Console.ReadLine();

                    isOptionValid = int.TryParse(input, out option);
                    if (!isOptionValid) Console.WriteLine("Invalid input!");
                }

                switch (option)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("- USERS -");
                        foreach (var dbUser in DatabaseUser.GetAllUsers(context))
                        {
                            Console.WriteLine(dbUser.Name);
                        }
                        Console.WriteLine("- USERS -");
                        Console.ResetColor();
                        break;
                    case 2:
                        Console.Write("Enter name for the new record: ");
                        string n1 = Console.ReadLine();
                        Console.Write("Enter password for the new record: ");
                        string pass = Console.ReadLine();
                        DatabaseUser.InsertUserFromConsole(context, n1, pass);
                        break;
                    case 3:
                        Console.Write("Enter name to delete first matched record: ");
                        string n2 = Console.ReadLine();
                        DatabaseUser.DeleteUserByName(context, n2);
                        break;
                    default:
                        break;
                }
           
            }
        }
    }
}
