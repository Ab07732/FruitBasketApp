using System;
using System.Collections.Generic;
using System.Xml;

namespace FruitBasketApp
{
    class Fruit
    {
        public string Name { get; }
        public string Color { get; }
        public int length {  get; }
        public decimal Weight { get; }
        public decimal Price { get; }

        public Fruit(string name, string color, decimal weight, decimal price)
        {
            Name = name;
            Color = color;
            Weight = weight;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Color: {Color}, Weight: {Weight}g, Length: {length} Price: ${Price}";
        }
    }

    class Apple : Fruit
    {
        public string Type { get; }

        public Apple(string type, string color, decimal weight, decimal price) : base("Apple", color, weight, price)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Type: {Type}, {base.ToString()}";
        }
    }

    class Banana : Fruit
    {
        public string Type { get; }

        public Banana(string type, string color, int length, decimal weight, decimal price) : base("Banana", color, weight, price)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Type: {Type}, {base.ToString()}";
        }
    }

    class Orange : Fruit
    {
        public string Type { get; }

        public Orange(string type, string color, decimal weight, decimal price) : base("Orange", color, weight, price)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Type: {Type}, {base.ToString()}";
        }
    }

    class Pear : Fruit
    {
        public string Variety { get; }

        public Pear(string variety, string color, decimal weight, decimal price) : base("Pear", color, weight, price)
        {
            Variety = variety;
        }

        public override string ToString()
        {
            return $"Variety: {Variety}, {base.ToString()}";
        }
    }

    class FruitBasket
    {
        private List<Fruit> fruits;
        private const int MaxCapacity = 10;

        public FruitBasket()
        {
            fruits = new List<Fruit>();

        }

        public void AddFruit(Fruit fruit, int quantity)
        {
            if (fruits.Count + quantity <= MaxCapacity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    fruits.Add(fruit);
                }
                Console.WriteLine($"{quantity} {fruit.Name}s added to the basket.");

            }
            else
            {
                Console.WriteLine($"Cannot add {quantity} {fruit.Name}. Basket is full. Cannot add more fruit. Press 6 to see basket contents.");
            }
            
        }

        public void DisplayBasket()
        {
            Console.WriteLine("\nFruit Basket Contents:");
            decimal totalWeight = 0;
            decimal totalPrice = 0;
            
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
                totalPrice += fruit.Price;
                totalWeight += fruit.Weight;
            }

            Console.WriteLine($"Total Price: ${totalPrice}");
            Console.WriteLine($"Total Weight: {totalWeight}g");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FruitBasket basket = new FruitBasket();
            List<string> allowedFruits = new List<string> { "apple", "banana", "orange", "pear", "kiwi" };

            Console.WriteLine("Welcome to the Fruit Basket App!");

            while (true)
            {
                Console.WriteLine("\nChoose a fruit to add:");
                Console.WriteLine("1. Apple");
                Console.WriteLine("2. Banana");
                Console.WriteLine("3. Orange");
                Console.WriteLine("4. Pear");
                Console.WriteLine("5. Kiwi");
                Console.WriteLine("6. Display basket contents");
                Console.WriteLine("7. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nChoose type of apple:");
                        Console.WriteLine("1. Granny Smith");
                        Console.WriteLine("2. Red Delicious");
                        Console.WriteLine("3. Gala");
                        int appleChoice;
                            if (!int.TryParse(Console.ReadLine(), out appleChoice) || appleChoice < 1 || appleChoice > 3)
                        {
                            Console.WriteLine("Invalid choice. Please choose again.");
                            continue;
                        }
                        Console.WriteLine("Enter quantity:");
                        int appleQuantity;
                        if (!int.TryParse(Console.ReadLine(), out appleQuantity) || appleQuantity < 1)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a number greater than 0.");
                            continue;
                        }
                        switch (appleChoice)
                        {
                            case 1:
                                basket.AddFruit(new Apple("Granny Smith", "Green", 150, 1.2m), appleQuantity);
                                break;
                            case 2:
                                basket.AddFruit(new Apple("Red Delicious", "Red", 180, 1.4m), appleQuantity);
                                break;
                            case 3:
                                basket.AddFruit(new Apple("Gala", "Yellow", 170, 1.3m), appleQuantity);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nChoose size of banana");
                        Console.WriteLine("1. Small");
                        Console.WriteLine("2. Medium");
                        Console.WriteLine("3. Large");
                        int bananaChoice;
                        if (!int.TryParse(Console.ReadLine(),out bananaChoice) || bananaChoice < 1 || bananaChoice > 3)
                        {
                            Console.WriteLine("Invalid choice. Please choose again.");
                            continue;
                        }
                        Console.WriteLine("Enter quantity:");
                        int bananaQuantity;
                        if (!int.TryParse(Console.ReadLine(), out bananaQuantity) || bananaQuantity < 1)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a number greater than 0.");
                            continue;
                        }
                        switch (bananaChoice)
                        {
                            case 1:
                                basket.AddFruit(new Banana("Large", "Yellow", 12, 140, 1m),bananaQuantity);
                                break;
                            case 2:
                                basket.AddFruit(new Banana("Medium", "Yellow", 8, 140, .75m),bananaQuantity);
                                break;
                            case 3:
                                basket.AddFruit(new Banana("Small", "Yellow", 5, 140, .5m), bananaQuantity);
                                break;
                        }
                        break;
                    case 3:
                        //basket.AddFruit(new Fruit("Orange", "Orange", 180, 1.5m));
                        Console.WriteLine("\nChoose variety of orange:");
                        Console.WriteLine("1. Mandarin");
                        Console.WriteLine("2. Clementine");
                        Console.WriteLine("3. Naval");
                        int orangeChoice;
                        if (!int.TryParse(Console.ReadLine(), out orangeChoice) || orangeChoice < 1 || orangeChoice > 3)
                        {
                            Console.WriteLine("Invalid choice. Please choose again.");
                            continue;
                        }
                        Console.WriteLine("Enter quantity:");
                        int orangeQuantity;
                        if (!int.TryParse(Console.ReadLine(), out orangeQuantity) || orangeQuantity < 1)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a number greater than 0.");
                            continue;
                        }
                        switch (orangeChoice)
                        {
                            case 1:
                                basket.AddFruit(new Orange("Mandarin", "Orange", 200, 1.0m),orangeQuantity);
                                break;
                            case 2:
                                basket.AddFruit(new Orange("Clementine", "Orange", 180, 1.1m),orangeQuantity);
                                break;
                            case 3:
                                basket.AddFruit(new Orange("Naval", "Orange", 190, 1.2m), orangeQuantity);
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nChoose variety of pear:");
                        Console.WriteLine("1. Bartlett");
                        Console.WriteLine("2. Anjou");
                        Console.WriteLine("3. Bosc");
                        int pearChoice;
                        if (!int.TryParse(Console.ReadLine(), out pearChoice) || pearChoice < 1 || pearChoice > 3)
                        {
                            Console.WriteLine("Invalid choice. Please choose again.");
                            continue;
                        }
                        Console.WriteLine("Enter quantity:");
                        int pearQuantity;
                        if (!int.TryParse(Console.ReadLine(), out pearQuantity) || pearQuantity < 1)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a number greater than 0.");
                            continue;
                        }
                        switch (pearChoice)
                        {
                            case 1:
                                basket.AddFruit(new Pear("Bartlett", "Green", 200, 1.0m),pearQuantity);
                                break;
                            case 2:
                                basket.AddFruit(new Pear("Anjou", "Red", 180, 1.1m),pearQuantity);
                                break;
                            case 3:
                                basket.AddFruit(new Pear("Bosc", "Brown", 190, 1.2m),pearQuantity);
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter kiwi quantity:");
                        int kiwiQuantity;
                        if (!int.TryParse(Console.ReadLine(), out kiwiQuantity) || kiwiQuantity < 1)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a number greater than 0.");
                            continue;
                        }
                        basket.AddFruit(new Fruit("Kiwi", "Brown", 80, 1.3m), kiwiQuantity);
                        break;
                    case 6:
                        basket.DisplayBasket();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }
            }
        }
    }
}
