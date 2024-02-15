using CodingCha.Entities;
using CodingCha.Database;

namespace CodingCha.Services
{
    public class FlightService : IFlightService
    {
        private readonly MyContext Context;
        public FlightService(MyContext context)
        {
            Context = context;
        }
        public void AddFlight(Flight flight)
        {
            try
            {
                Context.Flights.Add(flight);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteFlight(int flightid)
        {
            Flight flight = Context.Flights.SingleOrDefault(f=>f.FlightId==flightid);
            if (flight != null)
            {
                Context.Flights.Remove(flight);
                Context.SaveChanges();
            }
        }

        public void EditFlight(Flight flight)
        {
            Context.Flights.Update(flight);
            Context.SaveChanges();
        }

        public List<Flight> FlightByAirline(string airline)
        {
            try
            {

                return Context.Flights.Where(a => a.Airline == airline).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Flight> GetAllFlights()
        {
            var result = Context.Flights.ToList();
            return result;
        }

        public Flight GetFlightById(int flightid)
        {
            return Context.Flights.Find(flightid);
        }

        public Flight GetFlightByNo(string flightno)
        {
            /*return Context.Flights.Find(flightno);*/
            try
            {

                return (Flight)Context.Flights.Where(a => a.FlightNo == flightno);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
