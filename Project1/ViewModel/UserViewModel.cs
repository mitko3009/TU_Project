using Project1.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.ViewModel
{
    public class UserViewModel
    {

        public User User { get; }

        public UserViewModel(User user)
        {
            User = user;
        }

    }
}
