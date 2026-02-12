using System;
using System.Collections.Generic;

public class Bike
{
    public string Model { get; set; }
    public int PricePerDay { get; set; }
    public string Brand { get; set; }
}

public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        Bike bike = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };

        int key = Program.bikeDetails.Count + 1;
        Program.bikeDetails.Add(key, bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> grouped =
            new SortedDictionary<string, List<Bike>>();

        foreach (var item in Program.bikeDetails)
        {
            Bike bike = item.Value;

            if (!grouped.ContainsKey(bike.Brand))
            {
                grouped[bike.Brand] = new List<Bike>();
            }

            grouped[bike.Brand].Add(bike);
        }

        return grouped;
    }
}

public class Program
{
    public static SortedDictionary<int, Bike> bikeDetails =
        new SortedDictionary<int, Bike>();

    public static void Main(string[] args)
    {
        BikeUtility utility = new BikeUtility();
        int choice;

        do
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the model:");
                    string model = Console.ReadLine();

                    Console.WriteLine("Enter the brand:");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Enter the price per day:");
                    int price = int.Parse(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);
                    Console.WriteLine("Bike details added successfully");
                    break;

                case 2:
                    var grouped = utility.GroupBikesByBrand();

                    foreach (var brandGroup in grouped)
                    {
                        foreach (var bike in brandGroup.Value)
                        {
                            Console.WriteLine(brandGroup.Key + " " + bike.Model);
                        }
                    }
                    break;

                case 3:
                    break;
            }

        } while (choice != 3);
    }
}
