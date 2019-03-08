using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetStore.Core.Models;
using System.Collections.Generic;

namespace PetStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void Order_OrderItems_Total()
        {
            // Arrange
            var expected = 95.89M;
            var order = new Order()
            {
                CustomerId = "12345",
                Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        ProductId = "8ed0e6f7",
                        Quantity = 2,
                        Name = "leash",
                        Price = 9.99M
                    },
                    new OrderItem()
                    {
                        ProductId = "c0258525",
                        Quantity = 3,
                        Name = "collar",
                        Price = 6.99M
                    },
                    new OrderItem()
                    {
                        ProductId = "0a207870",
                        Quantity = 1,
                        Name = "food bowl",
                        Price = 14.99M
                    },
                    new OrderItem()
                    {
                        ProductId = "f020e7e0",
                        Quantity = 4,
                        Name = "squeaky toy",
                        Price = 4.99M
                    },
                    new OrderItem()
                    {
                        ProductId = "b32e16b5",
                        Quantity = 1,
                        Name = "dog bed",
                        Price = 19.99M
                    }
                }
            };

            // Act
            var actual = order.Total;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
