using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1.FlightMaintenanceApp.CreateFlight
{
    public static class CreateFlightPrompt
    {
        // why delegate ??
        //      Need to deligate since i am passing a method
        public delegate bool TryParse<T>(string input, out T value);

        // ask while false then prints error
        // note : <T> means it can work with any type
        public static T Ask<T>(string label, TryParse<T> parser, string errorMessage)
        {
            while (true)
            {
                Console.Write($"{label}: ");
                var raw = Console.ReadLine() ?? string.Empty;

                if (parser(raw, out var value)) 
                {
                    return value; // returns true and outs the value
                }           
                    
                //dont get why need to define prev ?? 
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = prev;
            }
        }
    }
}
