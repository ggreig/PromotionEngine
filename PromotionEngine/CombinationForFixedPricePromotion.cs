using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class CombinationForFixedPricePromotion : PromotionBase
    {
        private readonly uint myFixedPrice;

        public CombinationForFixedPricePromotion(Dictionary<StockKeepingUnit, uint> inPattern, uint inFixedPrice)
        : base (inPattern)
        {
            myFixedPrice = inFixedPrice;
        }
        
        public override uint GetPrice()
        {
            return myFixedPrice;
        }
    }
}
