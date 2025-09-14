/* Kiki, a first-time entrepreneur from the city of 
Koriko has decided to open a small distance 
courier service to deliver packages, with her 
friend Tombo and cat Joji. */
using EverestCodingQuestion;

Console.WriteLine("Enter Problem Number:");
int problemNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Enter base_delivery_cost & no_of_packges Details:");
var firstLine = Console.ReadLine().Split();
double baseDeliveryCost = double.Parse(firstLine[0]);
int noOfPackages = int.Parse(firstLine[1]);

List<Package> packages = new List<Package>();

// Read packages details
for (int i = 0; i < noOfPackages; i++)
{
    Console.WriteLine("Enter pkg_id pkg_weight distance_in_km offer_code:");
    var parts = Console.ReadLine().Split();
    packages.Add(new Package
    {
        Id = parts[0],
        Weight = double.Parse(parts[1]),
        Distance = double.Parse(parts[2]),
        OfferCode = parts[3]
    });
}

// Calculate discounts and total cost for all packages
OfferService offerService = new OfferService();
foreach (var pkg in packages)
{
    double deliveryCost = baseDeliveryCost + (pkg.Weight * 10) + (pkg.Distance * 5);
    pkg.Discount = offerService.CalculateDiscount(deliveryCost, pkg.Weight, pkg.Distance, pkg.OfferCode);
    pkg.TotalCost = deliveryCost - pkg.Discount;
}
if (problemNumber == 1)
{
    // Output for Problem 1
    Console.WriteLine("Output:");
    foreach (var pkg in packages)
    {
        Console.WriteLine($"{pkg.Id} {(int)pkg.Discount} {(int)pkg.TotalCost}");
    }
}
else if (problemNumber == 2)
{
    // Read vehicle info
    Console.WriteLine("Enter no_of_vehicles max_speed max_carriable_weight");
    var vehicleLine = Console.ReadLine().Split();
    int noOfVehicles = int.Parse(vehicleLine[0]);
    double maxSpeed = double.Parse(vehicleLine[1]);
    double maxCarriableWeight = double.Parse(vehicleLine[2]);
    // Estimate delivery time
    LogisticsService logisticsService = new LogisticsService(noOfVehicles, maxSpeed, maxCarriableWeight);
    //var deliveryTimes = logisticsService.EstimateDeliveryTimes(packages, noOfVehicles, maxSpeed, maxCarriableWeight);
    var deliveryTimes = logisticsService.EstimateDeliveryTimes(packages);

    // Output
    Console.WriteLine("Output:");
    foreach (var pkg in packages)
    {
        Console.WriteLine($"{pkg.Id} {(int)pkg.Discount} {(int)pkg.TotalCost} {deliveryTimes[pkg.Id]:0.00}");
    }
}