using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class StopVideo : Option
    {
        App _app;

        public StopVideo(App app)
            : base("Parar vídeo.")
        {
            _app = app;
        }
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
