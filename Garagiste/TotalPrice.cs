namespace Garagiste
{
    public class TotalPrice
    {
        private IPrice price;

        public TotalPrice(IPrice price)
        {
            this.price = price;
        }

        public double CalculateTotal()
        {
            return price.CalculateVat() +
                price.CalculatePreTaxAmount();
        }
    }
}