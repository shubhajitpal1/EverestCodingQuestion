using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestCodingQuestion
{
    public class OfferService : IOfferService
    {
        private readonly Dictionary<string, (double discount, double distMin, double distMax, double weightMin, double weightMax)> offers =
            new Dictionary<string, (double, double, double, double, double)>() {
            {"OFR001", (0.10, 70, 200, 0, 200)},
            {"OFR002", (0.07, 50, 150, 10, 250)},
            {"OFR003", (0.05, 50, 250, 10, 150)}
            };
        public double CalculateDiscount(double deliveryCost, double weight, double distance, string offerCode)
        {
            if (!offers.ContainsKey(offerCode))
                return 0;

            var offer = offers[offerCode];
            if ((distance >= offer.distMin && distance <= offer.distMax) && (weight >= offer.weightMin && weight <= offer.weightMax))
                return deliveryCost * offer.discount;
            else
                return 0;
        }
    }
}
