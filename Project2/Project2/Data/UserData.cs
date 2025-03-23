using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Welcome.Model;

namespace WelcomeExtended.Data
{
    class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _nextId = 0;
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        } // AddUser()

        public void DeleteUser(User user)
        {
            if (_users.IndexOf(user) == 0) { return; } // if (!_users.Contains(user)) { return; }
            _users.Remove(user);
        } // DeleteUser()

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        } // ValidateUser()

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        } // ValidateUserLambda()

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Name == name && user.Password == password
                      select user.Id;
            return ret != null ? true : false;
        } // ValidateUserLinq()

        public User GetUser(string name, string password)
        {
            return (from user in _users
                    where user.Name == name && user.Password == password
                    select user)
                          .First();
        } // GetUser()

        public void SetActive(string name, DateTime dateTime)
        {
            DateTime temp;
            if (!DateTime.TryParse(dateTime.ToString(), out temp)) { return; }

            (from user in _users
             where user.Name == name
             select user)
             .First().Expires = dateTime;
        } // SetActive()

        public void AssignUserRole(string name, UserType role)
        {
            (from user in _users
             where user.Name == name
             select user)
             .First().Role = role;
        } // AssignUserRole()

    }
}
