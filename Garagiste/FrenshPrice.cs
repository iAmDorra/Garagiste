namespace Garagiste
{
    public class FrenshPrice : PriceBase
    {
        private double tax;
        private double preTaxPrice;

        public FrenshPrice(double tax, double preTaxPrice)
        {
            this.tax = tax;
            this.preTaxPrice = preTaxPrice;
        }

        protected override double CalculatePreTaxAmount()
        {
            return preTaxPrice;
        }

        protected override double CalculateVat()
        {
            return preTaxPrice* tax / 100;
        }
    }
}