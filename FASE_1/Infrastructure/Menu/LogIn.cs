using FASE_1.Models;
using System;

namespace FASE_1.Infrastructure.Menu
{
    class LogIn : Option
    {
        private App _app;
        private Menu _menuUser;

        public LogIn(App app)
            :base("Iniciar sessió.")
        {
            _app = app;
            _menuUser = new Menu();
            _menuUser.Add(new VideoList(_app));
            _menuUser.Add(new VideoCreator(_app));
            _menuUser.Add(new VideoManager(_app));
            _menuUser.CloseSesion();

        }

        public override void Execute()
        {
            Console.WriteLine("\n--- Login ---");
            string userName = _app.GetInputItemValidate("Introdueix el nom d'usuari (anular per sortir): ");
            if (string.IsNullOrEmpty(userName))
                return;
            string password = _app.GetInputItemValidate("Introdueix la contrasenya (anular per sortir): ");
            if (string.IsNullOrEmpty(password))
                return;

            if (_app.Users.ContainsKey(userName) && _app.Users[userName].Password == password)
            {
                Console.WriteLine("\nSesió iniciada amb éxit!");
                ShowMenuUser();
            }
            else
                Console.WriteLine("\nL'usuari i/o contraseña incorrectes.\n");
        }

        private void ShowMenuUser()
        {
            do
            {
                Console.WriteLine("\n--- Menú d'Usuari ---");
                _menuUser.Show();
                _menuUser.GetOption().Execute();
            } while (!_menuUser.Finished());

            _app.CurrentUser = null;
        }
    }
}
