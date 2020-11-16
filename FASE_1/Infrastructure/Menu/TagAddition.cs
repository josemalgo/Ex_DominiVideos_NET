using FASE_1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class TagAddition : Option
    {
        private App _app;
        private Video _video; 

        public TagAddition(App app, Video video)
            :base("Afegir tag.")
        {
            _app = app;
            _video = video;
        }

        public override void Execute()
        {
            string tag = _app.GetInputItemValidate("Afegeix un tag (anular per sortir): ");
            if (string.IsNullOrEmpty(tag))
                return;

            _video.AddTag(tag);
        }
    }
}
