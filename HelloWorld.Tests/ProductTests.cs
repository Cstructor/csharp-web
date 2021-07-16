using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using System.Collections.Generic;
using HelloWorld.Controllers;
using System.Linq;
using Moq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {

        [TestMethod]
        public void TestProducts_WithFake_Expect5()
        {
            // Arrange
            var controller = new HomeController(new FakeProduct2Repository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;

            Assert.IsNotNull(products, "Products is null");
            Assert.AreEqual(5, products.Length, "Length is invalid");
            Assert.AreEqual(3, products.Where(t => t.Price > 10).Count(), "Too few > $10");
            Assert.AreEqual(2, products.Where(t => t.Price < 10).Count(), "Too many < $10");
        }

        [TestMethod]
        public void TestProducts_WithMoq_Expect5()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .SetupGet(x => x.Products)
                .Returns(() =>
                {
                    return new Product[]
                    {
                        new Product{ Name="Baseball", Price=11} ,
                        new Product{ Name="Football", Price=8},
                        new Product{ Name="Tennis", Price=13},
                        new Product{ Name="Golf", Price=3},
                        new Product{ Name="Ping", Price=12},
                    };
                });

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var viewResult = (System.Web.Mvc.ViewResult)result;

            var products = (Product[])(viewResult).Model;

            Assert.AreEqual(5, products.Length, "Length is invalid");
            Assert.AreEqual(3, products.Where(t => t.Price > 10).Count(), "Too few > $10");
            Assert.AreEqual(2, products.Where(t => t.Price < 10).Count(), "Too many < $10");
        }

        [TestMethod]
        public void TestProducts_WithFake_Expect4()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;

            Assert.IsNotNull(products, "Products is null");
            Assert.AreEqual(4, products.Length, "Length is invalid");
        }

        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();

            mockProductRepository
                .SetupGet(x => x.Products)
                .Returns(() =>
                {
                    return new Product[]
                    {
                        new Product{Name="Baseball"},
                        new Product{Name="Football"}
                    };
                });

            //mockProductRepository
            //    .Setup(t => t.GetPrice())
            //    .Returns(() => false);

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var viewResult = (System.Web.Mvc.ViewResult)result;

            var products = (Product[])(viewResult).Model;

            Assert.AreEqual(2, products.Length, "Length is invalid");
        }
    }
}