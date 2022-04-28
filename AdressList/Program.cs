using System;
using System.Collections.Generic;

namespace AdressList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create and change adresses when reference type
            if (cReadNrAdresses(10, out List<cAdress> cMyFriends))
            {
                for (int i = 0; i < cMyFriends.Count; i++)
                {
                    cChangeToDenmark(cMyFriends[i]);
                    Console.WriteLine(cMyFriends[i]);
                 }
            }

            //Create and change adresses when value type
            if (sReadNrAdresses(10, out List<sAdress> sMyFriends))
            {
                for (int i = 0; i < sMyFriends.Count; i++)
                {
                    //Note country is not changed as sAdress is value type and a copy of the value is passed as parameter
                    sChangeToDenmark(sMyFriends[i]);

                    Console.WriteLine(sMyFriends[i]);
 
                    //I need to use the return value and insert that into array 
                    sMyFriends[i] = sChangeToDenmark(sMyFriends[i]);
                    Console.WriteLine(sMyFriends[i]);
                    Console.WriteLine();
                }
            }
        }

        #region cAdress is a reference type (class)
        //In parameter is of value type, out parameter is a reference type (List) contanting reference types (cAdress)
        public static bool cReadNrAdresses(int NrOfAddresses, out List<cAdress> adresses)
        {
            adresses = new List<cAdress>();

            //Simulate connection to database
            bool bdConnection = true;
            if (!bdConnection)
                return false;

            //Have a connection, simulate reading from the db
            for (int i = 0; i < NrOfAddresses; i++)
            {
                adresses.Add(cAdress.Factory.CreateRandom());
            }

            return bdConnection;
        }

        //Change all contries as adress is a reference type
        public static void cChangeToDenmark(cAdress adress)
        {
           adress.Country = "Denmark";
        }
        #endregion


        #region sAdress is a value types (struct)
        //In parameter is of value type, out parameter is a reference type (List) contanting reference types (cAdress)
        public static bool sReadNrAdresses(int NrOfAddresses, out List<sAdress> adresses)
        {
            adresses = new List<sAdress>();

            //Simulate connection to database
            bool bdConnection = true;
            if (!bdConnection)
                return false;

            //Have a connection, simulate reading from the db
            for (int i = 0; i < NrOfAddresses; i++)
            {
                adresses.Add(sAdress.Factory.CreateRandom());
            }

            return bdConnection;
        }

        //Change all contries as adress is a reference type
        public static sAdress sChangeToDenmark(sAdress adress)
        {
            adress.Country = "Denmark";
            return adress;
        }
        #endregion
    }
}
