using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeWithMilk = new CoffeeWithMilk(new Coffee(), 3);
            var coffeeWithChocolate = new CoffeeWithChocolate(new Coffee(), 7);

            var coffeeWithChocolateAndMilk = new CoffeeWithChocolate(coffeeWithMilk, 7);

            Console.WriteLine("Total for coffee with milk: " + coffeeWithMilk.GetPrice());
            Console.WriteLine("Total for coffee with chocolate: " + coffeeWithChocolate.GetPrice());
            Console.WriteLine("Total for coffee with milk + chocolate: " + coffeeWithChocolateAndMilk.GetPrice());

        }

        private interface ICoffee
        {
            int GetPrice();
        }

        private class Coffee : ICoffee
        {
            public int GetPrice()
            {
                return 15;
            }
        }

        //Decorator 1
        private class CoffeeWithMilk : ICoffee
        {
            private ICoffee _coffee;
            private int _priceOfMilk;

            public CoffeeWithMilk(ICoffee coffee, int priceOfMilk)
            {
                _coffee = coffee;
                _priceOfMilk = priceOfMilk;
            }

            public int GetPrice()
            {
                return _coffee.GetPrice() + _priceOfMilk;
            }
        }

        //Decorator 2
        private class CoffeeWithChocolate : ICoffee
        {
            private ICoffee _coffee;
            private int _priceOfChocolate;

            public CoffeeWithChocolate(ICoffee coffee, int priceOfChocolate)
            {
                _coffee = coffee;
                _priceOfChocolate = priceOfChocolate;
            }

            public int GetPrice()
            {
                return _coffee.GetPrice() + _priceOfChocolate;
            }
        }
    }
}
