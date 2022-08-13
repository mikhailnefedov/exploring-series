using exploring_graphql.Models;

namespace exploring_graphql.Query
{
    public class Query
    {
        public Customer GetCustomer() =>
            new Customer
            {
                Id = 1,
                Name = "John Smith",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        TotalAmount = 42.0
                    },
                    new Order
                    {
                        Id = 2,
                        Date = DateTime.Now,
                        TotalAmount = 1.0
                    },
                }
            };
    }
}
