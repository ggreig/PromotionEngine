using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public abstract class PromotionBase
    {
        protected PromotionBase(Dictionary<StockKeepingUnit, uint> inPattern)
        {
            Pattern = inPattern;
        }

        protected Dictionary<StockKeepingUnit, uint> Pattern { get; }

        public abstract uint GetPrice();
    }
}
