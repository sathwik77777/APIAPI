using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CodingCha.Entities;
using CodingCha.DTO;
using CodingCha.Models;
using CodingCha.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using log4net;
using System.Runtime.ConstrainedExecution;

namespace CodingCha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService flightService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private ILogger<FlightController> logger;

        public FlightController(IFlightService flightService, IMapper mapper, IConfiguration configuration, ILogger<FlightController> logger)
        {
            this.flightService = flightService;
            _mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }
        [HttpGet, Route("GetAllFlights")]
        [Authorize]
        public IActionResult GetAllFlights()
        {
            try
            {
                List<Flight> flights = flightService.GetAllFlights();
                List<FlightDTO> flightsDTO = _mapper.Map<List<FlightDTO>>(flights);
                return Ok(flights);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("AddFlight")]
        [AllowAnonymous] //access the endpoint any any user with out login
        public IActionResult AddFlight(Flight flight)
        {
            try
            {
                Flight _flight = _mapper.Map<Flight>(flight);
                flightService.AddFlight(_flight);
                return StatusCode(200, _flight);


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetFlightById")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetFlightById(int flightId)
        {
            try
            {
                Flight flight = flightService.GetFlightById(flightId);
                FlightDTO flightDTO = _mapper.Map<FlightDTO>(flight);
                if (flight != null)
                {
                    return Ok(flightDTO);
                }
                else
                    return StatusCode(404, new JsonResult("Invalid Id"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("EditFlight")]
        //[Authorize(Roles = "Customer")]
        public IActionResult EditFlight(Flight flight)
        {
            try
            {
                Flight _flight = _mapper.Map<Flight>(flight);
                flightService.EditFlight(_flight);
                return StatusCode(200, flight);


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteFlight/{flightId}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteFlight(int flightId)
        {
            try
            {
                flightService.DeleteFlight(flightId);
                return StatusCode(200, new JsonResult($"Flight with Id {flightId} is Deleted"));

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

       /* [HttpGet, Route("GetFlightByNo")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetFlightByNo(string flightNo)
        {
            try
            {
                Flight flight = flightService.GetFlightByNo(flightNo);
                FlightDTO flightDTO = _mapper.Map<FlightDTO>(flight);
                if (flight != null)
                    return StatusCode(200, flight);
                else
                    return StatusCode(404, new JsonResult("Invalid Id"));

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }*/

        [HttpGet,Route("GetFlightByAirline")]
        [Authorize]
        public IActionResult GetFlightByAirline(string airline)
        {
            try
            {
                List<Flight> flight = flightService.FlightByAirline(airline);
                List<FlightDTO> flightDTO = _mapper.Map<List<FlightDTO>>(flight);
                if (flight != null)
                    return StatusCode(200, flight);
                else
                    return StatusCode(404, new JsonResult("Invalid Airline Name"));

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet, Route("SortingFlights")]
        [Authorize]
        public IActionResult GetFlightbySort(string SortOrder = "asc")
        {
            try
            {
                List<Flight> flights = flightService.GetAllFlights();
                List<FlightDTO> flightsDTO = _mapper.Map<List<FlightDTO>>(flights);
                if (SortOrder.ToLower() == "asc")
                {
                    flightsDTO = flightsDTO.OrderBy(p => p.EconomyPrice).ToList();
                }
                else if (SortOrder.ToLower() == "desc")
                {
                    flightsDTO = flightsDTO.OrderByDescending(p => p.EconomyPrice).ToList();
                }
                else
                {
                    return BadRequest("Invalid sortOrder parameter. Use 'asc' or 'desc'.");
                }
                return Ok(flightsDTO);

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);

            }
        }





        }
}
