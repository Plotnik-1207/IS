namespace IS
{
    public class Cost
    {
        public int GovCost { get; }
        public int MarketCost { get; }

        public Cost(int govCost, int marketCost)
        {
            GovCost = govCost;
            MarketCost = marketCost;
        }
        public override string ToString()
        {
            return $"Кадастровая стоимость: {GovCost} | Рыночная стоимость: {MarketCost}";
        }
    }
}
