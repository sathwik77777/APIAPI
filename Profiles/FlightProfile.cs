using AutoMapper;
using CodingCha.Entities;
using CodingCha.DTO;


namespace CodingCha.Profiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile() 
        {
            CreateMap<Flight, FlightDTO>();
            CreateMap<FlightDTO, Flight>();
        }

    }
}
