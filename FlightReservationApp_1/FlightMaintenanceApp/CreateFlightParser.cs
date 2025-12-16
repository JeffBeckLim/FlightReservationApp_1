using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FlightReservationApp_1.FlightMaintenanceApp
{
    public static class CreateFlightParser
    {
        // note: default - defaults to default value of a type int = 0
        // note: default! - the exclamation is a null-forgiving operator , temporary allows the variable to be null from the start of the method
        public static bool TryParseAirline(string input, out string value)
        {
            var s = (input ?? "").Trim().ToUpperInvariant();
            value = default!;
            if (s.Length < 2 || s.Length > 3) 
            {
                return false;
            }
            if (!Regex.IsMatch(s, @"^[A-Z0-9]+$"))
            {
                return false;
            } 
            int digits = 0; foreach (var ch in s) if (char.IsDigit(ch)) digits++;
            if (digits > 1) 
            {
                return false;
            }

            value = s; return true;
        }

        public static bool TryParseFlightNumber(string input, out int value)
        {
            if (int.TryParse((input ?? "").Trim(), out var n) && n >= 1 && n <= 9999)
            { 
                value = n; 
                return true; 
            }
            value = default; 
            return false;
        }

        public static bool TryParseStation(string input, out string value)
        {
            var s = (input ?? "").Trim().ToUpperInvariant();
            value = default!;
            if (s.Length != 3)
            {
                return false;
            }
            if (!char.IsLetter(s[0])) {
                return false;
            }
            if (!Regex.IsMatch(s, @"^[A-Z0-9]{3}$"))
            {
                return false;
            } 

            value = s; 
            return true;
        }

        public static bool TryParseTime(string input, out TimeOnly value)
        {
            if (TimeOnly.TryParse((input ?? "").Trim(), out var t))
            { 
                value = t; 
                return true; 
            }
            value = default; 
            return false;
        }
    }
}
