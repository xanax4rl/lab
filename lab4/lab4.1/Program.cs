using System;


    // Class Wheel
    class Wheel
    {
        public string Model { get; set; }

        public Wheel(string model)
        {
            Model = model;
        }
    }

    // Class Engine
    class Engine
    {
        public string Type { get; set; }

        public Engine(string type)
        {
            Type = type;
        }
    }

    // Class Car
    class Car
    {
        public string Brand { get; set; }
        public Wheel FrontWheel { get; set; }
        public Wheel RearWheel { get; set; }
        public Engine Engine { get; set; }

        public Car(string brand, Wheel frontWheel, Wheel rearWheel, Engine engine)
        {
            Brand = brand;
            FrontWheel = frontWheel;
            RearWheel = rearWheel;
            Engine = engine;
        }

        public void Drive()
        {
            Console.WriteLine("The car is driving.");
        }

        public void Refuel()
        {
            Console.WriteLine("The car is refueling.");
        }

        public void ChangeWheel(Wheel oldWheel, Wheel newWheel)
        {
            if (oldWheel == FrontWheel)
            {
                FrontWheel = newWheel;
            }
            else if (oldWheel == RearWheel)
            {
                RearWheel = newWheel;
            }
            Console.WriteLine("The wheel has been replaced.");
        }

        public void PrintBrand()
        {
            Console.WriteLine($"Car brand: {Brand}");
        }
    }

    
    public class Program
    {
        static void Main()
        {
            // Example usage
            Wheel frontWheel = new Wheel("Summer");
            Wheel rearWheel = new Wheel("Summer");
            Wheel newWheel = new Wheel("Summer");
            Engine engine = new Engine("Petrol");
            Car car = new Car("Mercedes", frontWheel, rearWheel, engine);

            car.Drive();
            car.Refuel();
            car.ChangeWheel(rearWheel,newWheel);
            car.PrintBrand();
        }
    }
    