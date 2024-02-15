using Microsoft.AspNetCore.Http.Connections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCha.Entities
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        [Required]
        [StringLength(10)]
        public string FlightNo { get; set; }
        [Required]
        [StringLength(50)]
        public string Airline { get; set;}
        [Required]
        [StringLength(50)]
        public string DepartureAirport { get; set; }
        [Required]
        [StringLength(50)]
        public string ArrivalAirport { get; set; }
        [Required]
        
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public int AvailableEconomy { get; set; }
        public int AvailableBusiness {  get; set; }
        public int AvailableFirstclass {  get; set; }
        public float EconomyPrice {  get; set; }
        public float BusinessPrice {  get; set; }
        public float FirstclassPrice {  get; set; }

    }
}
