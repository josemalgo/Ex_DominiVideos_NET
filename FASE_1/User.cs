using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1
{
    class User
    {
        private Guid _id;
        private string _userName, _name, _surname, _password;
        private DateTime _registrationDate;
        private List<Video> _videos;
        public string UserName { get { return _userName; } }
        public string Password { get { return _password; } }
        public List<Video> Videos { get { return _videos; } }

        public User(Guid id, string user, string name, string surname, string password, DateTime date)
        {
            _id = id;
            _userName = user;
            _name = name;
            _surname = surname;
            _password = password;
            _registrationDate = date;
            _videos = new List<Video>();
        }

        public void CreateVideo(Video video)
        {
            if(video.Save())
                _videos.Add(video);
        }
    }
}
