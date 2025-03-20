using Project1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.ViewModel
{
    public class UserView
    {

        private readonly UserViewModel userViewModel;

        public UserView(UserViewModel userViewModel)
        {
            this.userViewModel = userViewModel;
        }

        public void Display()
        {
            Console.WriteLine("User Information:");
            Console.WriteLine($"ID: {userViewModel.User.Id}");
            Console.WriteLine($"Name: {userViewModel.User.Name}");
            Console.WriteLine($"Age: {userViewModel.User.Age}");
            Console.WriteLine($"User Type: {userViewModel.User.Role}");
            Console.WriteLine($"Faculty Number: {userViewModel.User.FacultyNumber}");
            Console.WriteLine($"Email: {userViewModel.User.Email}");
            Console.WriteLine($"Password (Decrypted): {userViewModel.User.Password}");
            Console.WriteLine($"Expires On: {userViewModel.User.Expires}");
        }

        public void DisplayError()
        {
            throw new Exception("Error displaying user information!");
        }

    }
}
