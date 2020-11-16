using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class PlayVideo : Option
    {
        private Video _video;

        public PlayVideo(Video video)
            :base("Reproduir vídeo.")
        {
            _video = video;
        }
        public override void Execute()
        {
            _video.Play();
        }
    }
}
