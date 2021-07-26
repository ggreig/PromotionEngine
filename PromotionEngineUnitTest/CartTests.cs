using NUnit.Framework;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class CartTests
    {
        [Test]
        public void AddSkuToCartSucceeds()
        {
            // Arrange
            var theCart = new Cart();

            const uint theUnitPrice = 20;
            var anSku = new StockKeepingUnit('A', theUnitPrice);

            // Act
            theCart.Add(anSku);

            // Assert
            Assert.That(theCart.Contents[anSku], Is.EqualTo(1));
        }

        [Test]
        public void AddTwoIdenticalSkusToCartSucceeds()
        {
            // Arrange
            var theCart = new Cart();

            const uint theUnitPrice = 20;
            var anSku = new StockKeepingUnit('A', theUnitPrice);

            // Act
            theCart.Add(anSku).Add(anSku);

            // Assert
            Assert.That(theCart.Contents[anSku], Is.EqualTo(2));
        }
    }
}