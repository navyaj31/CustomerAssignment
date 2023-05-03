namespace Assignment7
{
    class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }

    class Details
    {
        List<Customer> list;
        public int CustomerId = 1;
        public Details()
        {
            list = new List<Customer>()
            {
                new Customer { Id = CustomerId++, FirstName = "Rahul", LastName = "krishna", Email = "rahulkrisha@gmail.com", Age = 25, PhoneNumber = "9398387917", City = "Hyderabad"},
                new Customer { Id = CustomerId++, FirstName = "praveen", LastName = "veera", Email = "praveenveera@gmail.com", Age = 30, PhoneNumber = "9441604864", City = "Warangal"}
            };
        }
        public void AddCustomer()
        {
            Console.WriteLine("Enter Customer First Name");
            string fistname = Console.ReadLine();
            Console.WriteLine("Enter customer Last Name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Customer Email Id");
            string emailid = Console.ReadLine();
            Console.WriteLine("Enter Customer Age");
            int age = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Enter Customer Phone Number");
            string phn = Console.ReadLine();
            Console.WriteLine("Enter Customer City");
            string city = Console.ReadLine();
            int id = CustomerId++;
            list.Add(new Customer() { Id = id, FirstName = fistname, LastName = lastname, Email = emailid, Age = age, PhoneNumber = phn, City = city });
            Console.WriteLine("Customer Added and Customer Id is Generated");
        }
        public Customer GetCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }
        public List<Customer> GetAllCustomers()
        {
            return list;
        }

        public bool DeleteCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    list.Remove(c);
                    return true;
                }
            }
            return false;
        }
        public void UpdateCustomer(int id)
        {
            foreach (Customer c in list)
            {
                if (c.Id == id)
                {
                    Console.WriteLine("Enter updated customer First Name");
                    c.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter updated customer Last Name");
                    c.LastName = Console.ReadLine();
                    Console.WriteLine("Enter upated customer email id");
                    c.Email = Console.ReadLine();
                    Console.WriteLine("Enter updated customer age");
                    c.Age = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter updated customer Phone Number");
                    c.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter updated customer City");
                    c.City = Console.ReadLine();
                    Console.WriteLine("Customer Details Updated Successfully");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Details details = new Details();
            string res = "y";
            do
            {
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Get customer By Id");
                Console.WriteLine("3. Get All customers");
                Console.WriteLine("4. Delete customer By Id");
                Console.WriteLine("5. Update customer By Id");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            details.AddCustomer();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Customer? c = details.GetCustomer(id);
                            if (c == null)
                            {
                                Console.WriteLine("Customer not exists");
                            }
                            else
                            {
                                Console.WriteLine($"Customer Details of id-{c.Id} :");
                                Console.WriteLine($"First Name: {c.FirstName}\nLast Name: {c.LastName}\nEmail: {c.Email}\nAge: {c.Age}\nPhone Number: {c.PhoneNumber}\nCity: {c.City}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("ID\tFirst_Name\tLast_Name\tEmail ID\t\tAge\tPhone_Number\tCity");
                            foreach (var c in details.GetAllCustomers())
                            {
                                Console.WriteLine($"{c.Id}\t{c.FirstName}\t\t{c.LastName}\t\t{c.Email}\t{c.Age}\t{c.PhoneNumber}\t{c.City}");



                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (details.DeleteCustomer(id))
                            {
                                Console.WriteLine("Customer Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Customer not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Customer Id");
                            int id = Convert.ToInt16(Console.ReadLine());
                            details.UpdateCustomer(id);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue? [y/n] ");
                res = Console.ReadLine();
            } while (res.ToLower() == "y");
        }
    }
}
    