using FlightReservationApp_1.Domain;
using FlightReservationApp_1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightReservationApp_1.FlightMaintenanceApp
{
    public class CreateFlight
    {
        public void Run()
        {

            // remember to state the type .Ask< data type > since it is ask<T>
            // CreateFlight params: 
            //          Label to prompt
            //          Method to use in CreatFlightParser
            //          Error Message

            Console.WriteLine(" [ Create Flight ] ");

            string airlineCode = CreateFlightPrompt.Ask<string>("AirlineCode",
                CreateFlightParser.TryParseAirline,
                "CreateFlightParser.cs : airline (2–3 alphanumeric, max one digit).");

            int flightNumber = CreateFlightPrompt.Ask<int>("FlightNumber",
                CreateFlightParser.TryParseFlightNumber,
                "CreateFlightParser.cs : Flight number must be 1–9999.");

            string departureStation = CreateFlightPrompt.Ask<string>("DepartureStation",
                CreateFlightParser.TryParseStation,
                "CreateFlightParser.cs : Station must be 3 chars, start with a letter, alphanumeric.");

            string arrivalStation = CreateFlightPrompt.Ask<string>("ArrivalStation",
                CreateFlightParser.TryParseStation,
                "CreateFlightParser.cs : Station must be 3 chars, start with a letter, alphanumeric.");

            TimeOnly std = CreateFlightPrompt.Ask<TimeOnly>("STD (HH:mm)",
                CreateFlightParser.TryParseTime,
                "CreateFlightParser.cs : Time must be HH:mm (24-hr).");

            TimeOnly sta = CreateFlightPrompt.Ask<TimeOnly>("STA (HH:mm)",
                CreateFlightParser.TryParseTime,
                "CreateFlightParser.cs : Time must be HH:mm (24-hr).");


            CreateFlight.Store(      
                    airlineCode, 
                    flightNumber,
                    departureStation,
                    arrivalStation,
                    std,
                    sta
                );

        }

        public static void Store(string airlineCode, int flightNumber, string departureStation, string arrivalStation, TimeOnly std, TimeOnly sta)
        {
            Console.WriteLine($"Storing ... {airlineCode}, {flightNumber}, {departureStation}, {arrivalStation}, {std}, {sta}");

            var file = Path.Combine(AppContext.BaseDirectory, "Data", "Flights.txt");
            var flight = new Flight(airlineCode, flightNumber, departureStation, arrivalStation, std, sta);

            var flightWriter = new FlightWriter();

            flightWriter.Add(flight, file);

        }
    }
}
