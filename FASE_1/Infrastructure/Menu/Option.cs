using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    abstract class Option
    {
        protected string title;

        protected Option(string title)
        {
            this.title = title;
        }

        public void Show(int position)
        {
            Console.WriteLine(position + " - " + title);
        }

        public abstract void Execute();
    }
}
