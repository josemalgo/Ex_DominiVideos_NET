using FASE_1.Infrastructure;
using FASE_1.Infrastructure.Menu;
using FASE_1.Models;
using System;
using System.Collections.Generic;

namespace FASE_1
{
    class Program
    {
        static void Main(string[] args)
        {
            new App().Start();
        }

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
        //    
        //}
    }
}
