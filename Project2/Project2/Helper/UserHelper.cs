using System;
using System.Collections.Generic;
using System.Text;
using WelcomeExtended.Data;
using Welcome.Model;

namespace WelcomeExtended.Helper
{
    static class UserHelper
    {
        public static string ToString(this User user)
        {
            if (user == null) { return "User does not exist!"; }
            return $"Name: {user.Name ?? "N/A"}\n" +
                $"Role: {user.Role}\n" +
                $"Faculty number: {user.FacultyNumber ?? "N/A"}";
        } // ToString()

        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("The name field cannot be empty!");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("The password field cannot be empty!");
                return false;
            }

            if (userData.ValidateUser(name, password))
            {
                userData.SetActive(name, DateTime.Now);
                return true;
            }

            return false;
        } // ValidateCredentials()

        public static User GetUser(this UserData userData, string name, string password)
        {
            return userData.GetUser(name, password);
        } // GetUser()
    }
}
