using Bogus;
using P06Shop.Shared.Shop;
using System;

namespace P07Shop.DataSeeder
{
    public class OrderSeeder
    {
        public static List<Order> GenerateOrderData()
        {
            int orderId = 16;
            Random random = new Random();
            var orderFaker = new Faker<Order>()
                .UseSeed(123456)
                .RuleFor(x=>x.Date, x=>x.Date.Between(DateTime.Now.AddYears(-10), DateTime.Now).Date)
                .RuleFor(x => x.TotalPrice, x => Math.Round((random.NextDouble() * (100 - 10) + 10),2))
                .RuleFor(x=>x.Id, x=> orderId++);

            return orderFaker.Generate(35).ToList();

        }
    }
}