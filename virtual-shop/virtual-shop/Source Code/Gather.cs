using System;
using System.Text.Json;

namespace virtual_shop.SourceCode
{
	public class Gather
	{
        public static List<Product> AllProducts()
        {
            Products products = new();

            try
            {
                products = JsonSerializer.Deserialize<Products>(File.ReadAllText("Data/Products.json"));
                products.ProductList = SetIDs(products.ProductList);
            }
            catch
            {
                Console.WriteLine($"Unable to deserialize data from file at path: Data/Products.json into type {products.GetType()}");
            }

            return products.ProductList;
        }

        public static List<Product> SetIDs(List<Product> productList)
        {
            for (int productIndex = 0; productIndex < productList.Count; productIndex++)
            {
                productList[productIndex].id = productIndex + 1;
            }

            return productList;
        }
    }
}

