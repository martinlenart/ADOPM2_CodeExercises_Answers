using System;
namespace GameProduct
{
	public class Inventory : IInventory
	{
		private List<GameProduct> _inventoryList;
		public GameProduct this[int idx]
        {
            get { return _inventoryList[idx]; }
        }
 
		public int StockCount => _inventoryList.Sum(i => i.StockLevel);
		public decimal StockValue
		{
			get
			{
				var value = 0M;
                foreach (var item in _inventoryList)
                {
					value += item.Price * item.StockLevel;
                }
				return value;
			}
		}

		public GameProduct Add (GameProduct prod)
		{
			_inventoryList.Add(prod);
			return prod;
		}

		public Inventory() { }
        
		public Inventory(int NrOfItems)
		{
			_inventoryList = GameProduct.CreateRandomList(NrOfItems);
		}
	}
}

