using System;
using System.Collections.Generic;

namespace Inheritance
{
    public class Chef
    {
        public string Name { get; set; } = "Boring";
        public virtual string Hello => "I'm boring!";
        public virtual string FavoriteDish => "I have none";
    }
    public class FrenchChef : Chef
    {
        public override string Hello => "Bonjour";
        public override string FavoriteDish => "Escargot";
        public override string ToString() => $"{Hello} my name is {Name}";
    }
    public sealed class ItalianChef : Chef
    {
        public new string Hello => "Ciao";
        public new string FavoriteDish => "Pizza";
        public override string ToString() => $"{Hello} my name is {Name}";
    }
    public class SwedishChef : Chef
    {
        public new string Hello => "Hej";
        public new string FavoriteDish => "Meatballs";
        public override string ToString() => $"{Hello} my name is {Name}";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var chef = new Chef();
            Console.WriteLine(chef.Name);
            Console.WriteLine(chef.Hello);
            Console.WriteLine(chef.FavoriteDish);

            Console.WriteLine();
            FrenchChef french = new FrenchChef { Name = "Jean-Pierre" };
            Console.WriteLine(french.Name);
            Console.WriteLine(french.Hello);
            Console.WriteLine(french.FavoriteDish);

            Console.WriteLine();
            Chef french2 = french;
            Console.WriteLine(french2.Name);
            Console.WriteLine(french2.Hello);
            Console.WriteLine(french2.FavoriteDish);

            Console.WriteLine();
            var french3 = french as Chef;
            Console.WriteLine(french3.Name);
            Console.WriteLine(french3.Hello);
            Console.WriteLine(french3.FavoriteDish);

            Console.WriteLine();
            var french4 = chef as FrenchChef;
            Console.WriteLine(french4?.Name);
            Console.WriteLine(french4?.Hello);
            Console.WriteLine(french4?.FavoriteDish);
        }
    }
}
