using System;
using System.Collections.Generic;
using System.Text;

namespace FlightReservationApp_1.Domain
{
    public class Flight
    {
        public string AirlineCode { get; set;  }
        public int FlightNumber { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public TimeOnly Std { get; set; } 
        public TimeOnly Sta { get; set; } 

        // Constructor

        public Flight(string airlineCode, int flightNumber, string departureStation, string arrivalStation, TimeOnly std, TimeOnly sta)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            DepartureStation = departureStation;
            ArrivalStation = arrivalStation;
            Std = std;
            Sta = sta;
        }


    }
}
