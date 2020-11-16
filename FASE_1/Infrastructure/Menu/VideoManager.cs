using FASE_1.Models;
using System;

namespace FASE_1.Infrastructure.Menu
{
    class VideoManager : Option
    {
        private App _app;
        private Menu _menuManagerVideo; 

        public VideoManager(App app, Menu menuManagerVideo)
            : base("Gestionar vídeo.")
        {
            _app = app;
            _menuManagerVideo = menuManagerVideo;
        }

        public override void Execute()
        {
            Console.Write("\n\n- Aquets son el videos que tens: ");
            //ShowVideosUser();

            string title = _app.GetInputItemValidate("Introdueix el títol del vídeo (anular per sortir): ");
            if (string.IsNullOrEmpty(title))
                return;

            Video video = _app.CurrentUser.Videos.Find(x => x.Title == title);

            if (video != null)
                ShowMenuManagerVideo(video);
            else
                Console.WriteLine("\nEl títol del video que has escrit no coincidex o no existeix\n");
        }

        private void ShowMenuManagerVideo(Video video)
        {
            //TODO: añadir menu aqui??? Per pasar el vídeo seleccionat?
            do
            {
                _menuManagerVideo.Show();
                _menuManagerVideo.GetOption().Execute();
            } while (!_menuManagerVideo.Finished());
        }
    }
}
