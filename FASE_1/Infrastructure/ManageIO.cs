using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure
{
    public class ManageIO
    {
		public string inString()
		{
            string input = string.Empty;
            try
			{
				input = Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error!! El valor introduit no és vàlid!");
			}
			return input;
		}

		public int inInt()
		{
			int input = 0;
			try
			{
				input = int.Parse(this.inString());
			}
			catch (Exception e)
			{
				Console.WriteLine("Error!! Has d'introduir un número!");
			}
			return input;
		}
	}
}
