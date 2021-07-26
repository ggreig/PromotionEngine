using NUnit.Framework;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class StockKeepingUnitTests
    {
        [Test]
        public void StockKeepingUnit_HasExpectedValues()
        {
            // Act
            char theExpectedId = 'a';
            uint theExpectedUnitPrice = 20;
            var theSku = new StockKeepingUnit(theExpectedId, theExpectedUnitPrice);

            // Act
            char theActualId = theSku.Id;
            uint theActualUnitPrice = theSku.UnitPrice;

            // Assert
            // Not best practice to have two asserts, but still trivial so let's keep it simple.
            Assert.That(theActualId, Is.EqualTo(theExpectedId));
            Assert.That(theActualUnitPrice, Is.EqualTo(theExpectedUnitPrice));
        }
    }
}