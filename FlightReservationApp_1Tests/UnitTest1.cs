using FlightReservationApp_1.FlightMaintenanceApp.CreateFlight;

namespace FlightReservationApp_1Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {


            // Arrange
            var dataDir = Path.Combine(AppContext.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            var filePath = Path.Combine(dataDir, "Flights.txt");

            // Ensure clean slate
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Input values
            string airlineCode = "AA1";
            int flightNumber = 123;
            string departureStation = "MNL";
            string arrivalStation = "CEB";
            var std = new TimeOnly(14, 30);
            var sta = new TimeOnly(16, 0);

            // Act
            CreateFlight.Store(
                airlineCode,
                flightNumber,
                departureStation,
                arrivalStation,
                std,
                sta
            );

            // Assert
            Assert.True(File.Exists(filePath), "Flights.txt should be created.");

            var content = File.ReadAllText(filePath);
            Assert.False(string.IsNullOrWhiteSpace(content), "Flights.txt should contain content.");


        }
    }
}
