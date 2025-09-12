/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Test Cases

        // Test 1
        // Scenario: Add one customer and then serve the customer
        Console.WriteLine("Test 1");
        var service = new CustomerService(4);
        service.AddNewCustomer("Alice", "A001", "Password reset");
        service.ServeCustomer();

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers and serve them in the correct order
        Console.WriteLine("Test 2");
        service = new CustomerService(4);
        service.AddNewCustomer("Bob", "B002", "Login issue");
        service.AddNewCustomer("Charlie", "C003", "Payment error");
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try to serve when queue is empty
        Console.WriteLine("Test 3");
        service = new CustomerService(4);
        service.ServeCustomer();

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Enforce max queue size
        Console.WriteLine("Test 4");
        service = new CustomerService(2);
        service.AddNewCustomer("David", "D004", "App crash");
        service.AddNewCustomer("Eve", "E005", "Update failed");
        service.AddNewCustomer("Frank", "F006", "Slow performance"); // Should show error
        Console.WriteLine($"Service Queue: {service}");

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Provide invalid max size (0), should default to 10
        Console.WriteLine("Test 5");
        service = new CustomerService(0);
        Console.WriteLine($"Size should be 10: {service}");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        _maxSize = maxSize <= 0 ? 10 : maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    /// <summary>
    /// Add a customer interactively (using Console.ReadLine).
    /// </summary>
    public void AddNewCustomer()
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Queue is full");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        AddNewCustomer(name, accountId, problem);
    }

    /// <summary>
    /// Add a customer directly (useful for testing).
    /// </summary>
    public void AddNewCustomer(string name, string accountId, string problem)
    {
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Queue is full");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer()
    {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No customers in the queue");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object.
    /// </summary>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}
