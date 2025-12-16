using FlightReservationApp_1.FlightMaintenanceApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1
{
    public class FlightMaintenance
    {
        private readonly CreateFlight _createFlight = new CreateFlight();
        private readonly SearchFlight _searchFlight= new SearchFlight();
        private readonly ViewAllFlights _viewAllFlights= new ViewAllFlights();
        public void Run()
        {

            while (true)
            {
                Console.WriteLine("=== Flight Maintenance ===");
                Console.WriteLine("1) Create Flight");
                Console.WriteLine("2) Search Flight");
                Console.WriteLine("3) View All Flight");
                Console.WriteLine("0) Back");
                Console.Write("Select: ");
                var choice = (Console.ReadLine() ?? "").Trim();

                if (choice == "1")
                {
                    _createFlight.Run();
                }
                else if (choice == "2")
                {
                    _searchFlight.Run();
                }
                else if (choice == "3")
                {
                    _viewAllFlights.Run();
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
