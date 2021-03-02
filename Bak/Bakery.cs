using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bak
{
   public class Bakery
    {
		//private Reader reader = UserInputReader.Instance;
		private OrderProcessor orderProcessor;

		private bool open_Conflict;

		public virtual void open()
		{
			this.open_Conflict = true;
			orderProcessor = new OrderProcessor(this);

			while (open_Conflict)
			{
				Console.WriteLine(Constants.ORDER_TEXT);
				Console.WriteLine(orderProcessor.process(Console.ReadLine()));
				Console.WriteLine(Constants.LINE);
			}
		}

		public virtual void close()
		{
			this.open_Conflict = false;
		}
	}
}
