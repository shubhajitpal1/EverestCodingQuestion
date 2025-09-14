using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestCodingQuestion
{
    public interface ILogisticsService
    {
        Dictionary<string, double> EstimateDeliveryTimes(List<Package> packages);
    }
}
