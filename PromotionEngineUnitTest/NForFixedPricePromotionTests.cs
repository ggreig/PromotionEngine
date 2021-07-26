using System.Collections.Generic;
using NUnit.Framework;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class NForFixedPricePromotionTests
    {
        [Test]
        public void Promotion_ReturnsExpectedPrice()
        {
            // Arrange
            const uint theUnitPrice = 20;
            var anSku = new StockKeepingUnit('A', theUnitPrice);
            const uint theNumberInPattern = 2;

            const uint theExpectedPrice = 30;


            var thePromotion = new NForFixedPricePromotion(anSku, theNumberInPattern, theExpectedPrice);

            // Act
            var theResult = thePromotion.GetPrice();

            // Assert
            Assert.That(theResult, Is.EqualTo(theExpectedPrice));
        }
    }
}