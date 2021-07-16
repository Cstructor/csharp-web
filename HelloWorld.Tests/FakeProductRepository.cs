using HelloWorld.Models;
using System.Collections.Generic;

namespace HelloWorld.Tests
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                var items = new[]
                {
                    new Product{ Name="Baseball"},
                    new Product{ Name="Football"},
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };
                return items;
            }
        }
    }

    public class FakeProduct1Repository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                var items = new[]
                {
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };
                return items;
            }
        }
    }

    public class FakeProduct2Repository : IProductRepository
    {
        public IEnumerable<Product> Products
        {
            get
            {
                var items = new[]
                {
                    new Product{ Name="Baseball", Price=11} ,
                    new Product{ Name="Football", Price=8},
                    new Product{ Name="Tennis", Price=13},
                    new Product{ Name="Golf", Price=3},
                    new Product{ Name="Ping", Price=12},
                };
                return items;
            }
        }
    }
}