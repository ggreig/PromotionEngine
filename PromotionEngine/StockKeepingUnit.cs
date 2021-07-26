using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class StockKeepingUnit
    {
        public StockKeepingUnit(char inID)
        {
            Id = inID;
        }

        public char Id { get; private set; }
    }
}
