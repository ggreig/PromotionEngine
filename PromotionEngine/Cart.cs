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
        public Dictionary<StockKeepingUnit, uint> Contents { get; private set; }
            = new Dictionary<StockKeepingUnit, uint>();

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
    }
}
