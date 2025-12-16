using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1.FlightMaintenanceApp
{
    public class SearchFlight
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine(" [ Search Flight Screen ] ");
                Console.WriteLine("1) Search by Flight Number");
                Console.WriteLine("2) Search by Airline Code");
                Console.WriteLine("3) Search by Origin and Destination");
                Console.WriteLine("0) Search by Back");
                Console.Write("Select: ");
                var choice = (Console.ReadLine() ?? "").Trim();

                if(choice == "1")
                {
                    Console.WriteLine("Search by Flight Number");
                 //   throw new NotImplementedException();
                }
                if (choice == "2")
                {
                    Console.WriteLine("Search by Airline Code");
                  //  throw new NotImplementedException();
                }
                if (choice == "3")
                {
                    Console.WriteLine("Search by Origin and Destination");
                   // throw new NotImplementedException();
                }
                if (choice == "0")
                {
                    break;
                }
            }
        }
    }
}
