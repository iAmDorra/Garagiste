using NFluent;
using NSubstitute;

namespace Garagiste.Tests
{
    [TestClass]
    public class PriceTest
    {
        [TestMethod]
        public void Return_total_for_any_price()
        {
            IPrice price = Substitute.For<IPrice>();
            var totalPrice = new TotalPrice(price);
            var total = totalPrice.CalculateTotal();
            Check.That(total).IsEqualTo(0);
        }

        [TestMethod]
        public void Return_sum_of_pretax_vat_for_any_price()
        {
            IPrice price = Substitute.For<IPrice>();
            price.CalculatePreTaxAmount().Returns(1);
            price.CalculateVat().Returns(1);
            var totalPrice = new TotalPrice(price);
            var total = totalPrice.CalculateTotal();
            Check.That(total).IsEqualTo(2);
        }

        [TestMethod]
        public void Calculate_total_price_should_return_zero_when_pretax_value_is_zero_for_france()
        {
            var frenshTax = 19.6;
            var preTaxPrice = 0;
            var frenshPrice = new TotalPrice(new FrenshPrice(frenshTax, preTaxPrice));
            var total = frenshPrice.CalculateTotal();
            Check.That(total).IsEqualTo(0);
        }

        [TestMethod]
        public void Calculate_total_price_should_return_zero_when_pretax_value_is_zero_for_luxembourg()
        {
            int preTaxServiceAmount = 0;
            int serviceTax = 12;
            int preTaxMaterialAmount = 0;
            int materialTax = 5;
            var luxembourgishPrice = new TotalPrice(new LuxembourgishPrice(preTaxServiceAmount, serviceTax,
                preTaxMaterialAmount, materialTax));
            var total = luxembourgishPrice.CalculateTotal();
            Check.That(total).IsEqualTo(0);
        }

        [TestMethod]
        public void Calculate_total_price_including_tax_for_frensh_mechanic()
        {
            var frenshTax = 19.6;
            var preTaxPrice = 100;
            var frenshPrice = new TotalPrice(new FrenshPrice(frenshTax, preTaxPrice));
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
            var luxembourgishPrice = new TotalPrice(
                new LuxembourgishPrice(preTaxServiceAmount, serviceTax, preTaxMaterialAmount, materialTax));
            var total = luxembourgishPrice.CalculateTotal();
            Check.That(total).IsEqualTo(161);
        }
    }
}