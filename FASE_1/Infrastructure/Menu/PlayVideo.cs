using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class PlayVideo : Option
    {
        App _app;

        public PlayVideo(App app)
            :base("Reproduir vídeo.")
        {
            _app = app;
        }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
