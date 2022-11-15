namespace Garagiste
{
    public class LuxembourgishPrice : PriceBase
    {
        private int preTaxServiceAmount;
        private int serviceTax;
        private int preTaxMaterialAmount;
        private int materialTax;

        public LuxembourgishPrice(int preTaxServiceAmount,
            int serviceTax,
            int preTaxMaterialAmount,
            int materialTax)
        {
            this.preTaxServiceAmount = preTaxServiceAmount;
            this.serviceTax = serviceTax;
            this.preTaxMaterialAmount = preTaxMaterialAmount;
            this.materialTax = materialTax;
        }

        protected override double CalculateVat()
        {
            return preTaxServiceAmount * serviceTax / 100 +
                   preTaxMaterialAmount * materialTax / 100;
        }
        protected override double CalculatePreTaxAmount()
        {
            return preTaxServiceAmount +
                         preTaxMaterialAmount;
        }
    }
}