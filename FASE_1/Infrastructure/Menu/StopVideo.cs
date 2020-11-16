using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class StopVideo : Option
    {
        Video _video;

        public StopVideo(Video video)
            : base("Parar vídeo.")
        {
            _video = video;
        }
        public override void Execute()
        {
            _video.Stop();
        }
    }
}
