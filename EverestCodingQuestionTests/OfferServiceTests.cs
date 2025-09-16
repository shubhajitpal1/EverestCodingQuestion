using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EverestCodingQuestion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverestCodingQuestionTests
{
    [TestClass]
    public class OfferServiceTests
    {
        private IOfferService _offerService;

        [TestInitialize]
        public void Setup()
        {
            _offerService = new OfferService();
        }

        [TestMethod]
        public void ValidOffer_ShouldReturnCorrectDiscount()
        {
            double cost = 1000;
            double weight = 100;
            double distance = 100;
            string code = "OFR001";

            double discount = _offerService.CalculateDiscount(cost, weight, distance, code);

            Assert.AreEqual(100, discount);
        }

        [TestMethod]
        public void InvalidOfferCode_ShouldReturnZeroDiscount()
        {
            double discount = _offerService.CalculateDiscount(1000, 100, 100, "INVALID");
            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void OutOfRangeWeight_ShouldReturnZeroDiscount()
        {
            double discount = _offerService.CalculateDiscount(1000, 300, 100, "OFR001");
            Assert.AreEqual(0, discount);
        }
    }

}
