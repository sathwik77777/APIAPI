using CodingCha.Entities;

namespace CodingCha.Services
{
    public interface IFlightService
    {
        void AddFlight(Flight flight); //Done
        List<Flight> GetAllFlights(); //Done
        Flight GetFlightById(int flightid); //Done
        void EditFlight(Flight flight); //Done
        void DeleteFlight(int flightid); //Done
        List<Flight> FlightByAirline(string airline); //Done
        Flight GetFlightByNo(string flightno); //Done




    }
}
