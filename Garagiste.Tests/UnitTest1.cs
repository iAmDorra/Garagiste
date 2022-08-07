using NFluent;

namespace Garagiste.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Calculate_total_price_including_tax_for_frensh_mechanic()
        {
            var frenshTax = 19.6;
            var preTaxPrice = 100;
            var frenshPrice = new FrenshPrice(frenshTax, preTaxPrice);
            var total = frenshPrice.CalculateTotal();
            Check.That(total).IsEqualTo(119.6);
        }

        [TestMethod]
        public void Calculate_total_price_including_tax_for_luxembourgish_mechanic()
        {
            var preTaxServiceAmount = 50;
            var serviceTax = 12;
            var preTaxMaterialAmount = 100;
            var materialTax = 5;
            var luxembourgishPrice = new LuxembourgishPrice(preTaxServiceAmount, serviceTax, preTaxMaterialAmount, materialTax);
            var total = luxembourgishPrice.CalculateTotal();
            Check.That(total).IsEqualTo(161);
        }
    }
}