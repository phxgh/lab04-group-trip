/*
    * Name: Phoenix Rojas
    * Course: CSCI-1250, Section 002
    * Assignment: Lab 04, The Group Trip
    * Date: October 7, 2026
    * Description: Rebuilds the trip calculator with methods and arrays so it
    * reports on a whole group instead of one person.
*/

const float TaxRate = .18f;

const int PizzaSlices = 8;

Console.Write("Round trip miles: ");
int roundTripMiles = Convert.ToInt32(Console.ReadLine());
Console.Write("Miles per gallon: ");
int milesPerGallon = Convert.ToInt32(Console.ReadLine());
Console.Write("Price per gallon: ");
double pricePerGallon = Convert.ToDouble(Console.ReadLine());
Console.Write("How many pizzas: ");
int pizzaCount = Convert.ToInt32(Console.ReadLine());
Console.Write("Price per pizzas: ");
double pizzaPrice = Convert.ToDouble(Console.ReadLine());

/* Part 1 */
Console.WriteLine("=== Part 1: The Trip ===");
double fuelCost = FuelCost(roundTripMiles, milesPerGallon, pricePerGallon);
Console.WriteLine("Fuel cost:" + fuelCost.ToString("C"));
double pizzaCost = pizzaCount * pizzaPrice;
Console.WriteLine("Pizza cost: " + pizzaCost.ToString("C"));
double tripTotal = fuelCost + pizzaCost;
Console.WriteLine("Trip total: " + tripTotal.ToString("C"));
Console.Write("\n");

/* Part 2 */
Console.WriteLine("=== Part 2: The Group ===");

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

int peopleGoing = names.Length;
double slicesEach = (pizzaCount * PizzaSlices) / peopleGoing;
double costPerPerson = tripTotal / peopleGoing;

Console.WriteLine("People going: " + peopleGoing);
Console.WriteLine("Slices each: " + slicesEach.ToString("F1"));
Console.WriteLine("Slices each: " + costPerPerson.ToString("C"));
Console.Write("\n");

/* Part 3 */
Console.WriteLine("=== Part 3: Who Works How Long ===");

double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], TaxRate);
    double takeHomePerHour = takeHomePay / hoursWorked[i];
    double hoursToCover = HoursToCover(costPerPerson, takeHomePerHour);
    Console.WriteLine($"{names[i]}: takes home {takeHomePay.ToString("C")} for {hoursToCover.ToString("F2")} hours, {takeHomePerHour.ToString("C")} per hour, must work {hoursToCover.ToString("F2")} hours");

    totalHours += hoursWorked[i];
    totalTakeHomePay += takeHomePay;
    longest = Math.Max(longest, hoursToCover);
}
Console.Write("\n");

Console.WriteLine("Total hours worked: " + totalHours);
Console.WriteLine("Total take home pay: " + totalTakeHomePay.ToString("C"));
Console.WriteLine("Longest anyone must work: " + longest.ToString("F2"));

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
