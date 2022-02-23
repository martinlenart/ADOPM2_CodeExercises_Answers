using System;
using System.Collections.Generic;

namespace Immutability
{
    public enum CarMake { Volvo }
    public enum CarModel { First, XC70, XC90, V70, V40, Last }
    public class Car : IEquatable<Car>, IComparable<Car>
    {
        public CarMake Make { get; } = CarMake.Volvo;
        public CarModel Model { get; init; }
        public int Year { get; init; } = 2020;

        public int CompareTo(Car other)
        {
            if (Model != other.Model)
                return Model.CompareTo(other.Model);

            return Year.CompareTo(other.Year);
        }
        public bool Equals(Car other) => (this.Make, this.Model, this.Year) == (other.Make, other.Model, other.Year);

        #region legacy .NET compliance
        public override bool Equals(object obj) => Equals(obj as Car);
        public override int GetHashCode() => (this.Make, this.Model, this.Year).GetHashCode();

        #endregion

        public static bool operator ==(Car c1, Car c2) => c1.Equals(c2);
        public static bool operator !=(Car c1, Car c2) => !c1.Equals(c2);
        public override string ToString() => $"Make: {Make} Model: {Model} Year: {Year}";

        public Car() { }
        public Car(Car org)
        {
            Make = org.Make;
            Model = org.Model;
            Year = org.Year;
        }

        public void Deconstruct(out CarMake Make, out CarModel Model, out int Year)
        {
            Make = this.Make;
            Model = this.Model;
            Year = this.Year;
        }

    }

    #region Immutable versions of Car
    public class ImmutableCar : IEquatable<ImmutableCar>, IComparable<ImmutableCar>
    {
        public CarMake Make { get; } = CarMake.Volvo;
        public CarModel Model { get; init; }
        public int Year { get; init; } = 2020;

        public int CompareTo(ImmutableCar other)
        {
            if (Model != other.Model)
                return Model.CompareTo(other.Model);
            
            return Year.CompareTo(other.Year);
        }
        public bool Equals(ImmutableCar c1) => (this.Make, this.Model, this.Year) == (c1.Make, c1.Model, c1.Year);

        #region legacy .NET compliance
        public override bool Equals(object obj) => Equals(obj as ImmutableCar);
        public override int GetHashCode() => (this.Make, this.Model, this.Year).GetHashCode();

        #endregion

        public static bool operator ==(ImmutableCar c1, ImmutableCar c2) => c1.Equals(c2);
        public static bool operator !=(ImmutableCar c1, ImmutableCar c2) => !c1.Equals(c2);
        public override string ToString() => $"Make: {Make} Model: {Model} Year: {Year}";

        public ImmutableCar() { }
        public ImmutableCar(ImmutableCar org)
        {
            Make = org.Make;
            Model = org.Model;
            Year = org.Year;
        }

        public void Deconstruct(out CarMake Make, out CarModel Model, out int Year)
        {
            Make = this.Make;
            Model = this.Model;
            Year = this.Year;
        }

    }
    public record RecordCar(CarMake Make, CarModel Model, int Year);
    #endregion

    public class Cars
    {
        List<ImmutableCar> myCars = new List<ImmutableCar>();

        public ImmutableCar this[int idx] => myCars[idx];
        public override string ToString()
        {
            string sRet = "";
            for (int i = 0; i < myCars.Count; i++)
            {
                sRet += $"{myCars[i]}\n";
                if ((i + 1) % 10 == 0)
                    sRet += "\n";
            }
            return sRet;
        }

        public void Sort()
        { 
            myCars.Sort(); 
        }

        public Cars(int Count)
        {
            var rnd = new Random();
            for (int i = 0; i < Count; i++)
            {
                var model = (CarModel)rnd.Next((int)CarModel.First + 1, (int)CarModel.Last);
                var year = rnd.Next(1990, 2022);

                myCars.Add(new ImmutableCar { Model = model, Year = year });

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new ImmutableCar();
            var car2 = new ImmutableCar(car1);

            Console.WriteLine(car1);
            Console.WriteLine(car2);

            Console.WriteLine(car1 == car2); //false
            Console.WriteLine(ImmutableCar.Equals(car1, car2)); //true

            (var myModel, _, var myYear) = car2;
            Console.WriteLine(myYear);

            var car3 = new RecordCar(CarMake.Volvo, CarModel.XC70, 2020);
            var car4 = car3;
            var car5 = car3 with { Year = 1990 };


            Console.WriteLine();
            var myCars = new Cars(30);
            myCars.Sort();
            Console.WriteLine(myCars);

            Console.WriteLine();
            Console.WriteLine(myCars[5]);

        }
    }
}
