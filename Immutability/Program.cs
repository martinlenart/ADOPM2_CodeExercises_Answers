using System;
using System.Collections.Generic;

namespace Immutability
{
    public enum CarMake { Volvo, BMW }
    public enum CarModel { Unknown, XC70, XC90, V70, V40, s300, s500, s700, Last }
    public class Car : IEquatable<Car>, IComparable<Car>
    {
        public CarMake Make { get; set; } = CarMake.Volvo;
        public CarModel Model { get; set; }
        public int Year { get; set; } = 2020;

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

        #region operator overload
        public static bool operator ==(Car c1, Car c2) => c1.Equals(c2);
        public static bool operator !=(Car c1, Car c2) => !c1.Equals(c2);
        #endregion

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

    //Immutability by class
    public class ImmutableCar : IEquatable<ImmutableCar>, IComparable<ImmutableCar>
    {
        public CarMake Make { get; init; } = CarMake.Volvo;
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

        #region operator overload
        public static bool operator ==(ImmutableCar c1, ImmutableCar c2) => c1.Equals(c2);
        public static bool operator !=(ImmutableCar c1, ImmutableCar c2) => !c1.Equals(c2);
        public override string ToString() => $"Make: {Make} Model: {Model} Year: {Year}";
        #endregion

        #region Property Change Methods
        public ImmutableCar SetMake(CarMake make) => new ImmutableCar(this) { Make = make };
        public ImmutableCar SetModel(CarModel model) => new ImmutableCar(this) { Model = model };
        public ImmutableCar SetYear(int year) => new ImmutableCar(this) { Year = year };
        #endregion

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

    //Immutability by record
    public record RecordCar(CarMake Make, CarModel Model, int Year);
    #endregion

 
    class Program
    {
        static void Main(string[] args)
        {
            var car1 = new Car { Make = CarMake.Volvo, Model = CarModel.XC90, Year = 2020 };
            var car2 = new ImmutableCar { Make = CarMake.Volvo, Model = CarModel.XC90, Year = 2020 };
            var car3 = new RecordCar (CarMake.Volvo, CarModel.XC90, 2020);

            Console.WriteLine("Immutability");
            //Lets change to a new car model
            car1.Make = CarMake.BMW;
            car1.Model = CarModel.s300;
            car1.Year = 2010;
            Console.WriteLine(car1);

            //Immutable class - car2 is unchanged
            var newcar = car2.SetMake(CarMake.BMW).SetModel(CarModel.s300).SetYear(2010);
            Console.WriteLine(car2);
            Console.WriteLine(newcar);
            Console.WriteLine();

            //Immutability by record
            var another_newcar = car3 with { Make = CarMake.BMW, Model = CarModel.s300, Year = 2010 };
            Console.WriteLine(car3);
            Console.WriteLine(another_newcar);


            //Deconstructor
            Console.WriteLine("\nDeconstructors");
            var (a1, b1, c1) = car1;
            Console.WriteLine($"{a1}, {b1}, {c1}");

            var (a2, b2, c2) = newcar;
            Console.WriteLine($"{a2}, {b2}, {c2}");

            var (a3, b3, c3) = another_newcar;
            Console.WriteLine($"{a3}, {b3}, {c3}");
        }
    }
}
