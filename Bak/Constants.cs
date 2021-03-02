using System.Collections.Generic;

namespace Bak
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static Arrays.asList;

	public class Constants
	{
		public static readonly IList<string> EXIT_COMMANDS = new List<string> {"EXIT", "exit", "0"};
		public const string PRODUCT_CSV_FILE = "product.csv";
		public const string PRODUCT_PRICE_CSV_FILE = "product_price.csv";
		public const string CURRENCY = "$";
		public const string SPACE = " ";
		public const string TABSPACE = "\t";
		public const string NEWLINE = "\n";
		public const string MUL = " X ";
		public const string LINE = "------------------------------------------------------------";
		public static readonly string ORDER_TEXT = "Please place your order.(Type EXIT, exit, 0 to exit).";
		public const string BAKERY_CLOSED_TEXT = "BAKERY CLOSED";
		public const string INVALID_USER_INPUT = "Invalid User Input";
		public const string INVALID_PRODUCT_CODE = "Invalid Product Code";
		public const string CSV_READING_ERROR = "Error while reading csv:";
		public const string INVALID_INPUT_PRODUCT_COUNT = "Invalid Product count";
	}

}