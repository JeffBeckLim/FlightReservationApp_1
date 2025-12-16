using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1
{
    public class Reservation
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("=== Reservation ===");
                Console.WriteLine("1) Book Flight");
                Console.WriteLine("2) Add Passenger");
                Console.WriteLine("3) Search Reservation");
                Console.WriteLine("0) Back");
                Console.Write("Select: ");
                var choice = (Console.ReadLine() ?? "").Trim();

                if (choice == "1")
                {
                    Console.WriteLine("Book Flight");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Add Flight");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Search All Flights");
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Back");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }
    }
}
