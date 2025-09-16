using EverestCodingQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestCodingQuestionTests
{
    [TestClass]
    public class LogisticsServiceTests
    {
        private ILogisticsService _logisticsService;

        [TestInitialize]
        public void Setup()
        {
            _logisticsService = new LogisticsService(2,70,200);
        }

        [TestMethod]
        public void EstimateDeliveryTimes_ShouldAssignTimesToAllPackages()
        {
            var packages = new List<Package>
            {
                new Package { Id = "PKG2", Weight = 75, Distance = 125 },
                new Package { Id = "PKG1", Weight = 50, Distance = 30 },
                new Package { Id = "PKG3", Weight = 175, Distance = 100 },
                new Package { Id = "PKG4", Weight = 110, Distance = 60 },
                new Package { Id = "PKG5", Weight = 155, Distance = 95 }
            };

            var result = _logisticsService.EstimateDeliveryTimes(packages);

            Assert.AreEqual(5, result.Count);
            Assert.IsTrue(result["PKG1"] == 3.98);
            Assert.IsTrue(result["PKG2"] == 1.78);
            Assert.IsTrue(result["PKG3"] == 1.42);
            Assert.IsTrue(result["PKG4"] == 0.85);
            Assert.IsTrue(Math.Round(result["PKG5"],2) == 4.19);
        }
    }

}
