using System;
using System.IO;
using NLog.Fluent;
using Welcome.Model;
using Welcome.ViewModel;
using Welcome.Model;
using WelcomeExtended.Others;
using Welcome.View;

namespace WelcomeExtended
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var user = new User
                {
                    Name = "John Smith",
                    Password = "password123",
                    Role = UserType.Student
                };

                var viewModel = new UserViewModel(user);

                var view = new UserView(viewModel);

                view.Display();

                view.DisplayError();


            }
            catch(Exception e)
            {
                var log = new ActionOnError(Delegates.Log);
                log(e.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }

           

        }
    }
}
