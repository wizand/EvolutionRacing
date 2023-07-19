using EvolutionRacingModels;

using EvolutionRacingServer.Services;

using Microsoft.AspNetCore.Mvc;


namespace EvolutionRacingServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameManagerController : ControllerBase
    {
        public readonly RaceManagerService _raceManagerService;

        public GameManagerController(RaceManagerService raceManagerService) 
        {
            _raceManagerService = raceManagerService;
        }

        [HttpGet("NewGame")]
        public IActionResult CreateNewRace(string trackId)
        {
            string raceId = _raceManagerService.AddNewRace(trackId);
            return Ok(raceId);
        }

        [HttpPost("RegisterVehicles")]
        public IActionResult RegisterVehicles(string raceId, string[] racerIds)
        {
            var racerManager = _raceManagerService.GetRace(raceId);
            racerManager.RegisterVehicles(racerIds);
            _raceManagerService.UpdateRacerManager(racerManager);
            return Ok("Registered " + racerIds.Length + " vehicles for race " + raceId + ".");
        }

        [HttpPost("UpdateVehicle")]
        public VehicleState UpdateVehicle(VehicleCommand newCommand) 
        {
            var raceManager = _raceManagerService.GetRace(newCommand.RaceId);
            var vehicle = raceManager.GetVehicle(newCommand.VehicleId);
            if ( vehicle.IsOut || vehicle.IsFinished )
            {
                return vehicle.CurrentState;
            }
            var vehicleState = raceManager.Simulate(newCommand);
            
            return vehicleState;
        }
    }
}