using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FlightReservationApp_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var flightMaintenace = new FlightMaintenance();
            var reservation = new Reservation();
            RunMainMenu(flightMaintenace, reservation);
        }

        private static void RunMainMenu(FlightMaintenance flightMaintenance, Reservation reservation)
        {
            while (true)
            {

                Console.WriteLine("=== Main Menu ===");
                Console.WriteLine("1) Flight Maintenance");
                Console.WriteLine("2) Reservations");
                Console.WriteLine("0) Exit");
                Console.Write("Select: ");
                var choice = (Console.ReadLine() ?? "").Trim();

                if (choice == "1")
                {
                    flightMaintenance.Run();
                }
                else if (choice == "2")
                {
                    reservation.Run();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Exit");
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
