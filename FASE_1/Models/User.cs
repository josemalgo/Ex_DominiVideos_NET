using FASE_1.Infrastructure;
using System;
using System.Collections.Generic;

namespace FASE_1.Models
{
    class User : Entity
    {
        private string _userName, _name, _surname, _password;
        private DateTime _registrationDate;
        private List<Video> _videos;
        public string UserName { get { return _userName; } }

        public string Password { get { return _password; } }

        public List<Video> Videos { get { return _videos; } }

        public User(Guid id, string user, string name, string surname, string password, DateTime date)
            : base(id)
        {
            _userName = user;
            _name = name;
            _surname = surname;
            _password = password;
            _registrationDate = date;
            _videos = new List<Video>();
        }

        public void CreateVideo(Video video)
        {
            this._videos.Add(video);
        }

        #region Validations

        public static string GetInputItemValidate(string outputInformation, Dictionary<string,User> exist = null)
        {
            string item = "";
            ValidationResult valRes = new ValidationResult();
            valRes.IsSuccess = false;

            while (!valRes.IsSuccess)
            {
                if (valRes.Messages.Count > 0)
                    Console.WriteLine(valRes.AllErrors);

                Console.Write(outputInformation);
                item = Console.ReadLine();
                if (item == "anular")
                    return null;

                if (exist != null && exist.ContainsKey(item))
                    Console.WriteLine("\nEl nom d'usuari ya s'esta utilitzant. Proba amb un altre.");
                else
                    valRes = User.ValidateEmptyOrNullField(item);
            }

            return item;
        }

        public static ValidationResult ValidateEmptyOrNullField(string value)
        {
            ValidationResult valRes = new ValidationResult();
            valRes.IsSuccess = true;
            if (string.IsNullOrEmpty(value) || value.Replace(" ", "") == "")
            {
                valRes.IsSuccess = false;
                valRes.Messages.Add("El camp no pot estar buit!");
            }

            return valRes;
        }

        #endregion  
    }
}
