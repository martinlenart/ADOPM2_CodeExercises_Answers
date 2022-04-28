using System;

namespace ValueRef
{
    class Program
    {
        struct Astruct
        {
            public int MyInt { get; set; }
        }
        class Aclass
        {
            public int MyInt { get; set; }
        }

        static void Main(string[] args)
        {
                      
        }

        static void DoSomething0(int a, out int b)
        {
            b = a * 2;
            a = a * 10;
        }
        static void DoSomething1(int a, out Aclass outB)
        {
            outB = new Aclass { MyInt = a*2 };
            a = a * 10;
        }

        static void DoSomething3(int a, Astruct myA)
        {
            myA.MyInt = a;
        }

        static void DoSomething1(int[] array)
        {
            array[3] = 5;
        }
        static void DoSomething2(int a, int[] array)
        {
            array = new int[25];
            array[3] = a;
        }
         static void DoSomething4(int a, Aclass myB)
        {
             myB.MyInt = a;
        }
        static void DoSomething5(int a, Aclass myB)
        {
            myB = new Aclass();
            myB.MyInt = a;
        }
    }
}
