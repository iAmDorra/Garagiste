namespace Garagiste
{
    public class FrenshPrice : IPrice
    {
        private double tax;
        private double preTaxPrice;

        public FrenshPrice(double tax, double preTaxPrice)
        {
            this.tax = tax;
            this.preTaxPrice = preTaxPrice;
        }

        public double CalculatePreTaxAmount()
        {
            return preTaxPrice;
        }

        public double CalculateVat()
        {
            return preTaxPrice* tax / 100;
        }
    }
}