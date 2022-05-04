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
            /*
            var Ac = new Aclass();

            int a = 10;
            int b;
            DoSomething0(a, out b);
            Console.WriteLine($"a:{a}, b:{b}");

            a = 10;
            As.MyInt = 10;
            DoSomething3(a, As);
            Console.WriteLine($"a:{a}, As.MyInt:{As.MyInt}");
            

            int i = 0;
            bool b1 = true;
            float f = 0F;
            double d = 0D;

            double myPi;
            SetValues(i, b1, f, d, out myPi);
            SetValues(0, true, 10.10F, 10.10D, out double myPi2);

            Console.WriteLine($"i:{i}, b1:{b1}, f:{f}, d:{d}, myPi: {myPi}, myPi2:{myPi2}");
            */

            var As = new Astruct { MyInt=4 };
            var Ac = new Aclass { MyInt = 4 };
            int a = 4;
            int[] myArray = { 1, 2, 3, 4 };
            DoSomething1(a, myArray, As, Ac);
            Console.WriteLine($"a:{a}, myArray[3]:{myArray[3]}, As.MyInt:{As.MyInt}, Ac.MyInt:{Ac.MyInt}");

        }

        //Some Methods to test
        static void DoSomething1(int a, int[] array, Astruct astruct, Aclass aclass)
        {
            a = 5;
            array[3] = 5;
            astruct.MyInt = 5;
            aclass.MyInt = 5;
        }







/*
        public static void SetValues(int i, bool b, float f, double d, out double pi)
        {
            i = 10;
            b = false;
            f = 10.10F;
            d = 10.10D;
            Console.WriteLine($"i:{i}, b:{b}, f:{f}, d:{d}");
            pi = Math.PI;


        }
        static void DoSomething0(int in1, out int z1)
        {
            in1 = 100;
            z1 = 100;
        }
        static void DoSomething3(int a, Astruct myA)
        {
            a = 100;
            myA.MyInt = 100;
        }


        static void DoSomething1(int a, out Aclass outB)
        {
            outB = new Aclass { MyInt = a * 2 };
            a = a * 10;
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
        */
    }
}
