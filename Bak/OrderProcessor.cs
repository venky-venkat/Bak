using System.Collections.Generic;
using System.Text;

namespace Bak
{
	//using InputException = tech.mohammad.amir.common.exceptions.InputException;
	//using tech.mohammad.amir.common.parsers;
	//using UserInputParser = tech.mohammad.amir.common.parsers.impl.UserInputParser;
	//using Product = tech.mohammad.amir.models.Product;

 

	public class OrderProcessor
	{
		 
		private Bakery bakery;

		public OrderProcessor(Bakery bakery)
		{
			this.bakery = bakery;
		}

		public virtual string process(string inputString)
		{
			if (!Constants.EXIT_COMMANDS.Contains(inputString.Trim()))
			{
				Dictionary<string, string> userInput = new Dictionary<string, string>();
				string[] input = inputString.Split(' ');
			 
				userInput.Add(input[0].ToString(), input[1].ToString());
				var cc = userInput.ToString();
				
				return cc; //userInput.SetOfKeyValuePairs().Select(this.generateOrderBill).collect(Collectors.joining(Constants.NEWLINE));
			 
			}
			else
			{
				bakery.close();
				return Constants.BAKERY_CLOSED_TEXT;
			}
		}

	 

		private IDictionary<int, int> calculateBill(Product product, int? quantity)
		{
			IDictionary<int, int> output = new Dictionary<int, int>();

			IList<int> packSizeList = product.SortedSupportedPackList;

			int q = quantity.Value;
			int start = 0;
			int packSize = 0;

			while (q > 0 && start < packSizeList.Count)
			{
				if (packSize > 0)
				{
					if (packSizeList.IndexOf(packSize) + 1 == packSizeList.Count)
					{
						packSize = packSizeList[0];
					}

					if (output.ContainsKey(packSize))
					{
						q = q + packSize;

						if (output[packSize] > 1)
						{
							output[packSize] = output[packSize] - 1;
						}
						else
						{
							output.Remove(packSize);
						}

						start = packSizeList.IndexOf(packSize) + 1;
					}
				}

				for (int i = start; i < packSizeList.Count; i++)
				{
					if (q / packSizeList[i] > 0)
					{
						packSize = packSizeList[i];
						output[packSize] = q / packSize;
						q = q % packSize;
					}
				}

				start++;
			}

			if (q > 0)
			{
				output.Clear();
			}

			return output;
		}

		private string printBill(IDictionary<int, int> output, Product product, int? quantity)
		{
			if (output.Count == 0)
			{
				return Constants.INVALID_INPUT_PRODUCT_COUNT;
			}
			else
			{
				StringBuilder outputBuffer = new StringBuilder();
				float totalOrderValue = 0f;

				foreach (int packSize in output.Keys)
				{
					totalOrderValue += output[packSize] * product.getPrice(packSize).Value;

					outputBuffer.Append(Constants.NEWLINE + Constants.TABSPACE + output[packSize] + Constants.MUL + packSize + Constants.CURRENCY + product.getPrice(packSize));
				}

				return quantity + Constants.SPACE + product + Constants.SPACE + Constants.CURRENCY + totalOrderValue + outputBuffer.ToString();
			}
		}
	}

}