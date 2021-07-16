using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                var items = new[]
                    {
                    new Product{ ProductId=101, Name = "Baseball", Description="balls", Price=14.20m},
                    new Product{ ProductId=102, Name="Football", Description="nfl", Price=9.24m},
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };
                return items;
            }
        }
    }
}