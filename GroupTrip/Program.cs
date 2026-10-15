/*
    * Name: Phoenix Rojas
    * Course: CSCI-1250, Section 002
    * Assignment: Lab 04, The Group Trip
    * Date: October 7, 2026
    * Description: Rebuilds the trip calculator with methods and arrays so it
    * reports on a whole group instead of one person.
*/

const float TaxRate = .18f;

const int PizzaCount = 3;
const int PizzaSlices = 8;
const double PizzaPrice = 12.99;

/* Part 1 */
Console.WriteLine("=== Part 1: The Trip ===");

double fuelCost = FuelCost(260, 28, 2.89);
Console.WriteLine("Fuel cost:" + fuelCost.ToString("C"));
double pizzaCost = PizzaCount * PizzaPrice;
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
double tripTotal = fuelCost + pizzaCost;
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));

/* Methods */
static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double gallons = miles / milesPerGallon;
    return gallons * pricePerGallon;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * taxRate;
    
    double result = grossPay - taxWithheld;
    return result;
}

static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    double result = amountOwed / takeHomePerHour;
    return result;
}
