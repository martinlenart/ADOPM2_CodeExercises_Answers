using System;
using System.Collections.Generic;

namespace AdressList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IAdress> myFriends = new List<IAdress>();

            //myFriends.Add(new Adress { FirstName = "Martin", LastName = "Lenart", Country = "Sweden" });

            PrintMyFriends(myFriends);

        }

        static void PrintMyFriends(List<IAdress> adresses)
        {
            foreach (var item in adresses)
            {
                if (item.Country == "Sweden")
                {
                    Console.WriteLine(item.FirstName);
                }
            }
        }
    }
}
