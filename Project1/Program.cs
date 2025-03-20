using System;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
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
