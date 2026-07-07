using ECommerceSystem.Models;
using Microsoft.VisualBasic;
using System.Collections;
using System.Net;

namespace ECommerceSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a database context
            ECommerceContext context = new ECommerceContext();

            // Call the user registration function
            RegisterNewUser(context);
        }

        // Register a new user and save it to the database
        public static void RegisterNewUser(ECommerceContext context)
        {
            // Display the function title
            Console.WriteLine("=== Register New User ===");

            // Read user information from the console
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            // Create a new User object
            User newUser = new User();

            // Assign user input to object properties
            newUser.Username = username;
            newUser.Email = email;
            newUser.PasswordHash = password;
            newUser.FullName = fullName;
            newUser.PhoneNumber = phoneNumber;
            newUser.Address = address;

            // Set system-generated values
            newUser.RegistrationDate = DateTime.Now;
            newUser.IsActive = true;

            // Add the new user to the database
            context.Users.Add(newUser);

            // Save changes to the database
            context.SaveChanges();

            // Display the generated user ID
            Console.WriteLine("New User ID: " + newUser.UserId);
        }

        //Q2//

        // Add a new product to an existing category
        public static void AddNewProduct(ECommerceContext context)
        {
            // Display the function title
            Console.WriteLine("=== Add New Product ===");

            // Get all categories from the database
            var categories = context.Categories.ToList();

            // Display available categories
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId} - {category.CategoryName}");
            }
            // Read category ID from the user
            Console.Write("Enter Category ID: ");
            int categoryId = int.Parse(Console.ReadLine());

            // Read product information
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Stock Quantity: ");
            int stock = int.Parse(Console.ReadLine());

            Console.Write("Enter Image URL: ");
            string imageUrl = Console.ReadLine();

            // Create a new Product object
            Product newProduct = new Product();

            // Assign user input to product properties
            newProduct.ProductName = productName;
            newProduct.Description = description;
            newProduct.Price = price;
            newProduct.StockQuantity = stock;
            newProduct.ImageUrl = imageUrl;
            newProduct.CategoryId = categoryId;

            // Set system-generated values
            newProduct.CreatedAt = DateTime.Now;
            newProduct.IsAvailable = true;

            // Add the product to the database
            context.Products.Add(newProduct);

            // Save changes
            context.SaveChanges();

            // Display the generated product ID
            Console.WriteLine("New Product ID: " + newProduct.ProductId);

        }
        ////Q3//

        public static void PlaceAnOrder(ECommerceContext context)
        {
            // Display the function title
            Console.WriteLine("=== Place a New Order ===");

            // Read User ID
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());

            // Check if the user exists
            User user = context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            // Read shipping address
            Console.Write("Enter Shipping Address: ");
            string shippingAddress = Console.ReadLine();

            // Read payment method
            Console.Write("Enter Payment Method: ");
            string paymentMethod = Console.ReadLine();

            // Create a new Order object
            Order order = new Order();

            // Assign user input to order properties
            order.UserId = userId;
            order.ShippingAddress = shippingAddress;
            order.PaymentMethod = paymentMethod;

            // Set system generated/default values
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            order.TotalAmount = 0;

            // Add the order to the database
            context.Orders.Add(order);

            // Save the order first to generate OrderId
            context.SaveChanges();

            Console.WriteLine("New Order ID: " + order.OrderId);

            // Display all available products
            Console.WriteLine("\n=== Available Products ===");

            var products = context.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId} - {product.ProductName} - Price: {product.Price} OMR - Stock: {product.StockQuantity}");
            }

            // Allow the user to add multiple products
            bool addMore = true;

            while (addMore)
            {
                // Read Product ID
                Console.Write("\nEnter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                // Read Quantity
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                // Check if quantity is valid
                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                    continue;
                }

                // Find the selected product
                Product selectedProduct = context.Products.FirstOrDefault(p => p.ProductId == productId);

                // Check if the product exists
                if (selectedProduct == null)
                {
                    Console.WriteLine("Product not found.");
                    continue;
                }

                // Check stock availability
                if (quantity > selectedProduct.StockQuantity)
                {
                    Console.WriteLine("Not enough stock.");
                    continue;
                }

                // Create a new OrderItem
                OrderItem item = new OrderItem();

                // Assign values to OrderItem
                item.OrderId = order.OrderId;
                item.ProductId = selectedProduct.ProductId;
                item.Quantity = quantity;
                item.UnitPrice = selectedProduct.Price;

                // Add OrderItem to the database
                context.OrderItems.Add(item);

                // Calculate the order total
                order.TotalAmount += selectedProduct.Price * quantity;

                // Reduce product stock
                selectedProduct.StockQuantity -= quantity;

                // Ask the user if they want to add another product
                Console.Write("Add another product? (Y/N): ");
                string answer = Console.ReadLine();

                if (answer.ToUpper() != "Y")
                {
                    addMore = false;
                }
            }

            // Save all changes to the database
            context.SaveChanges();

            // Display confirmation message
            Console.WriteLine("\n================================");
            Console.WriteLine("Order placed successfully.");
            Console.WriteLine("Order ID: " + order.OrderId);
            Console.WriteLine("Total Amount: " + order.TotalAmount + " OMR");
            Console.WriteLine("================================");
        }

        ////Q4//
        public static void WriteProductReview(ECommerceContext context)
        {
            // Display function title
            Console.WriteLine("=== Write Product Review ===");

            // Display all users
            Console.WriteLine("\nAvailable Users:");

            var users = context.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId} - {user.FullName}");
            }

            // Display all products
            Console.WriteLine("\nAvailable Products:");

            var products = context.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductId} - {product.ProductName}");
            }

            // Read User ID
            Console.Write("\nEnter User ID: ");
            int userId = int.Parse(Console.ReadLine());

            // Read Product ID
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());

            // Read Rating
            Console.Write("Enter Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            // Validate rating
            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid Rating.");
                return;
            }

            // Read Comment
            Console.Write("Enter Comment: ");
            string? comment = Console.ReadLine();

            // Create Review object
            Review review = new Review();

            // Assign values
            review.UserId = userId;
            review.ProductId = productId;
            review.Rating = rating;
            review.Comment = comment;
            review.ReviewDate = DateTime.Now;

            // Add Review
            context.Reviews.Add(review);

            // Save changes
            context.SaveChanges();

            Console.WriteLine("Review added successfully.");
        }
        //////Q5//
        public static void UpdateProductPriceAndAvailability(ECommerceContext context)
        {
            // Display function title
            Console.WriteLine("=== Update Product Price and Availability ===");

            // Read Product ID
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());

            // Find the product
            Product product = context.Products.FirstOrDefault(p => p.ProductId == productId);

            // Check if the product exists
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            // Display current product information
            Console.WriteLine("Current Price: " + product.Price);
            Console.WriteLine("Current Availability: " + product.IsAvailable);

            // Read the new price
            Console.Write("Enter New Price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            // Read the new availability status
            Console.Write("Is the product available? (Y/N): ");
            string answer = Console.ReadLine();

            // Update product price
            product.Price = newPrice;

            // Update product availability
            if (answer.ToUpper() == "Y")
            {
                product.IsAvailable = true;
            }
            else
            {
                product.IsAvailable = false;
            }

            // Save changes to the database
            context.SaveChanges();

            // Display confirmation message
            Console.WriteLine("Product updated successfully.");
        }
        //Q6//

        //Q7//
        public static void DeleteReview(ECommerceContext context)
        {
            // Display function title
            Console.WriteLine("=== Delete Review ===");

            // Read Review ID
            Console.Write("Enter Review ID: ");
            int reviewId = int.Parse(Console.ReadLine());

            // Find the review
            Review review = context.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);

            // Check if the review exists
            if (review == null)
            {
                Console.WriteLine("Review not found.");
                return;
            }

            // Remove the review from the database
            context.Reviews.Remove(review);

            // Save changes
            context.SaveChanges();

            // Display confirmation message
            Console.WriteLine("Review deleted successfully.");
        }
    }
}