public class InventoryItem
{
    // Properties
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        // Initializing the properties with the values passed to the constructor.
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Methods

    // Update the price of the item
    public void UpdatePrice(double newPrice)
    {
        // Update the item's price with the new price.
        Price = newPrice;
    }

    // Restock the item
    public void RestockItem(int additionalQuantity)
    {
        // Increase the item's stock quantity by the additional quantity.
        QuantityInStock += additionalQuantity;
    }

    // Sell an item
    public void SellItem(int quantitySold)
    {
        // Decrease the item's stock quantity by the quantity sold.

        // Below we are checking if the input quantity is less than or equal to current stock 
        // if not we won't change the Quantity, this will prevent the total quantity to be always positive value
        if (quantitySold <= QuantityInStock)
        {
            // Displaying the number of items sold if available in stock and reducing the total stock
            QuantityInStock -= quantitySold;
            Console.WriteLine($"{quantitySold} {ItemName}(s) sold.");
        }
        else
        {
            Console.WriteLine($"Insufficient stock. Unable to sell {quantitySold} {ItemName}(s).");
        }
    }

    // Check if an item is in stock
    public bool IsInStock()
    {
        // Return true if the item is in stock (quantity > 0), otherwise false.
        if (QuantityInStock > 0)
            return true;
        else
            return false;
    }

    // Print item details
    public void PrintDetails()
    {
        // Print the details of the item (name, id, price, and stock quantity).
        Console.WriteLine($"Name  :    {ItemName}");
        Console.WriteLine($"ID    :    {ItemId}");
        Console.WriteLine($"Price :    {Price}");
        Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        Console.WriteLine("\nWelcome to Inventory Management");

        // Implementing logic to interact with these objects.
        // User interaction loop
        int exit = 1;
        while (exit != 0)
        {
            // Displaying Menu for the user to select
            Console.WriteLine("*********************************");
            Console.WriteLine("1. Print details of all items");
            Console.WriteLine("2. Sell items");
            Console.WriteLine("3. Restock an item");
            Console.WriteLine("4. Check if an item is in stock");
            Console.WriteLine("5. Update the price of an item");
            Console.WriteLine("6. Exit");
            Console.WriteLine("*********************************");

            // Read user input and continue as pet user choice
            Console.Write("\nEnter an option to continue: ");
            string userinput = Console.ReadLine();

            // Switch case for each functionality of the methods provided above
            switch (userinput)
            {
                // Printing all the info of the items using PrintDetails method
                case "1":
                    Console.WriteLine("     Item 1");
                    item1.PrintDetails();
                    Console.WriteLine("\n     Item 2");
                    item2.PrintDetails();
                    break;

                // Using SellItem method to sell the items
                case "2":
                    Console.WriteLine("Which item do you want to sell?");
                    Console.WriteLine("1. Laptop");
                    Console.WriteLine("2. Smartphone");
                    Console.Write("Enter your choice (1 or 2): ");
                    string itemChoice = Console.ReadLine();

                    // Update the corresponding item stock after selling number of item
                    // provided by user
                    switch (itemChoice)
                    {
                        // To sell and update the Quantity in Stock of Laptop
                        case "1":
                            Console.Write("Enter the quantity of laptops to sell: ");
                            int sellQuantityLaptop = int.Parse(Console.ReadLine());
                            item1.SellItem(sellQuantityLaptop);
                            break;
                        // To sell and update the Quantity in Stock of Smartphone
                        case "2":
                            Console.Write("Enter the quantity of smartphones to sell: ");
                            int sellQuantitySmartphone = int.Parse(Console.ReadLine());
                            item2.SellItem(sellQuantitySmartphone);
                            break;
                        // Invalid input Handling
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;

                // To Restock the number of items in the inventory using RestockItem Method
                case "3":
                    Console.WriteLine("Which item do you want to restock?");
                    Console.WriteLine("1. Laptop");
                    Console.WriteLine("2. Smartphone");
                    Console.Write("Enter your choice (1 or 2): ");
                    string restockChoice = Console.ReadLine();

                    switch (restockChoice)
                    {
                        // Restocking the Laptops as per user input
                        case "1":
                            Console.Write("Enter the quantity of laptops to restock: ");
                            int restockQuantityLaptop = int.Parse(Console.ReadLine());
                            item1.RestockItem(restockQuantityLaptop);
                            break;
                        // Restocking the Smartphones as per user input
                        case "2":
                            Console.Write("Enter the quantity of smartphones to restock: ");
                            int restockQuantitySmartphone = int.Parse(Console.ReadLine());
                            item2.RestockItem(restockQuantitySmartphone);
                            break;
                        // Invalid input handling
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;

                // To check if the items are in stock or not in the inventory using IsInStock method
                case "4":
                    Console.WriteLine($"Laptop: {(item1.IsInStock() ? "In stock" : "Out of stock")}");
                    Console.WriteLine($"Smartphone: {(item2.IsInStock() ? "In stock" : "Out of stock")}");
                    break;

                // To update the price of an item in the inventory using UpdatePrice method
                case "5":
                    Console.WriteLine("Which item's price do you want to update?");
                    Console.WriteLine("1. Laptop");
                    Console.WriteLine("2. Smartphone");
                    Console.Write("Enter your choice (1 or 2): ");
                    string priceUpdateChoice = Console.ReadLine();

                    switch (priceUpdateChoice)
                    {
                        // Updating the Laptop Price to new price provided by user
                        case "1":
                            Console.Write("Enter the new price for the Laptop: ");
                            double newLaptopPrice = double.Parse(Console.ReadLine());
                            item1.UpdatePrice(newLaptopPrice);
                            Console.WriteLine("Laptop price updated successfully.");
                            break;
                        // Updating the Smartphone Price to new price provided by user
                        case "2":
                            Console.Write("Enter the new price for the Smartphone: ");
                            double newSmartphonePrice = double.Parse(Console.ReadLine());
                            item2.UpdatePrice(newSmartphonePrice);
                            Console.WriteLine("Smartphone price updated successfully.");
                            break;
                        // Invalid Input Handling
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;

                // Exit option for the user to exit out of the Inventory Management menu
                case "6":
                    exit = 0;
                    break;

                // Invalid Input Handling
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
