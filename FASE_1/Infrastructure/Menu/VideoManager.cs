using FASE_1.Models;
using System;

namespace FASE_1.Infrastructure.Menu
{
    class VideoManager : Option
    {
        private readonly App _app;
        private readonly Menu _menuManagerVideo; 

        public VideoManager(App app)
            : base("Gestionar vídeo.")
        {
            _app = app;
            _menuManagerVideo = new Menu();
        }

        public override void Execute()
        {
            Console.Write("\n- Aquets son el videos que tens: ");
            _app.CurrentUser.ShowListVideos();

            string title = _app.GetInputItemValidate("\nIntrodueix el títol del vídeo que vols gestionar (anular per sortir): ");
            if (string.IsNullOrEmpty(title))
                return;

            Video newVideo = _app.CurrentUser.SearchVideoByTitle(title);

            if (newVideo != null)
                ShowMenuManagerVideo(newVideo);
            else
                Console.WriteLine("\nEl títol del video que has escrit no coincidex o no existeix\n");
        }

        private void ShowMenuManagerVideo(Video video)
        {
            _menuManagerVideo.Add(new TagAddition(_app, video));
            _menuManagerVideo.Add(new PlayVideo(video));
            _menuManagerVideo.Add(new PauseVideo(video));
            _menuManagerVideo.Add(new StopVideo(video));
            _menuManagerVideo.Close();

            do
            {
                Console.WriteLine("\n--- Menú gestió vídeo ---");
                _menuManagerVideo.Show();
                _menuManagerVideo.GetOption().Execute();
            } while (!_menuManagerVideo.Finished());
        }
    }
}
