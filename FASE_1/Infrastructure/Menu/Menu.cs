using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure.Menu
{
    class Menu
    {
        private Dictionary<int,Option> _options;
        private int _quantity;
        private Exit _exit;

        public Menu()
        {
            _options = new Dictionary<int, Option>(); ;
            _quantity = 0;
            _exit = new Exit();
        }

        public void Add(Option option)
        {
            _options.Add(_quantity + 1, option);
            _quantity++;
        }

        public void Close()
        {
            this.Add(_exit);
        }

        public void CloseSesion()
        {
            _exit.TitleLogOut();
            this.Add(_exit);
        }

        public void Show()
        {
            foreach(var option in _options)
            {
                option.Value.Show(option.Key);
            }
        }

        public Option GetOption()
        {
            ManageIO manageIO = new ManageIO();
            int option;
            bool error = true;
            do
            {
                Console.Write("\nEscull una opció [1 - " + _quantity + "]: ");
                option = manageIO.inInt();
                error = !_options.ContainsKey(option);
                if (error)
                    Console.WriteLine("Error!!! La opció ha d'estar entre 1 y " + _quantity);
            } while (error);

            return _options[option];
        }

        public bool Finished()
        {
            return _exit.Executed();
        }
    }
}
