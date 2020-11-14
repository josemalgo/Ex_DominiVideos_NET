using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class LoginUserOption : Option
    {
        private App _app;

        public LoginUserOption(App app)
            :base("Iniciar sessió.")
        {
            this._app = app;
        }

        public override void Execute()
        {
            Console.WriteLine("\n--- Login ---");
            string userName = User.GetInputItemValidate("Introdueix el nom d'usuari: ");
            if (string.IsNullOrEmpty(userName))
                return;
            string password = User.GetInputItemValidate("Introdueix la contrasenya: ");
            if (string.IsNullOrEmpty(password))
                return;

            if (_app.Users.ContainsKey(userName) && _app.Users[userName].Password == password)
            {
                Console.WriteLine("Sesió iniciada amb éxit!");
                //MenuUsuari();
            }
            else
                Console.WriteLine("\nL'usuari i/o contraseña incorrectes.\n");
        }
    }
}
