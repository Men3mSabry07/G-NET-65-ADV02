using System;

namespace G_NET_65_ADV02_
{
    internal class Program
    {
        static List<Product> catalog = new()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
            new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };

        #region Q1 - Smart Product Search
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> condition)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
                if (condition(product)) result.Add(product);

            return result;
        }

        #endregion

        #region Q3.1 - Print Reports
        static void PrintReport(List<Product> products, Action<Product> reportAction)
        {
            foreach (Product product in products) reportAction(product);
        }

        #endregion

        #region Q3.2 - Transform Products

        static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> func)
        {
            List<TResult> result = new List<TResult>();
            foreach (Product product in products)
                result.Add(func(product));

            return result;
        }

        #endregion

        #region Q3.3 - Filter Products

        static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
                if (condition(product)) result.Add(product);

            return result;
        }

        #endregion

        static void Main(string[] args)
        {
            #region Q1 - Smart Product Search

            // 1.1 All Electronics products
            List<Product> electronicsProducts =
                SearchProducts(catalog, p => p.Category == "Electronics");

            Console.WriteLine("Electronics Products:");
            foreach (Product product in electronicsProducts)
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");

            // 1.2 Products cheaper than $50
            List<Product> cheapProducts =
                SearchProducts(catalog, p => p.Price < 50);

            Console.WriteLine("\nProducts Cheaper than $50:");
            foreach (Product product in cheapProducts)
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");

            // 1.3 Products that are in stock
            List<Product> inStockProducts =
                SearchProducts(catalog, p => p.Stock > 0);

            Console.WriteLine("\nProducts In Stock:");
            foreach (Product product in inStockProducts)
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");

            // 1.4 Clothing products under $100
            List<Product> affordableClothing =
                SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);

            Console.WriteLine("\nClothing Products Under $100:");
            foreach (Product product in affordableClothing)
                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");

            #endregion

            #region Q3.1 - Print Reports

            // 3.1.1 Short Report
            Console.WriteLine("\nShort Report:");
            PrintReport(catalog,
                p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            // 3.1.2 Detailed Report
            Console.WriteLine("\nDetailed Report:");
            PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));

            #endregion

            #region Q3.2 - Transform Products

            // 3.2.1 Product Summary
            List<string> summary = TransformProducts(catalog, p => $"{p.Name} (${p.Price})");

            Console.WriteLine("\nSummary List:");
            foreach (string item in summary) Console.WriteLine(item);

            // 3.2.2 Product Price Labels
            List<string> priceLabels = TransformProducts(catalog, p => p.Price > 100 ? "Expensive!" : "Affordable");

            Console.WriteLine("\nPrice Labels:");
            for (int i = 0; i < catalog.Count; i++)
                Console.WriteLine($"{catalog[i].Name}: {priceLabels[i]}");

            #endregion

            #region Q3.3 - Filter Products

            // 3.3.1 Low-Stock Alert
            List<Product> lowStockProducts = FilterProducts(catalog, p => p.Stock < 20);

            Console.WriteLine("\nLow-Stock Alerts:");
            foreach (Product product in lowStockProducts)
                Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");

            #endregion
        }
    }
}