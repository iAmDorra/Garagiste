namespace Garagiste
{
    public interface IPrice
    {
        double CalculatePreTaxAmount();
        double CalculateVat();
    }

}