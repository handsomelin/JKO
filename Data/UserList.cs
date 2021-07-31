using System;
using System.Collections.Generic;

namespace Data
{
    public class UserList
    {
        HashSet<User> users;
        public UserList()
        {
            this.users = new HashSet<User>();
        }
        public HashSet<User> Users
        {
            get
            {
                return users;
            }
        }
        //public bool Exist(string str)
        //{
        //    User user = new User(str);
        //    if (users.Contains(user))
        //    {
        //        return true;
        //    }
        //    Console.WriteLine("Error - unknown user");
        //    return false;
        //}
        public bool Register(string str)
        {
            User user = new User(str);
            if (!users.Add(user))
            {
                Console.WriteLine("Error - user already existing");
                return false;
            }
            Console.WriteLine("Success");
            return true;
        }
        public User GetUser(string str)
        {
            User user = new User(str);
            if(users.TryGetValue(user, out user))
            {
                return user;
            }
            return null;
        }
    }
}
