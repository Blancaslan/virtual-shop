using System;
using System.Globalization;
using System.Reflection;

namespace virtual_shop.SourceCode
{
	public class Display
	{
		public static void Product(Product _Product)
		{
            Console.WriteLine("\nName:\t" + _Product.Name);
            Console.WriteLine("Price:\t£" + _Product.SellPrice);
			Console.WriteLine("Qty:\t" + _Product.Quantity);
        }

		public static void Products(Products _Products)
		{
			for (int _Index = 0; _Index < _Products.ProductList.Count; _Index++)
			{
				Product(_Products.ProductList[_Index]);
			}
		}

		public static void Recipt(List<Product> products)
		{
			Console.Clear();
			Console.WriteLine("\nDennis Ltd");
			Console.WriteLine("\n----------\n");

			foreach (Product product in products)
			{
				Console.WriteLine($"{product.Name} Qty: {product.Quantity}");
				Console.WriteLine($"\t£{product.SellPrice * product.Quantity}");
			}

            Console.WriteLine("\n----------\n");
            Console.WriteLine($"Total: £{Basket.BasketTotal(products)}");
		}

		public static void AllBasket(List<Product> _Basket)
		{
			Console.Clear();
			foreach(Product _Product in _Basket)
			{
				Product(_Product);
			}

			if (_Basket.Count == 0)
				Console.WriteLine("Nothing In Basket.");

			Console.WriteLine("\nPress Any Key To Continue.");
			Console.ReadKey();
		}

		public static void BasketManagementOptions(int _UserIndex)
		{
			Console.Clear();
			List<string> _Options = new() { "Add Item", "Sub Item", "Show Basket", "Quit    "};
			for (int _OptionIndex = 0; _OptionIndex < _Options.Count; _OptionIndex++)
			{
				if (_OptionIndex == _UserIndex)
					Console.WriteLine(_Options[_OptionIndex] + "\t[0]");
				else
					Console.WriteLine(_Options[_OptionIndex] + "\t[ ]");
			}
		}

		public static void ListProducts(int userIndex)
		{
            Console.Clear();
            Products products = new();
			products.ProductList = Gather.AllProducts();

			for (int productIndex = 0; productIndex < products.ProductList.Count; productIndex++)
			{
                if (productIndex == userIndex)
                    Console.WriteLine(products.ProductList[productIndex].Name + "\t\t[0]");
                else
                    Console.WriteLine(products.ProductList[productIndex].Name + "\t\t[ ]");
            }
		}

		public static void RunOptions(int userIndex)
		{
			Console.Clear();
			List<string> options = new() { "basket", "Receipt" };

			for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
			{
                if (optionIndex == userIndex)
                    Console.WriteLine(options[optionIndex] + "\t[0]");
                else
                    Console.WriteLine(options[optionIndex] + "\t[ ]");
            }
        }
	}
}

