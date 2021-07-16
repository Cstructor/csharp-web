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
                    new Product{ Name="Tennis ball"} ,
                    new Product{ Name="Golf ball"},
                };
                return items;
            }
        }
    }
}