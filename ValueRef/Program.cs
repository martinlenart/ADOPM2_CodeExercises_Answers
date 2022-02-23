using System;

namespace ValueRef
{
    class Program
    {
        struct A
        {
            public int MyInt { get; set; }
        }
        class B
        {
            public int MyInt { get; set; }
        }

        static void Main(string[] args)
        {
            (string, int, float)[] mySuperTuppleArray = new (string, int, float)[5];

            
            
            int a = 0;
            B myB1 = null;
            Console.WriteLine(a);
            DoSomething0(a, out myB1);
            Console.WriteLine(a);
            Console.WriteLine(myB1.MyInt);

            Console.WriteLine();

            var myA = new A { MyInt = 0 };
            Console.WriteLine(myA.MyInt);
            DoSomething2(myA);
            Console.WriteLine(myA.MyInt);

            var myB = new B { MyInt = 0 };
            Console.WriteLine(myB.MyInt);
            DoSomething3(myB);
            Console.WriteLine(myB.MyInt);

            /*
            Console.WriteLine();
            int[] myArray = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"myArray[3] = {myArray[3]}");
            DoSomething1(myArray);
            Console.WriteLine($"myArray[3] = {myArray[3]}");
            */
        }

        static void DoSomething0(int a, out B outB)
        {
            a = 5;
            outB = new B { MyInt = 15 };
        }
        static void DoSomething1(int[] array)
        {
            array = new int[25];
            array[3] = 5;
        }
        static void DoSomething2(A myA)
        {
            myA.MyInt= 5;
        }
        static void DoSomething3(B myB)
        {
            myB = new B();
            myB.MyInt = 5;

        }

    }
}
