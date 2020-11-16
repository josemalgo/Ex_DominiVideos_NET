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
            if (_app.CurrentUser.Videos.Count == 0)
            {
                Console.WriteLine("\nNo tens cap video per mostrar");
                return;
            }

            Console.WriteLine();
            foreach (var video in _app.CurrentUser.Videos)
            {
                Console.WriteLine("\n- Títol: " + video.Title + " - Tags: " + ShowTags(video.Tags));
            }
        }
        private string ShowTags(List<string> tags)
        {
            string concatTags = "";
            int count = 1;

            foreach (var tag in tags)
            {
                if (count == tags.Count)
                    concatTags += tag;
                else
                    concatTags += tag + ", ";

                count++;
            }

            return concatTags;
        }
    }
}
