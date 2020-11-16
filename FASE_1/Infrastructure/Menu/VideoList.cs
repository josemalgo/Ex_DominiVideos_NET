using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class VideoList : Option
    {
        private App _app;

        public VideoList(App app)
            : base("Llistat dels vídeos.")
        {
            _app = app;
        }

        public override void Execute()
        {
            Console.WriteLine();
            _app.CurrentUser.ShowListVideos();
        }
        
    }
}
