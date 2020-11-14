using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class Exit : Option
    {
        private bool _executed;

        public Exit() : 
            base("Exit")
        {
            _executed = false;
        }

        public override void Execute()
        {
            _executed = true;
        }

        public bool Executed()
        {
            return _executed;
        }
    }
}
