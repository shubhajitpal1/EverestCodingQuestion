using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestCodingQuestion
{
    public interface IOfferService
    {
        double CalculateDiscount(double deliveryCost, double weight, double distance, string offerCode);
    }
}
