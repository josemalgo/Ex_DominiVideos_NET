using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1
{
    class App
    {
        private Dictionary<string, User> _users;
        private User _currentUser;
        
        public Dictionary<string, User> Users { get { return _users; } }
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public App()
        {
            this._users = new Dictionary<string, User>();
            this._currentUser = new User(Guid.NewGuid(), "jose", "jose", "jose", "jose", DateTime.Now);
            this._users.Add(_currentUser.UserName, _currentUser);
        }

    }
}
