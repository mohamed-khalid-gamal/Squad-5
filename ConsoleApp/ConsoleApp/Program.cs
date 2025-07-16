namespace ConsoleApp
{
	internal class Program
	{
		static ProductService productService = new ProductService();

		static void Main(string[] args)
		{

			int choice;
			do
			{
				ShowMenu();
				choice = GetChoice();

				switch (choice)
				{
					case 1: AddProduct(); break;
					case 2: ListAllProducts(); break;
					case 3: SearchByName(); break;
					case 4: UpdateProduct(); break;
					case 5: DeleteProduct(); break;
					case 6: GetProductById(); break;
					case 7: ListByCategory(); break;
					case 8: ListByPriceRange(); break;
					case 0: Console.WriteLine("Exiting..."); break;
					default: Console.WriteLine("Invalid choice."); break;
				}

			} while (choice != 0);
		}

		static void ShowMenu()
		{
			Console.WriteLine("\n--- Product Management ---");
			Console.WriteLine("1. Add Product");
			Console.WriteLine("2. List All Products");
			Console.WriteLine("3. Search Product by Name");
			Console.WriteLine("4. Update Product");
			Console.WriteLine("5. Delete Product");
			Console.WriteLine("6. Get Product by ID");
			Console.WriteLine("7. List by Category");
			Console.WriteLine("8. List by Price Range");
			Console.WriteLine("0. Exit");
		}

		static int GetChoice()
		{
			Console.Write("Enter your choice: ");
			int.TryParse(Console.ReadLine(), out int choice);

			return choice;
		}

		static void AddProduct()
		{
			string name = ReadString("Enter product name: ");
			decimal price = ReadDecimal("Enter price: ");
			int catId = ReadInt("Enter category ID: ");

			var product = productService.CreateProduct(name, price, catId);
			Console.WriteLine($"Created successfully: {product}");
		}

		static void ListAllProducts()
		{
			var products = productService.GetAllProducts();
			PrintProducts(products);
		}

		static void SearchByName()
		{
			string name = ReadString("Enter name to search: ");
			var products = productService.SearchProductsByName(name);
			PrintProducts(products);
		}

		static void UpdateProduct()
		{
			int id = ReadInt("Enter product ID to update: ");
			var product = productService.GetProductById(id);
			if (product == null)
			{
				Console.WriteLine("Product not found.");
				return;
			}

			var newName = ReadString("New name: ");
			var newPrice = ReadDecimal("New price: ");
			var newCatId = ReadInt("New category Id: ");

			bool isUpdated = productService.UpdateProduct(id, newName, newPrice, newCatId);


			Console.WriteLine(isUpdated ? "Updated successfully" : "An error occure while update product");
		}

		static void DeleteProduct()
		{
			int id = ReadInt("Enter product ID to delete: ");
			bool IsDeleted = productService.DeleteProduct(id);
			Console.WriteLine(IsDeleted ? "Deleted successfully." : "Not found.");
		}

		static void GetProductById()
		{
			int id = ReadInt("Enter product ID: ");
			var product = productService.GetProductById(id);
			Console.WriteLine(product != null ? product.ToString() : "Not found.");
		}

		static void ListByCategory()
		{
			int catId = ReadInt("Enter category ID: ");
			var products = productService.GetProductsByCategory(catId);
			PrintProducts(products);
		}

		static void ListByPriceRange()
		{
			decimal min = ReadDecimal("Enter minimum price: ");
			decimal max = ReadDecimal("Enter maximum price: ");
			var products = productService.GetProductsByPriceRange(min, max);
			PrintProducts(products);
		}

		static void PrintProducts(System.Collections.Generic.List<Product> products)
		{
			if (products.Count == 0)
			{
				Console.WriteLine("No products found.");
				return;
			}

			Console.WriteLine("\n=================");
			Console.WriteLine("Results");
			Console.WriteLine("=================\n");
			foreach (var product in products)
				Console.WriteLine(product);
		}

		static string ReadString(string message)
		{
			string input;
			do
			{
				Console.Write(message);
				input = Console.ReadLine();

			} while (string.IsNullOrWhiteSpace(input));

			return input;
		}

		static int ReadInt(string message)
		{
			while (true)
			{
				Console.Write(message);
				if (int.TryParse(Console.ReadLine(), out int result))
					return result;
				Console.WriteLine("Enter a valid number.");
			}
		}

		static decimal ReadDecimal(string message)
		{
			while (true)
			{
				Console.Write(message);
				if (decimal.TryParse(Console.ReadLine(), out decimal result))
					return result;
				Console.WriteLine("Enter a valid price.");
			}
		}
	}
}
