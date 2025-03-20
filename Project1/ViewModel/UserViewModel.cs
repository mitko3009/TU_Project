using System;
using System.Collections.Generic;
using System.Text;
using Welcome.Model;

namespace Welcome.ViewModel
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
