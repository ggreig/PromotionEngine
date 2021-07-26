using System.Collections.Generic;
using NUnit.Framework;

namespace PromotionEngine.Tests
{
    [TestFixture]
    public class CartTests
    {
        private readonly StockKeepingUnit A = new StockKeepingUnit('A', 50);
        private readonly StockKeepingUnit B = new StockKeepingUnit('B', 30);
        private readonly StockKeepingUnit C = new StockKeepingUnit('C', 20);
        private readonly StockKeepingUnit D = new StockKeepingUnit('D', 15);

        private readonly IPromotion Promotion1;
        private readonly IPromotion Promotion2;
        private readonly IPromotion Promotion3;

        public CartTests()
        {
            Promotion1 = new NForFixedPricePromotion(A, 3, 130);
            Promotion2 = new NForFixedPricePromotion(B, 2, 45);

            var thePromotion3Pattern = new Dictionary<StockKeepingUnit, uint>
            {
                {C, 1},
                {D, 1}
            };
            Promotion3 = new CombinationForFixedPricePromotion(thePromotion3Pattern, 30);
        }


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

        [Test]
        public void ScenarioA_WithPromotion1()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(B).Add(C);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion> {Promotion1});

            // Assert
            Assert.That(theResult, Is.EqualTo(100));
        }

        [Test]
        public void ScenarioA_WithPromotion2()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(B).Add(C);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion> {Promotion2});

            // Assert
            Assert.That(theResult, Is.EqualTo(100));
        }

        [Test]
        public void ScenarioA_WithPromotion3()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(B).Add(C);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion3});

            // Assert
            Assert.That(theResult, Is.EqualTo(100));
        }

        [Test]
        public void ScenarioB_WithPromotion1()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(A).Add(A).Add(A).Add(A)
                   .Add(B).Add(B).Add(B).Add(B).Add(B)
                   .Add(C);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion1});

            // Assert
            Assert.That(theResult, Is.EqualTo(400));
        }

        [Test]
        public void ScenarioB_WithPromotion2()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(A).Add(A).Add(A).Add(A)
                   .Add(B).Add(B).Add(B).Add(B).Add(B)
                   .Add(C);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion2});

            // Assert
            Assert.That(theResult, Is.EqualTo(390));
        }

        [Test]
        public void ScenarioB_WithPromotion3()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(A).Add(A).Add(A).Add(A)
                   .Add(B).Add(B).Add(B).Add(B).Add(B)
                   .Add(C);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion3});

            // Assert
            Assert.That(theResult, Is.EqualTo(420));
        }

        [Test]
        public void ScenarioC_WithPromotion1()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(A).Add(A)
                   .Add(B).Add(B).Add(B).Add(B).Add(B)
                   .Add(C)
                   .Add(D);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion1});

            // Assert
            Assert.That(theResult, Is.EqualTo(315));
        }

        [Test]
        public void ScenarioC_WithPromotion2()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(A).Add(A)
                   .Add(B).Add(B).Add(B).Add(B).Add(B)
                   .Add(C)
                   .Add(D);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion2});

            // Assert
            Assert.That(theResult, Is.EqualTo(305));
        }

        [Test]
        public void ScenarioC_WithPromotion3()
        {
            // Arrange
            var theCart = new Cart();
            theCart.Add(A).Add(A).Add(A)
                   .Add(B).Add(B).Add(B).Add(B).Add(B)
                   .Add(C)
                   .Add(D);

            // Act
            uint theResult = theCart.GetPrice(new List<IPromotion>{Promotion3});

            // Assert
            Assert.That(theResult, Is.EqualTo(330));
        }
    }
}