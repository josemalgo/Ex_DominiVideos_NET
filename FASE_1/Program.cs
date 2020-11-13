using FASE_1.Infrastructure;
using FASE_1.Models;
using System;
using System.Collections.Generic;

namespace FASE_1
{
    /// <summary>
    /// Validaciones campos en modelos
    /// Crear método save 
    /// Cambiar diccionario id por userName
    /// </summary>
    class Program
    {
        private static Dictionary<string, User> _users = new Dictionary<string, User>();
        private static User currentUser = null;
        private static Dictionary<string, string> OutputsRegisterLogin = new Dictionary<string, string>()
        {
            { "userName","Introdueix el nom d'usuari (anular per sortir): " },
            { "password","Introdueix la contraseña (anular per sortir): " },
            { "name","Introdueix el teu nom (anular per sortir): " },
            { "surname","Introdueix el teu cognom (anular per sortir):  " },
        };

        private static Dictionary<string, string> OutputsVideo = new Dictionary<string, string>()
        {
            { "url","Introduiex la URL (anular per sortir): " },
            { "title","Introduiex el títol (anular per sortir): " },
            { "titleChoice","Escriu el títol del video que vols veure (anular per sortir): " },
            { "tag", "\nEscriu un tag pel video (anular per sortir): " }
        };


        static void Main(string[] args)
        {
            ShowMenu();
        }

        #region Menús i opcions menús

        private static void ShowMenuOptions()
        {
            Console.WriteLine("\n--- Menú inici aplicació ---");
            Console.WriteLine("a - Inici sessió.");
            Console.WriteLine("b - Registrar-se.");
            Console.WriteLine("c - Sortir.");
        }

        private static void ShowMenu()
        {
            bool keepdoing = true;

            do
            {
                ShowMenuOptions();
                char option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case 'a':
                        Login();
                        break;
                    case 'b':
                        Register();
                        break;
                    case 'c':
                        Console.WriteLine("\nFins aviat!");
                        keepdoing = false;
                        break;
                    default:
                        Console.WriteLine("\nLa opció no es válida!\n");
                        break;
                }

            } while (keepdoing);
        }

        private static void MenuUsuariOptions()
        {
            Console.WriteLine("\n--- Menú d'usuari ---");
            Console.WriteLine("a - Veure llistat videos.");
            Console.WriteLine("b - Crear nou video.");
            Console.WriteLine("c - Gestionar video.");
            Console.WriteLine("d - Tanca Sessió.");
        }

        private static void MenuUsuari()
        {
            bool keepdoing = true;

            do
            {
                MenuUsuariOptions();
                char option = Console.ReadKey().KeyChar;

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
                        Console.WriteLine("\nFins aviat!");
                        keepdoing = false;
                        break;
                    default:
                        Console.WriteLine("\nLa opció no es válida!\n");
                        break;
                }

            } while (keepdoing);
        }

        private static void MenuManageVideosOptions()
        {
            Console.WriteLine("\n--- Menú video ---");
            Console.WriteLine("a - Afegir tags.");
            Console.WriteLine("b - Reproduir.");
            Console.WriteLine("c - Pausar.");
            Console.WriteLine("d - Parar.");
            Console.WriteLine("e - Sortir.");
        }

        private static void MenuManageVideos(Video video)
        {
            bool keepdoing = true;

            do
            {
                MenuManageVideosOptions();
                char option = Console.ReadKey().KeyChar;

                switch (option)
                {
                    case 'a':
                        AddTag(video);
                        break;
                    case 'b':
                        video.Play();
                        break;
                    case 'c':
                        video.Pause();
                        break;
                    case 'd':
                        video.Stop();
                        break;
                    case 'e':
                        Console.WriteLine("\nSortim del video.");
                        keepdoing = false;
                        break;
                    default:
                        Console.WriteLine("\nLa opció no es válida!\n");
                        break;
                }

            } while (keepdoing);
        }

        #endregion

        #region Validacion Inputs

        static bool CancelInput(string input)
        {
            if (input == "anular")
            {
                Console.WriteLine("\nS'ha cancelat l'operació!. Tornem al menú.");
                return true;
            }

            return false;
        }

        private static string GetInputItemValidate(string outputInformation, int exist = 0)
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
                if (CancelInput(item))
                    return null;

                if (exist == 1 && !ValidateUserExist(item))
                    Console.WriteLine("\nEl nom d'usuari ya s'esta utilitzant. Proba amb un altre.");
                else
                    valRes = User.ValidateEmptyOrNullField(item);
            }

            return item;
        }

        private static bool ValidateUserExist(string userName)
        {
            foreach (var user in _users)
            {
                if (user.Value.UserName == userName)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateUserLogin(string userName, string password)
        {
            foreach (var user in _users)
            {
                if (user.Value.UserName == userName && user.Value.Password == password)
                {
                    currentUser = user.Value;
                    return true;
                }
            }

            return false;
        }

        #endregion

        private static void Register()
        {
            Console.WriteLine("\n--- Registre d'usuari ---");
            string userName = GetInputItemValidate(OutputsRegisterLogin["userName"], 1);
            if (string.IsNullOrEmpty(userName))
                return;
            string password = GetInputItemValidate(OutputsRegisterLogin["password"]);
            if (string.IsNullOrEmpty(password))
                return;
            string name = GetInputItemValidate(OutputsRegisterLogin["name"]);
            if (string.IsNullOrEmpty(name))
                return;
            string surname = GetInputItemValidate(OutputsRegisterLogin["surname"]);
            if (string.IsNullOrEmpty(surname))
                return;

            User newUser = new User(Guid.NewGuid(), userName, name, surname, password, DateTime.Today);
            _users.Add(userName, newUser);
            Console.WriteLine("\nUsuari registrat amb éxit!\nYa podeu iniciar sessió.");
            Login();
        }

        private static void Login()
        {
            Console.WriteLine("\n--- Login ---");
            string userName = GetInputItemValidate(OutputsRegisterLogin["userName"]);
            if (string.IsNullOrEmpty(userName))
                return;
            string password = GetInputItemValidate(OutputsRegisterLogin["password"]);
            if (string.IsNullOrEmpty(password))
                return;

            if (ValidateUserLogin(userName, password))
            {
                MenuUsuari();
            }
            else
                Console.WriteLine("\nL'usuari i/o contraseña incorrectes.\n");
        }

        private static void ShowVideosUser()
        {
            if (currentUser.Videos.Count == 0)
            {
                Console.WriteLine("\nNo tens cap video per mostrar");
                return;
            }

            Console.WriteLine();
            foreach (var video in currentUser.Videos)
            {
                Console.WriteLine("\n- Títol: " + video.Title + " - Tags: " + ShowTags(video.Tags));
            }
        }

        private static string ShowTags(List<string> tags)
        {
            string concatTags = "";
            int count = 1;

            foreach(var tag in tags)
            {
                if (count == tags.Count)
                    concatTags += tag;
                else
                    concatTags += tag + ", ";

                count++;
            }

            return concatTags;
        }

        private static void CreateVideo()
        {
            Console.WriteLine("\n--- Creació d'un nou video ---");
            string url = GetInputItemValidate(OutputsVideo["url"]);
            if (string.IsNullOrEmpty(url))
                return;
            string title = GetInputItemValidate(OutputsVideo["title"]);
            if (string.IsNullOrEmpty(title))
                return;

            Video video = new Video(Guid.NewGuid(), url, title);
            currentUser.Videos.Add(video);
            Console.WriteLine("\nEl video s'ha creat amb éxit.");
        }

        private static void ManagementVideo()
        {
            Console.Write("\n\n- Aquets son el videos que tens: ");
            ShowVideosUser();
            
            string title = GetInputItemValidate(OutputsVideo["title"]);
            if (string.IsNullOrEmpty(title))
                return;

            Video video = currentUser.Videos.Find(x => x.Title == title);
            
            if(video != null)
                MenuManageVideos(video);
            else
                Console.WriteLine("\nEl títol del video que has escrit no coincidex o no existeix\n");
        }

        private static void AddTag(Video video)
        {
            string tag = GetInputItemValidate(OutputsVideo["tag"]);
            if (string.IsNullOrEmpty(tag))
                return;

            video.Tags.Add(Console.ReadLine());
        }
    }
}
