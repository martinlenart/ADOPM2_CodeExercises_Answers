using System;

namespace Constructors
{
    class Variables
    {
        public string Comment2 { get; init; }
        public readonly string Comment;
        public static readonly string s_Comment = "My database string for example";
        
        static Variables()
        {
            s_Comment = "Let's try";
        }
        public Variables()
        {
            Comment = "Oops default";
        }
        public Variables(string InitValue) : this()
        {
            Comment += InitValue;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myVar = new Variables { Comment2 = "Hej" };
            Console.WriteLine(myVar.Comment);
            Console.WriteLine(Variables.s_Comment);

        }
    }
}
