using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class PauseVideo : Option
    {
        private Video _video;

        public PauseVideo(Video video)
            : base("Pausar vídeo.")
        {
            _video = video;
        }
        public override void Execute()
        {
            _video.Pause();
        }
    }
}
