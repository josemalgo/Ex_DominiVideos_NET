using System;
using System.Collections.Generic;

namespace FASE_1
{
    class Program
    {
        private static Dictionary<Guid, User> _users = new Dictionary<Guid, User>();
        private static User currentUser = null;


        static void Main(string[] args)
        {

            IsAuthenticated();
            

        }

        private static void IsAuthenticated()
        {
            if (currentUser != null)
            {
                ShowMenu();
            }
            else
            {
                Login();
            }
        }

        private static void ShowMenuOptions()
        {
            Console.WriteLine("--- Menú inici aplicació ---");
            Console.WriteLine("a - Inici sessió.");
            Console.WriteLine("b - Registrar-se.");
            Console.WriteLine("c - Sortir.");
        }

        private static void ShowMenu()
        {
            bool keepdoing = false;

            ShowMenuOptions();

            char option = Console.ReadKey().KeyChar;

            do
            {
                switch (option)
                {
                    case 'a':
                        Login();
                        break;
                    case 'b':
                        Register();
                        break;
                    case 'c':
                        Console.WriteLine("Fins aviat!");
                        keepdoing = true;
                        break;
                    default:
                        Console.WriteLine("La opció no es válida!\n");
                        break;
                }

            } while (keepdoing);
        }

        private static void Register()
        {
            Console.WriteLine("-- Registre d'usuari --");
            Console.WriteLine("Introduiex el nom d'usuari:");
            string userName = Console.ReadLine();
            Console.WriteLine("Introduiex el teu nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Introduiex el teu cognom:");
            string surname = Console.ReadLine();
            Console.WriteLine("Introduiex la contraseña:");
            string password = Console.ReadLine();

            //TODO: Validacions camps introduïts

            Guid id = new Guid();
            User newUser = new User(id, userName, name, surname, password, DateTime.Today);
            _users.Add(id, newUser);

            Console.WriteLine("Usuari registrat amb éxit!\nYa podeu iniciar sessió.");
            Login();
        }

        private static void Login()
        {
            Console.WriteLine("-- Registre d'usuari --");
            Console.WriteLine("Introduiex el nom d'usuari");
            string userName = Console.ReadLine();
            Console.WriteLine("Introduiex la contraseña");
            string password = Console.ReadLine();

            if (ValidateUser(userName, password))
            {
                MenuUsuari();
            }
            else
                Console.WriteLine("L'usuari i/o contraseña incorrectes.");
        }

        private static bool ValidateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            if (string.IsNullOrEmpty(password))
                return false;

            foreach(var user in _users)
            {
                if(user.Value.UserName == userName && user.Value.Password == password)
                {
                    currentUser = user.Value;
                    return true;
                }
            }

            return false;
        }

        private static void MenuUsuariOptions()
        {
            Console.WriteLine("--- Menú d'usuari ---");
            Console.WriteLine("a - Veure llistat videos.");
            Console.WriteLine("b - Crear nou video.");
            Console.WriteLine("c - Gestionar video.");
            Console.WriteLine("d - Tanca Sessió.");
        }

        private static void MenuUsuari()
        {
            bool keepdoing = false;

            MenuUsuariOptions();

            char option = Console.ReadKey().KeyChar;

            do
            {
                switch (option)
                {
                    case 'a':
                        ShowVideosUser();
                        break;
                    case 'b':
                        CreateVideo();
                        break;
                    case 'c':
                        ManagementVideo();
                        break;
                    case 'd':
                        Console.WriteLine("Fins aviat!");
                        keepdoing = true;
                        break;
                    default:
                        Console.WriteLine("La opció no es válida!\n");
                        break;
                }

            } while (keepdoing);
        }

        private static void ShowVideosUser()
        {
            foreach (var video in currentUser.Videos())
            {
                Console.WriteLine(video.Title);
            }
        }

        private static void CreateVideo()
        {
            Console.WriteLine("-- Creació d'un nou video --");
            Console.WriteLine("Introduiex la URL:");
            string url = Console.ReadLine();
            Console.WriteLine("Introduiex el títol:");
            string title = Console.ReadLine();
            Console.WriteLine("Introduiex el/s tags(separats per espais o comes):");
            string tags = Console.ReadLine();

            //TODO: Validacions camps introduïts

            Guid id = new Guid();
            Video video = new Video(id, url, title, tags);

            currentUser.CreateVideo(video);
        }

        private static void ManagementVideo()
        {
            ShowVideosUser();
            Console.WriteLine("Escriu el títol del video que vols veure:");
            Video video = _users.Values.
        }

        private static void MenuManageVideosOptions()
        {
            Console.WriteLine("--- Menú video ---");
            Console.WriteLine("a - Afegit tags.");
            Console.WriteLine("b - Reproduir.");
            Console.WriteLine("c - Pausar.");
            Console.WriteLine("d - Parar.");
            Console.WriteLine("e - Tanca Sessió.");
        }

        private static void MenuManageVideos()
        {
            bool keepdoing = false;

            MenuUsuariOptions();

            char option = Console.ReadKey().KeyChar;

            do
            {
                switch (option)
                {
                    case 'a':
                        
                        break;
                    case 'b':
                        
                        break;
                    case 'c':
                        
                        break;
                    case 'd':

                        break;
                    case 'e':
                        Console.WriteLine("Sortim del video.");
                        keepdoing = true;
                        break;
                    default:
                        Console.WriteLine("La opció no es válida!\n");
                        break;
                }

            } while (keepdoing);
        }
    }
}
