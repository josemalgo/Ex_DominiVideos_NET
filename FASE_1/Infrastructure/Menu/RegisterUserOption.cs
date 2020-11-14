using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class RegisterUserOption : Option
    {
        private App _app;

        public RegisterUserOption(App app)
            :base("Registrar-se.")
        {
            this._app = app;
        }

        public override void Execute()
        {
            Console.WriteLine("\n--- Registre d'usuari ---");
            string userName = User.GetInputItemValidate("Introdueix el nom d'usuari: ", _app.Users);
            if (string.IsNullOrEmpty(userName))
                return;
            string password = User.GetInputItemValidate("Introdueix la contrasenya: ");
            if (string.IsNullOrEmpty(password))
                return;
            string name = User.GetInputItemValidate("Introdueix el teu nom: ");
            if (string.IsNullOrEmpty(name))
                return;
            string surname = User.GetInputItemValidate("Introdueix el teu cognom: ");
            if (string.IsNullOrEmpty(surname))
                return;

            User newUser = new User(Guid.NewGuid(), userName, name, surname, password, DateTime.Today);
            _app.Users.Add(userName, newUser);
            Console.WriteLine("\nUsuari registrat amb éxit!\n");
        }
    }
}
