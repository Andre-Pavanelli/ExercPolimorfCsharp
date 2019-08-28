using System;
using System.Collections.Generic;
using System.Globalization;
using ExercicioPolProduct.Entities;

namespace ExercicioPolProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            //estanciando uma lista de objetos do tipo product
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data");
                Console.Write("Common, used or imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'c')
                {
                    list.Add(new Product(name, price));
                }
                else if(ch == 'i')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, customsFee));
                }
                else if(ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");
            foreach(Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
