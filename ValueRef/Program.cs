using System;
using System.Collections.Generic;

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
            var As = new Astruct { MyInt=4 };
            var Ac = new Aclass { MyInt = 4 };
            int a = 4;
            int[] myArray = { 1, 2, 3, 4 };

            DoSomething1(a, myArray, As, Ac);
            Console.WriteLine($"a:{a}, myArray[3]:{myArray[3]}, As.MyInt:{As.MyInt}, Ac.MyInt:{Ac.MyInt}");
            //a:4, myArray[3]:5, As.MyInt:4, Ac.MyInt:5


            DoSomething1a(a, myArray, As, Ac,
                out int b1, out int[] b1array, out Astruct b1struct, out Aclass b1class);
            Console.WriteLine($"\na:{a}, myArray[3]:{myArray[3]}, As.MyInt:{As.MyInt}, Ac.MyInt:{Ac.MyInt}, " +
                $"b1:{b1}, b1array[3]:{b1array[3]}, b1struct.MyInt:{b1struct.MyInt}, b1class.MyInt:{b1class.MyInt}");
            //a:4, myArray[3]:5, As.MyInt:4, Ac.MyInt:5, b1:10, b1array[3]:40, b1struct.MyInt:10, b1class.MyInt:10


            int[] iArray1 = { 1, 2, 3, 4 };
            int[] iArray2 = { 9, 8, 7, 6 };
            DoSomething1b(iArray1, iArray2);
            Console.WriteLine($"\niArray1[0]:{iArray1[0]}, iArray2[0]:{iArray2[0]}");
            //iArray1[0]:10, iArray2[0]:9

            int i1 = 4;
            int i2 = 4;
            DoSomething1c(i1, ref i2);
            Console.WriteLine($"\ni1:{i1}, i2:{i2}");
            //i1:4, i2:2147483647

            int[] iArray3 = { 1, 2, 3, 4 };
            int[] iArray4 = { 9, 8, 7, 6 };
            DoSomething1d(iArray3, ref iArray4);
            Console.WriteLine($"\niArray3[0]:{iArray3[0]}, iArray4[0]:{iArray4[0]}");
            //iArray3[0]:1, iArray4[0]:10
        }

        //values of all value types (int, struct) will be copied into the params
        //References of all reference types (array, class) will be copied
        //Only the objects on the heap can be changed from the methos to the caller
        static void DoSomething1(int a, int[] array, Astruct astruct, Aclass aclass)
        {
            a = 5;
            array[3] = 5;
            astruct.MyInt = 5;
            aclass.MyInt = 5;
        }


        //I can pass any type as an out parameter. Either value or reference is passed
        static void DoSomething1a(int a, int[] array, Astruct astruct, Aclass aclass,
                                  out int b, out int[] barray, out Astruct bstruct, out Aclass bclass)
        {
            a = 5;
            array[3] = 5;
            astruct.MyInt = 5;
            aclass.MyInt = 5;

            b = 10;
            barray = new int[] { 10, 20, 30, 40 };
            bstruct = new Astruct { MyInt = 10 };
            bclass = new Aclass { MyInt = 10 };
        }

        //passing and changing reference types
        static void DoSomething1b(int[] array1, int[] array2)
        {
            array1[0] = 10;         //array1 is referenceing same object on the heap as the caller
                                    //Hence array from caller is changed

            array2 = new int[] { 10, 20, 30, 40, 50 };  //array2 is now referencing a new object on the heap.
                                                        //thrown away when leaving scope
                                                        //Hence caller array not modfied 
        }

        //passing value types and ref to value types
        static void DoSomething1c (int a1, ref int a2)
        {
            a1 = int.MaxValue;      //Value type. trown away when leaving scope
            a2 = int.MaxValue;      //Ref of a value type - refers to original variable of caller
                                    //Hence caller variable  changes
        }

        //passing reference types and ref to reference types
        static void DoSomething1d(int[] array1, ref int[] array2)
        {
            array1 = new int[] { 10, 20, 30, 40, 50};  //New instance referred to, will be thrown away when leaving scope
            array2 = new int[] { 10, 20, 30, 40, 50};  //Ref of refernce type - refers to original variable of caller
                                                       //Hence caller variable changes
        }
    }
}
