using System.Collections.Generic;

namespace tech.mohammad.amir.action
{
	using ReaderException = tech.mohammad.amir.common.exceptions.ReaderException;
	using tech.mohammad.amir.common.parsers;
	using ProductParser = tech.mohammad.amir.common.parsers.impl.ProductParser;
	using ProductPriceParser = tech.mohammad.amir.common.parsers.impl.ProductPriceParser;
	using FileUtils = tech.mohammad.amir.common.utils.FileUtils;
	using Product = tech.mohammad.amir.models.Product;
	using ProductPrice = tech.mohammad.amir.models.ProductPrice;


//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static tech.mohammad.amir.common.Constants.PRODUCT_CSV_FILE;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static tech.mohammad.amir.common.Constants.PRODUCT_PRICE_CSV_FILE;
	using static tech.mohammad.amir.io.impl.ConsoleWriter;

	public class BakeryProductStore
	{
		private static BakeryProductStore bakeryProductStore;
		private static IDictionary<string, Product> productMap;

		private BakeryProductStore()
		{
			loadProductMap();
			loadPriceInProductMap();
		}

		public static BakeryProductStore Instance
		{
			get
			{
				if (isNull(bakeryProductStore))
				{
					bakeryProductStore = new BakeryProductStore();
				}
    
				return bakeryProductStore;
			}
		}

		public virtual Product findProduct(string productCode)
		{
			return productMap[productCode];
		}

		private void loadProductMap()
		{
			try
			{
				Parser<Product> productParser = new ProductParser();
				productMap = productParser(FileUtils.readFileText(PRODUCT_CSV_FILE));
			}
			catch (ReaderException rex)
			{
				write(rex.Message);
			}
		}

		private void loadPriceInProductMap()
		{
			IDictionary<string, IList<ProductPrice>> productPriceMap = ProductPriceMap;
			populatePriceInProductMap(productPriceMap);
		}

		private IDictionary<string, IList<ProductPrice>> ProductPriceMap
		{
			get
			{
				try
				{
					Parser<IList<ProductPrice>> productPriceParser = new ProductPriceParser();
					return productPriceParser(FileUtils.readFileText(PRODUCT_PRICE_CSV_FILE));
				}
				catch (ReaderException rex)
				{
					write(rex.Message);
					return emptyMap();
				}
			}
		}

		private void populatePriceInProductMap(IDictionary<string, IList<ProductPrice>> productPriceMap)
		{
			productPriceMap.SetOfKeyValuePairs().forEach(this.populatePriceInProduct);
		}

		private void populatePriceInProduct(KeyValuePair<string, IList<ProductPrice>> productPriceEntry)
		{
			Product product = productMap[productPriceEntry.Key];

			productPriceEntry.Value.forEach(productPrice =>
			{
			product.addPricePack(productPrice.PackSize, productPrice.Price);
			});
		}
	}

}