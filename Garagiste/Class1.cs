namespace Garagiste
{
    public class FrenshPrice
    {
        private double tax;
        private double preTaxPrice;

        public FrenshPrice(double tax, double preTaxPrice)
        {
            this.tax = tax;
            this.preTaxPrice = preTaxPrice;
        }

        public double CalculateTotal()
        {
            if(this.GetType() == typeof(FrenshPrice))
            {
                // Do something
            }
            return preTaxPrice + preTaxPrice * tax / 100;
        }
    }

    public class LuxembourgishPrice
    {
        private int preTaxServiceAmount;
        private int serviceTax;
        private int preTaxMaterialAmount;
        private int materialTax;

        public LuxembourgishPrice(int preTaxServiceAmount, int serviceTax, int preTaxMaterialAmount, int materialTax)
        {
            this.preTaxServiceAmount = preTaxServiceAmount;
            this.serviceTax = serviceTax;
            this.preTaxMaterialAmount = preTaxMaterialAmount;
            this.materialTax = materialTax;
        }

        public double CalculateTotal()
        {
            return CalculateVat() +
            CalculatePreTaxAmount();
        }
        private double CalculateVat()
        {
            return preTaxServiceAmount * serviceTax / 100 +
                         preTaxMaterialAmount * materialTax / 100;
        }
        private double CalculatePreTaxAmount()
        {
            return preTaxServiceAmount +
                         preTaxMaterialAmount;
        }
    }
}