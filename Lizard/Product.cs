namespace Lizard
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }

        public double GetPrice(Customer customer)
        {
            if (customer.IsPremium)
            {
                return Price * .8;
            }
            return Price;
        }

        public double GetPrice(ICustomer customer)
        {
            if (customer.IsPremium)
            {
                return Price * .8;
            }
            return Price;
        }
    }
}
