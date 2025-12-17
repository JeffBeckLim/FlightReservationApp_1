using FlightReservationApp_1.Domain;
using FlightReservationApp_1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightReservationApp_1.FlightMaintenanceApp.SearchFlight
{
    public class SearchFlight
    {
        private readonly SearchFlightPrompt _searchFlightPrompt;
        private readonly FlightReader _reader;
        private readonly ViewAllFlights _viewer;

        public SearchFlight(SearchFlightPrompt searchFlightPrompt)
        {
            _searchFlightPrompt = searchFlightPrompt ?? throw new ArgumentNullException(nameof(searchFlightPrompt));
            _reader = new FlightReader();
            _viewer = new ViewAllFlights();
        }

        public void Run()
        {
            var file = Path.Combine(AppContext.BaseDirectory, "Data", "Flights.txt");

            while (true)
            {
                Console.WriteLine(" [ Search Flight Screen ] ");
                Console.WriteLine("1) Search by Flight Number");
                Console.WriteLine("2) Search by Airline Code");
                Console.WriteLine("3) Search by Origin and Destination");
                Console.WriteLine("0) Back");
                Console.Write("Select: ");
                var choice = (Console.ReadLine() ?? "").Trim();

                if (choice == "1")
                {
                    var raw = _searchFlightPrompt.Ask("Flight Number");
                    if (!int.TryParse(raw.Trim(), out var num))
                    {
                        Console.WriteLine("Invalid flight number.");
                        continue;
                    }

                    var match = _reader.Read(file).FirstOrDefault(f => f.FlightNumber == num);
                    if (match == null)
                    {
                        Console.WriteLine("No flight found with that number.");
                    }
                    else
                    {
                        _viewer.Show(new[] { match });
                    }
                }
                else if (choice == "2")
                {
                    var code = _searchFlightPrompt.Ask("Airline Code").Trim();
                    if (string.IsNullOrEmpty(code))
                    {
                        Console.WriteLine("Invalid airline code.");
                        continue;
                    }

                    var matches = _reader.Read(file).Where(f => string.Equals(f.AirlineCode, code, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (!matches.Any())
                    {
                        Console.WriteLine("No flights found for that airline code.");
                    }
                    else
                    {
                        _viewer.Show(matches);
                    }
                }
                else if (choice == "3")
                {
                    var (origin, destination) = _searchFlightPrompt.AskOriginDestination();
                    if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(destination))
                    {
                        Console.WriteLine("Invalid origin or destination.");
                        continue;
                    }

                    var matches = _reader.Read(file)
                        .Where(f => string.Equals(f.DepartureStation, origin, StringComparison.OrdinalIgnoreCase)
                                 && string.Equals(f.ArrivalStation, destination, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (!matches.Any())
                    {
                        Console.WriteLine("No flights found for that route.");
                    }
                    else
                    {
                        _viewer.Show(matches);
                    }
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown option.");
                }
            }
        }
    }
}
