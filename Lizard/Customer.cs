namespace Lizard
{
    public interface ICustomer
    {
        int Discount { get; set; }
        int OrderTotal { get; set; }
        string GreetMessage { get; set; }

        bool IsPremium { get; set; }
        string CombineNames(string firstName, string lastName);
        CustomerType GetCustomerDetails();
    }

    public class Customer : ICustomer
    {
        public int Discount { get; set; }
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; } = null!;

        public bool IsPremium { get; set; }

        public Customer()
        {
            Discount = 15;
            IsPremium = false;
        }

        public string CombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First Name");
            }

            GreetMessage = "Hey, " + firstName + " " + lastName;
            Discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PremiumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PremiumCustomer : CustomerType { }
}
