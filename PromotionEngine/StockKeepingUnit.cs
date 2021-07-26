using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class StockKeepingUnit
    {
        public StockKeepingUnit(char inId, uint inUnitPrice)
        {
            Id = inId;
            UnitPrice = inUnitPrice;
        }

        public char Id { get; private set; }

        /// <remarks>
        /// Assumed uint for UnitPrice based on examples; more likely to be decimal.
        /// </remarks>
        public uint UnitPrice { get; private set; }
    }
}
