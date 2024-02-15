namespace CodingCha.DTO
{
    public class FlightDTO
    {
        public int FlightID { get; set; }
        public string FlightNo { get; set; }
        public string Airline {  get; set; }
        public string DepartureAirport {  get; set; }
        public string ArrivalAirport {  get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AvailableEconomy { get; set; }
        public int AvailabeBusiness { get; set; }
        public int AvailableFirstclass { get; set; }
        public float EconomyPrice { get; set; }
        public float BusinessPrice { get; set; }
        public float FirstclassPrice { get; set; }
    }
}
