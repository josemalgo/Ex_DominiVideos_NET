using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class RegisteringUser : Option
    {
        private App _app;

        public RegisteringUser(App app)
            :base("Registrar-se.")
        {
            this._app = app;
        }

        public override void Execute()
        {
            Console.WriteLine("\n--- Registre d'usuari ---");
            string userName = _app.GetInputItemValidate("Introdueix el nom d'usuari (anular per sortir): ", 1);
            if (string.IsNullOrEmpty(userName))
                return;
            string password = _app.GetInputItemValidate("Introdueix la contrasenya (anular per sortir): ");
            if (string.IsNullOrEmpty(password))
                return;
            string name = _app.GetInputItemValidate("Introdueix el teu nom (anular per sortir): ");
            if (string.IsNullOrEmpty(name))
                return;
            string surname = _app.GetInputItemValidate("Introdueix el teu cognom (anular per sortir): ");
            if (string.IsNullOrEmpty(surname))
                return;

            User newUser = new User(Guid.NewGuid(), userName, name, surname, password, DateTime.Today);
            _app.Users.Add(userName, newUser);
            _app.CurrentUser = newUser;
            Console.WriteLine("\nUsuari registrat amb éxit!");
        }
    }
}
