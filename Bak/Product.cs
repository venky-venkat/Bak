using System.Collections.Generic;
using System.Linq;

namespace Bak
{

	public class Product
	{
		private string code;
		private string name;
		private IDictionary<int, float> priceByPackMap;

		public Product(string code, string name)
		{
			this.code = code;
			this.name = name;
			this.priceByPackMap = new Dictionary<int, float>();
		}

		public virtual string Code
		{
			get
			{
				return code;
			}
		}

		public virtual string Name
		{
			get
			{
				return name;
			}
		}

		public virtual float? getPrice(int packSize)
		{
			return priceByPackMap[packSize];
		}

		public virtual void addPricePack(int packSize, float? price)
		{
			this.priceByPackMap[packSize] = price.Value;
		}

        public virtual IList<int> SortedSupportedPackList
        {
            get
            {
                return priceByPackMap.Keys.OrderBy(getPrice).ToList();
            }
        }

        public override string ToString()
		{
			return code + "-" + name;
		}
	}

}