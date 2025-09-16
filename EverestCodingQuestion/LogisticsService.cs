using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestCodingQuestion
{
    public class LogisticsService : ILogisticsService
    {
        private readonly double maxWeight;
        private readonly double maxSpeed;
        private readonly int numVehicles;

        public LogisticsService(int vehicleCount, double vehicleSpeed, double maxVehicleWeight)
        {
            numVehicles = vehicleCount;
            maxSpeed = vehicleSpeed;
            maxWeight = maxVehicleWeight;
        }
        public Dictionary<string, double> EstimateDeliveryTimes(List<Package> packages)
        {
            var vehicleAvailableTimes = new double[numVehicles];
            var undelivered = new List<Package>(packages);
            var deliveryTimes = new Dictionary<string, double>();

            while (undelivered.Any())
            {
                var shipment = FindBestShipment(undelivered, maxWeight);
                if (!shipment.Any()) break;

                int vehicleIdx = Array.IndexOf(vehicleAvailableTimes, vehicleAvailableTimes.Min());
                double currentTime = vehicleAvailableTimes[vehicleIdx];

                double maxDistance = shipment.Max(pkg => pkg.Distance);
                double tripTime = 2 * Math.Truncate((maxDistance / maxSpeed) * 100) / 100;

                vehicleAvailableTimes[vehicleIdx] = currentTime + tripTime;

                foreach (var pkg in shipment)
                {
                    deliveryTimes[pkg.Id] = currentTime + Math.Truncate((pkg.Distance / maxSpeed) * 100) / 100;
                    undelivered.Remove(pkg);
                }
            }

            return deliveryTimes;
        }
        List<Package> FindBestShipment(List<Package> packages, double maxWeight)
        {
            int n = packages.Count;
            int W = (int)Math.Floor(maxWeight);
            double[,] dp = new double[n + 1, W + 1];

            for (int i = 1; i <= n; i++)
            {
                int wt = (int)Math.Floor(packages[i - 1].Weight);
                for (int w = 0; w <= W; w++)
                {
                    if (wt <= w)
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - wt] + packages[i - 1].Weight);
                    else
                        dp[i, w] = dp[i - 1, w];
                }
            }

            // Backtrack to find selected packages
            List<Package> selected = new List<Package>();
            int remWeight = W;
            for (int i = n; i > 0 && remWeight >= 0; i--)
            {
                if (dp[i, remWeight] != dp[i - 1, remWeight])
                {
                    Package pkg = packages[i - 1];
                    selected.Add(pkg);
                    remWeight -= (int)Math.Floor(pkg.Weight);
                }
            }

            return selected;
        }
    }
}
