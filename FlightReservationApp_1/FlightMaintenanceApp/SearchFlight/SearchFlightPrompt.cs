using FlightReservationApp_1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1.FlightMaintenanceApp.SearchFlight
{
    public class SearchFlightPrompt
    {

        private readonly FlightReader _reader = new FlightReader();

        public string Ask(string label)
        {
            Console.Write($"{label}: ");
            var raw = Console.ReadLine() ?? string.Empty;
            return raw;
        }

        public (string origin, string destination) AskOriginDestination()
        {
            Console.Write("Origin: ");
            var origin = (Console.ReadLine() ?? string.Empty).Trim();
            Console.Write("Destination: ");
            var destination = (Console.ReadLine() ?? string.Empty).Trim();
            return (origin, destination);
        }

        public void DisplayAvailableFlights()
        {
            var file = Path.Combine(AppContext.BaseDirectory, "Data", "Flights.txt");

            foreach (var f in _reader.Read(file))
            {
                Console.WriteLine($"{f.AirlineCode}{f.FlightNumber} {f.DepartureStation}->{f.ArrivalStation} STD {f.Std} STA {f.Sta}");
            }
        }
    }
}
