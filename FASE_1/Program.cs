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
                        Console.Write("\nEscriu un tag pel video: ");
                        video.Tags.Add(Console.ReadLine());
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

        private static void Register()
        {
            Console.WriteLine("\n-- Registre d'usuari --");
            Console.Write("Introduiex el nom d'usuari: ");
            string userName = Console.ReadLine();
            Console.Write("Introduiex el teu nom: ");
            string name = Console.ReadLine();
            Console.Write("Introduiex el teu cognom: ");
            string surname = Console.ReadLine();
            Console.Write("Introduiex la contraseña: ");
            string password = Console.ReadLine();

            //TODO: Validacions camps introduïts
            if(ValidateFields(userName) && ValidateFields(name) && ValidateFields(surname) && ValidateFields(password))
            {
                if (ValidateUserExist(userName))
                {
                    Guid id = Guid.NewGuid();
                    User newUser = new User(id, userName, name, surname, password, DateTime.Today);
                    _users.Add(id, newUser);
                    Console.WriteLine("\nUsuari registrat amb éxit!\nYa podeu iniciar sessió.");
                    Login();
                }
                else
                {
                    Console.WriteLine("\nEl nom d'usuari que has introduït ya existeix.");
                }
            }
        }

        private static bool ValidateUserExist(string userName)
        {
            foreach (var user in _users)
            {
                if(user.Value.UserName == userName)
                {
                    return false;
                }
            }

            return true;
        }

        private static void Login()
        {
            Console.WriteLine("\n-- Inici de sessió --");
            Console.Write("Introduiex el nom d'usuari: ");
            string userName = Console.ReadLine();
            Console.Write("Introduiex la contraseña: ");
            string password = Console.ReadLine();

            if (ValidateUserLogin(userName, password))
            {
                MenuUsuari();
            }
            else
                Console.WriteLine("\nL'usuari i/o contraseña incorrectes.");
        }

        private static bool ValidateUserLogin(string userName, string password)
        {
            if (ValidateFields(userName) && ValidateFields(password))
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
                Console.WriteLine("- Títol: " + video.Title + " - Tags: " + ShowTags(video.Tags));
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
            Console.WriteLine("\n-- Creació d'un nou video --");
            Console.Write("Introduiex la URL: ");
            string url = Console.ReadLine();
            Console.Write("Introduiex el títol: ");
            string title = Console.ReadLine();

            if(ValidateFields(url) && ValidateFields(title))
            {
                Guid id = new Guid();
                Video video = new Video(id, url, title);

                if (currentUser.CreateVideo(video))
                    Console.WriteLine("\nEl video s'ha creat amb éxit.");
            }
        }

        private static void ManagementVideo()
        {
            Console.Write("\nAquets son el videos que tens: ");
            ShowVideosUser();
            Console.Write("\nEscriu el títol del video que vols veure: ");
            Video video = currentUser.Videos.Find(x => x.Title == Console.ReadLine());
            
            if(video != null)
            {
                MenuManageVideos(video);
            }
            else
            {
                Console.WriteLine("\nEl títol del video que has escrit no coincidex o no existeix");
            }
        }

        private static bool ValidateFields(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Replace(" ", "") == "")
            {
                Console.WriteLine("\nNo pot haber cap camp buit!");
                return false;
            }

            return true;
        }
    }
}
