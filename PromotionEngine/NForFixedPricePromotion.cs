using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class NForFixedPricePromotion : PromotionBase
    {
        private readonly uint myFixedPrice;

        public NForFixedPricePromotion(StockKeepingUnit inSku, uint inNumber, uint inFixedPrice)
            : base(new Dictionary<StockKeepingUnit, uint>
            {
                {inSku, inNumber}
            })
        {
            myFixedPrice = inFixedPrice;
        }


        public override uint GetPrice()
        {
            return myFixedPrice;
        }
    }
}
