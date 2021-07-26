using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Cart
    {
        private uint myPromotionMatchCount;

        public Dictionary<StockKeepingUnit, uint> Contents { get; private set; }
            = new Dictionary<StockKeepingUnit, uint>();

        private Dictionary<StockKeepingUnit, uint> StandardPriceContents { get; set; }

        public Cart()
        {
        }

        /// <remarks>
        /// Return "this" so that SKUs can be added to the cart fluently.
        /// </remarks>
        public Cart Add(StockKeepingUnit inStockKeepingUnit)
        {
            if (Contents.ContainsKey(inStockKeepingUnit))
            {
                Contents[inStockKeepingUnit]++;
            }
            else
            {
                Contents.Add(inStockKeepingUnit, 1);
            }

            return this;
        }

        public uint GetPrice(IPromotion inPromotion)
        {
            ApplyPromotion(inPromotion);

            uint thePriceTotal = myPromotionMatchCount * inPromotion.GetPrice();

            foreach (var (theStockKeepingUnit, theCount) in StandardPriceContents)
            {
                thePriceTotal += theStockKeepingUnit.UnitPrice * theCount;
            }

            return thePriceTotal ;
        }

        private void ApplyPromotion(IPromotion inPromotion)
        {
            StandardPriceContents = Contents;

            myPromotionMatchCount = ApplyPatternMatches(inPromotion);
        }

        private uint ApplyPatternMatches(IPromotion inPromotion)
        {
            bool isPatternMatch = true;
            uint theMatchCount = 0;

            do
            {
                isPatternMatch = IsPatternMatchFound(inPromotion);

                if (isPatternMatch)
                {
                    theMatchCount++;
                    RemoveAMatch(inPromotion);
                }
            } while (isPatternMatch);

            return theMatchCount;
        }

        private bool IsPatternMatchFound(IPromotion inPromotion)
        {
            bool isPatternMatch = true;

            foreach (var _ in inPromotion.Pattern.Where(x => !SkuCountAvailable(x)))
            {
                isPatternMatch = false;
            }

            return isPatternMatch;
        }

        private void RemoveAMatch(IPromotion inPromotion)
        {
            foreach (var (anSku, thePatternSkuCount) in inPromotion.Pattern)
            {
                StandardPriceContents[anSku] -= thePatternSkuCount;
            }
        }

        private bool SkuCountAvailable(KeyValuePair<StockKeepingUnit, uint> inSkuCount)
        {
            var (anSku, thePatternSkuCount) = inSkuCount;
            return StandardPriceContents.ContainsKey(anSku) && StandardPriceContents[anSku] >= thePatternSkuCount;
        }
    }
}
