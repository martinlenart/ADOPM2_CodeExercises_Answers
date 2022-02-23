using System;

namespace Kata2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDateCollection = new MemberList(50);
            myDateCollection.Sort();
            
            Console.WriteLine(myDateCollection);

            Console.WriteLine();
        }
    }
}
