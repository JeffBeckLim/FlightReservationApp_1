using FlightReservationApp_1.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1.Infrastructure
{
    public class FlightWriter
    {
        //private readonly string _file;
        public void Add(Flight flight, string file)
        {
            //Directory.CreateDirectory(Path.GetDirectoryName(_file)!);
            var line = string.Join("|", new[]
            {
                flight.AirlineCode,
                flight.FlightNumber.ToString(),
                flight.DepartureStation,
                flight.ArrivalStation,
                flight.Std.ToString(),
                flight.Sta.ToString()
            }); 
            File.AppendAllText(file, line + Environment.NewLine);
        }

    }
}
