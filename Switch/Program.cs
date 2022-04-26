using System;
using System.Collections.Generic;

namespace Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            //var i = 4;
            var i = 5;
            switch (i)
            {
                case 4:
                case 5:
                    Console.WriteLine("Hello 4 and 5");
                    Console.WriteLine("And I could do something else here");
                    break;
                case 6:
                    Console.WriteLine("Hello exactly 6");
                    Console.WriteLine("And I could do something else here");
                    break;
                default:
                    Console.WriteLine("Default");
                    Console.WriteLine("And I could do something else here");
                    break;
            }

            string s = i switch
            {
                4 => "Hello4",
                5 => "Hello5",
                6 => "Hello6",
                _ => "Default"
            };

            Console.WriteLine($"\n{s}");
        }
    }
}
