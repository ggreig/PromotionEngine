using NUnit.Framework;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class StockKeepingUnitTests
    {
        [Test]
        public void StockKeepingUnit_HasExpectedId()
        {
            // Arrange / Act
            char theExpectedValue = 'a';
            var theSku = new StockKeepingUnit(theExpectedValue);

            // Act
            char theResult = theSku.Id;

            // Assert
            Assert.That(theResult, Is.EqualTo(theExpectedValue));
        }
    }
}