using FASE_1.Models;
using System;

namespace FASE_1.Infrastructure.Menu
{
    class VideoCreator : Option
    {
        private App _app;

        public VideoCreator(App app)
            :base("Crear vídeo.")
        {
            _app = app;
        }

        public override void Execute()
        {
            Console.WriteLine("\n--- Creació d'un nou video ---");
            string url = _app.GetInputItemValidate("Introdueix la URL del vídeo (anular per sortir): "); 
            if (string.IsNullOrEmpty(url))
                return;
            string title = _app.GetInputItemValidate("Introdueix el títol del vídeo (anular per sortir): ");
            if (string.IsNullOrEmpty(title))
                return;

            Video video = new Video(Guid.NewGuid(), url, title);
            _app.CurrentUser.Videos.Add(video);
            Console.WriteLine("\nEl video s'ha creat amb éxit.");

        }
    }
}
