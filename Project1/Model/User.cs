using System;

namespace Project1.Model
{
    public class User
    {

        public virtual int Id { get; set; }
        public DateTime expires;

       

        public DateTime Expires
        {
            get { return expires; }
            set { expires = value; }
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public UserType Role { get; set; }
        public string FacultyNumber { get; set; }
        public string Email { get; set; }

        private string password;
        public string Password
        {
            get { return Decrypt(password); }
            set { password = Encrypt(value); }
        }

        private string Encrypt(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private string Decrypt(string input)
        {
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public User() { }
    }
}
