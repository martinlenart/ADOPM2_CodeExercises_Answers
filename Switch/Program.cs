using System;
using System.Collections.Generic;

namespace Switch
{
    class Program
    {
        public class A
        {
            List<int> myInts = new List<int>();

            public string this[int idx] => "Hello";
            public A()
            {
                for (int i = 0; i < 10; i++)
                {
                    myInts.Add(i);
                }
            }
        }
        static void Main(string[] args)
        {
            var myA = new A();
            Console.WriteLine(myA[int.MaxValue]);
            
            Console.WriteLine("Hello World!");

            var i = 5;
            switch (i)
            {
                case 4:
                case 5: Console.WriteLine("Hello 5");
                    Console.WriteLine("Hello 5");
                    break;
                case 6:
                    Console.WriteLine("Hello 6");
                    Console.WriteLine("Hello 6");
                    break;
                default: Console.WriteLine("Default");
                    break;
            }

            string s = i switch
            {
                4 => "Hello4",
                5 => "Hello5",
                6 => "Hello6",
                _ => "Default"
            };
        }
    }
}
