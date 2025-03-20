using Project1.Model;
using Project1.ViewModel;
using System;

namespace Project1
{
    class Program
    {
        static void Main()
        {
            User user = new User
            {
                Id = 1,
                Name = "John Doe",
                Age = 30,
                Role = UserType.Student,
                FacultyNumber = "123456",
                Email = "john@example.com",
                Password = "mypassword",
                Expires = DateTime.Now.AddYears(1) 
            };

           
            UserViewModel userViewModel = new UserViewModel(user);

            UserView userView = new UserView(userViewModel);

            userView.Display();

            Console.ReadKey();
        }
    }
}
