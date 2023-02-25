List<Customer> customers = new List<Customer> {
    new Customer {
        Id = 1,
        Name = "Alice",
        Email = "alice@example.com",
        Age = 25,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 100.00M, CustomerId = 1},
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 50.00M, CustomerId = 1 },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 75.00M, CustomerId = 1 }
        }
    },
    new Customer {
        Id= 2,
        Name = "Bob",
        Email = "bob@example.com",
        Age = 35,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 150.00M, CustomerId = 2 },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 75.00M, CustomerId = 2 },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 125.00M, CustomerId = 2}
        }
    },
    new Customer {
        Id =3,
        Name = "Charlie",
        Email = "charlie@example.com",
        Age = 30,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M, CustomerId = 3},
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M, CustomerId = 3 },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M, CustomerId = 3}
        }
    }
};


var text = (from c in customers
    select new
    {
        Name = c.Name,
        Email = c.Email,
        Age = c.Age,
        PurchaseHistory = c.PurchaseHistory.OrderByDescending(p=>p.CustomerId).Select(p=>p.Amount).Sum()
    });

var most = customers.Select(p=> p.PurchaseHistory.OrderByDescending(p=>p.CustomerId).Select(p=>p.Amount).Sum());
foreach (var s in text)
{
    Console.WriteLine(s);
}

class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public List<Purchase> PurchaseHistory { get; set; }
}
class Purchase
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}