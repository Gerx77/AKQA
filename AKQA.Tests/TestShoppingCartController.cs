using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQA.Models;
using AKQA.Controllers;
using System.Web.Http.Results;

namespace AKQA.Tests
{
    [TestClass]
    public class TestShoppingCartController
    {

        [TestMethod]
        public void SuccessCondition()
        {
            //Arrange
            var shoppingCart = new ShoppingCart() { Name = "Matt", Price = 245.32M };
            var controller = new ShoppingCartController();

            //Act
            var result = controller.Post(shoppingCart);
            var contentResult = result as OkNegotiatedContentResult<ShoppingCart>;

            //Assert
            Assert.AreEqual("Matt", contentResult.Content.Name);
            Assert.AreEqual(245.32M, contentResult.Content.Price);
            Assert.IsNotNull(contentResult.Content.PriceInWords);
            Assert.AreEqual("TWO HUNDRED FOURTY FIVE DOLLARS AND THIRTY TWO CENTS", contentResult.Content.PriceInWords);
        }

        [TestMethod]
        public void IncorrectDollarAmount()
        {
            var shoppingCart = new ShoppingCart() { Price = 100M };
            var controller = new ShoppingCartController();

            var result = controller.Post(shoppingCart);
            var contentResult = result as OkNegotiatedContentResult<ShoppingCart>;

            Assert.AreEqual(100M, contentResult.Content.Price);
            Assert.AreNotEqual("TWO HUNDRED DOLLARS", contentResult.Content.PriceInWords);
        }

        [TestMethod]
        public void IncorrectCentsAmount()
        {
            var shoppingCart = new ShoppingCart() { Price = 245.32M };
            var controller = new ShoppingCartController();

            var result = controller.Post(shoppingCart);
            var contentResult = result as OkNegotiatedContentResult<ShoppingCart>;

            Assert.AreEqual(245.32M, contentResult.Content.Price);
            Assert.AreNotEqual("TWO HUNDRED FOURTY FIVE DOLLARS AND THIRTY THREE CENTS", contentResult.Content.PriceInWords);
        }

        [TestMethod]
        public void MissingCents()
        {
            var shoppingCart = new ShoppingCart() { Price = 245.32M };
            var controller = new ShoppingCartController();

            var result = controller.Post(shoppingCart);
            var contentResult = result as OkNegotiatedContentResult<ShoppingCart>;

            Assert.AreEqual(245.32M, contentResult.Content.Price);
            Assert.AreNotEqual("TWO HUNDRED FOURTY FIVE DOLLARS", contentResult.Content.PriceInWords);
        }

        [TestMethod]
        public void InvalidPrice()
        {

            var shoppingCart = new ShoppingCart() { Price = 123.456M };
            var controller = new ShoppingCartController();

            var result = controller.Post(shoppingCart);
            var contentResult = result as OkNegotiatedContentResult<ShoppingCart>;

            Assert.IsNull(contentResult);

        }
    }
}
