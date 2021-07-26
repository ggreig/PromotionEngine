using System.Collections.Generic;

namespace PromotionEngine
{
    public interface IPromotion
    {
        Dictionary<StockKeepingUnit, uint> Pattern { get; }
        uint GetPrice();
    }
}