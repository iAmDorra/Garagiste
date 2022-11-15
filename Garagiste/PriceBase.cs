namespace Garagiste
{
    public abstract class PriceBase
    {

        public double CalculateTotal()
        {
            return CalculateVat() +
            CalculatePreTaxAmount();
        }

        protected abstract double CalculatePreTaxAmount();
        protected abstract double CalculateVat();
    }
}