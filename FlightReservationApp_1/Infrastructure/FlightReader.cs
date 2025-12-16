using FlightReservationApp_1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1.Infrastructure
{
    public class FlightReader
    {

        // C:\Users\je2lim\source\repos\FlightReservationApp_1\FlightReservationApp_1\bin\Debug\net10.0 >>>>>>> Flights.txt path

        public IEnumerable<Flight> Read(string filePath)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (line.StartsWith("AirlineCode|")) continue; // header

                var p = line.Split('|');
                yield return new Flight(
                    p[0],                   // airlineCode
                    int.Parse(p[1]),        // flightNumber
                    p[2],                   // departureStation
                    p[3],                   // arrivalStation
                    TimeOnly.Parse(p[4]),   // std
                    TimeOnly.Parse(p[5])    // sta
                );
            }
        }
    }
}
