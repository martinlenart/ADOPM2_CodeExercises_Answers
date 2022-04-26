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
                      
            int a = 0;
            Aclass myAclass = null;
            Console.WriteLine(a);
            DoSomething0(a, out myAclass);
            Console.WriteLine(a);
            Console.WriteLine(myAclass.MyInt);
            Console.WriteLine();

            var myAstruct = new Astruct { MyInt = 0 };
            Console.WriteLine(myAstruct.MyInt);
            DoSomething1(myAstruct);
            Console.WriteLine(myAstruct.MyInt);

            myAclass = new Aclass { MyInt = 0 };
            Console.WriteLine(myAclass.MyInt);
            DoSomething2(myAclass);
            Console.WriteLine(myAclass.MyInt);
            Console.WriteLine();

            int[] myArray = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"myArray[3] = {myArray[3]}");
            DoSomething3(myArray);
            Console.WriteLine($"myArray[3] = {myArray[3]}");
        }

        static void DoSomething0(int a, out Aclass outB)
        {
            a = 5;
            outB = new Aclass { MyInt = 15 };
        }
        static void DoSomething3(int[] array)
        {
            array = new int[25];
            array[3] = 5;
        }
        static void DoSomething1(Astruct myA)
        {
            myA.MyInt= 5;
        }
        static void DoSomething2(Aclass myB)
        {
            myB = new Aclass();
            myB.MyInt = 5;
        }
    }
}
