using FASE_1.Infrastructure;
using FASE_1.Infrastructure.Menu;
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
        private Menu _menu;

        public Dictionary<string, User> Users { get { return _users; } }
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public App()
        {
            _users = new Dictionary<string, User>();
            _currentUser = null;
            _menu = new Menu();
            _menu.Add(new LogIn(this));
            _menu.Add(new RegisteringUser(this));
            _menu.Close();
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("\n--- Menú inici aplicació ---");
                _menu.Show();
                _menu.GetOption().Execute();
            } while (!_menu.Finished());
        }

        #region Validations
        public string GetInputItemValidate(string outputInformation, int exist = 0)
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

                if (exist == 1 && _users.ContainsKey(item))
                    Console.WriteLine("\nEl nom d'usuari ya s'esta utilitzant. Proba amb un altre.");
                else
                    valRes = ValidateEmptyOrNullField(item);
            }

            return item;
        }

        public ValidationResult ValidateEmptyOrNullField(string value)
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
