using FlightReservationApp_1.Infrastructure;
using FlightReservationApp_1.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace FlightReservationApp_1.FlightMaintenanceApp
{
    public class ViewAllFlights
    {

        private readonly FlightReader _reader = new FlightReader();

        public void Run()
        {
            Console.WriteLine(" [ View All Flight Screen ] ");

            var file = Path.Combine(AppContext.BaseDirectory, "Data", "Flights.txt");

            foreach (var f in _reader.Read(file))
            {
                Console.WriteLine($"{f.AirlineCode}{f.FlightNumber} {f.DepartureStation}->{f.ArrivalStation} STD {f.Std} STA {f.Sta}");
            }
        }

        public void Show(IEnumerable<Flight> flights)
        {
            Console.WriteLine(" [ Flights ] ");
            foreach (var f in flights)
            {
                Console.WriteLine($"{f.AirlineCode}{f.FlightNumber} {f.DepartureStation}->{f.ArrivalStation} STD {f.Std} STA {f.Sta}");
            }
        }
    }
}
