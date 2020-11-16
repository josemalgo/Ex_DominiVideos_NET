using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class PauseVideo : Option
    {
        App _app;

        public PauseVideo(App app)
            : base("Pausar vídeo.")
        {
            _app = app;
        }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
