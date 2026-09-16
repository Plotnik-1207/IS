using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS
{
    internal class Cost : IPrintable
    {
        public string GovCost { get; }
        public string MarketCost { get; }

        public Cost(string govCost, string marketCost)
        {
            GovCost = govCost;
            MarketCost = marketCost;
        }
        public override string ToString()
        {
            return $"Кадастровая стоимость: {GovCost} | Рыночная стоимость: {MarketCost}\n";
        }
    }
}
