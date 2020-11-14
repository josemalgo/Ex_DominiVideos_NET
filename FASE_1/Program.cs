using FASE_1.Infrastructure;
using FASE_1.Infrastructure.Menu;
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
        private App app;
        private Menu menu;

        private Program()
        {
            app = new App();
            menu = new Menu();
            menu.Add(new LoginUserOption(app));
            menu.Add(new RegisterUserOption(app));
            menu.Close();
        }

        private void Start()
        {
            do
            {
                Console.WriteLine("\n--- Menú inici aplicació ---");
                menu.Show();
                menu.GetOption().Execute();
            } while (!menu.finished());
        } 

        static void Main(string[] args)
        {
            new Program().Start();
        }

        #region Menús i opcions menús

        //private static void MenuUsuariOptions()
        //{
        //    Console.WriteLine("\n--- Menú d'usuari ---");
        //    Console.WriteLine("a - Veure llistat videos.");
        //    Console.WriteLine("b - Crear nou video.");
        //    Console.WriteLine("c - Gestionar video.");
        //    Console.WriteLine("d - Tanca Sessió.");
        //}

        //private static void MenuUsuari()
        //{
        //    bool keepdoing = true;

        //    do
        //    {
        //        MenuUsuariOptions();
        //        char option = Console.ReadKey().KeyChar;

        //        switch (option)
        //        {
        //            case 'a':
        //                ShowVideosUser();
        //                break;
        //            case 'b':
        //                CreateVideo();
        //                break;
        //            case 'c':
        //                ManagementVideo();
        //                break;
        //            case 'd':
        //                Console.WriteLine("\nFins aviat!");
        //                keepdoing = false;
        //                break;
        //            default:
        //                Console.WriteLine("\nLa opció no es válida!\n");
        //                break;
        //        }

        //    } while (keepdoing);
        //}

        //private static void MenuManageVideosOptions()
        //{
        //    Console.WriteLine("\n--- Menú video ---");
        //    Console.WriteLine("a - Afegir tags.");
        //    Console.WriteLine("b - Reproduir.");
        //    Console.WriteLine("c - Pausar.");
        //    Console.WriteLine("d - Parar.");
        //    Console.WriteLine("e - Sortir.");
        //}

        //private static void MenuManageVideos(Video video)
        //{
        //    bool keepdoing = true;

        //    do
        //    {
        //        MenuManageVideosOptions();
        //        char option = Console.ReadKey().KeyChar;

        //        switch (option)
        //        {
        //            case 'a':
        //                AddTag(video);
        //                break;
        //            case 'b':
        //                video.Play();
        //                break;
        //            case 'c':
        //                video.Pause();
        //                break;
        //            case 'd':
        //                video.Stop();
        //                break;
        //            case 'e':
        //                Console.WriteLine("\nSortim del video.");
        //                keepdoing = false;
        //                break;
        //            default:
        //                Console.WriteLine("\nLa opció no es válida!\n");
        //                break;
        //        }

        //    } while (keepdoing);
        //}

        #endregion

        #region Validacion Inputs

        



        

        #endregion

        //private static void ShowVideosUser()
        //{
        //    if (currentUser.Videos.Count == 0)
        //    {
        //        Console.WriteLine("\nNo tens cap video per mostrar");
        //        return;
        //    }

        //    Console.WriteLine();
        //    foreach (var video in currentUser.Videos)
        //    {
        //        Console.WriteLine("\n- Títol: " + video.Title + " - Tags: " + ShowTags(video.Tags));
        //    }
        //}

        //private static string ShowTags(List<string> tags)
        //{
        //    string concatTags = "";
        //    int count = 1;

        //    foreach(var tag in tags)
        //    {
        //        if (count == tags.Count)
        //            concatTags += tag;
        //        else
        //            concatTags += tag + ", ";

        //        count++;
        //    }

        //    return concatTags;
        //}

        //private static void CreateVideo()
        //{
        //    Console.WriteLine("\n--- Creació d'un nou video ---");
        //    string url = GetInputItemValidate(OutputsVideo["url"]);
        //    if (string.IsNullOrEmpty(url))
        //        return;
        //    string title = GetInputItemValidate(OutputsVideo["title"]);
        //    if (string.IsNullOrEmpty(title))
        //        return;

        //    Video video = new Video(Guid.NewGuid(), url, title);
        //    currentUser.Videos.Add(video);
        //    Console.WriteLine("\nEl video s'ha creat amb éxit.");
        //}

        //private static void ManagementVideo()
        //{
        //    Console.Write("\n\n- Aquets son el videos que tens: ");
        //    ShowVideosUser();
            
        //    string title = GetInputItemValidate(OutputsVideo["title"]);
        //    if (string.IsNullOrEmpty(title))
        //        return;

        //    Video video = currentUser.Videos.Find(x => x.Title == title);
            
        //    if(video != null)
        //        MenuManageVideos(video);
        //    else
        //        Console.WriteLine("\nEl títol del video que has escrit no coincidex o no existeix\n");
        //}

        //private static void AddTag(Video video)
        //{
        //    string tag = GetInputItemValidate(OutputsVideo["tag"]);
        //    if (string.IsNullOrEmpty(tag))
        //        return;

        //    video.Tags.Add(Console.ReadLine());
        //}
    }
}
