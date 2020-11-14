using System;
using System.Collections.Generic;
using System.Text;

namespace FASE_1.Infrastructure
{
    public class ManageIO
    {
		public string inString()
		{
			string input = null;
			try
			{
				input = Console.ReadLine();
			}
			catch (Exception e)
			{
				this.Exit();
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
				this.Exit();
			}
			return input;
		}

		private void Exit()
		{
			Console.WriteLine("ERROR d'entrada/sortida!");
			Environment.Exit(0);
		}
	}
}
