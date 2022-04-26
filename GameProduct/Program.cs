using System;

namespace GameProduct // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var ShopInventory = new Inventory(10_000);
            //IInventory ShopInventory = Inventory.CreateRandom(10_000);

            //Console.WriteLine($"I have {ShopInventory.InventoryList.Count} nr of different products");
            Console.WriteLine($"I have {ShopInventory.StockCount} products on stock");
            Console.WriteLine($"I have a stock value of {ShopInventory.StockValue:C2}");

            var item2 = ShopInventory[2];
            item2.Price = 0;
            item2.StockLevel = 0;

            Console.WriteLine();
            Console.WriteLine(ShopInventory[2]);

            ShopInventory.Add(GameProduct.CreateRandom());
 

            /*
            //Console.WriteLine(GameProduct.CreateRandom());
            //Console.WriteLine(GameProduct.CreateRandom());

            var gp = GameProduct.CreateRandom();
            var gp1 = new GameProduct(gp);
            var gp2 = new GameProduct(gp);


            Console.WriteLine(gp1.Equals(gp2));
            Console.WriteLine(gp1 == gp2);

            Console.WriteLine();
            Console.WriteLine(gp1);
            Console.WriteLine(gp2);



            Console.ReadKey();
            var games = GameProduct.CreateRandomList(10_000);
            Console.WriteLine($"Nr of Games: {games.Count()}");
            Console.ReadKey();

            games.Contains(gp1);

            games.Sort();
            foreach (var item in games.TakeLast(20))
            {
                Console.WriteLine(item);
            }
            */
        }
    }
}


