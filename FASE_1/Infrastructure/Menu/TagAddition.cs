using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class TagAddition : Option
    {
        private App _app;

        public TagAddition(App app)
            :base("Afegir tag.")
        {
            _app = app;
        }

        public override void Execute()
        {
            string tag = _app.GetInputItemValidate("Afegeix un tag (anular per sortir): ");
            if (string.IsNullOrEmpty(tag))
                return;

            //video.Tags.Add(Console.ReadLine());
        }
    }
}
