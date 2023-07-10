using System.Data;
using System.Text;

using EvolutionRacingServer.Data;

using Microsoft.AspNetCore.Razor.Hosting;

namespace EvolutionRacingServer.Services
{
    public class RacerManager
    {
        public string RaceId { get; set; } = "";
        public string TrackId { get; }

        TickState CurrentTick = new(1000);
        int MaxTick = 99999;
        Dictionary<string, Racer> Racers = null;

        public RacerManager(string trackId, string raceId)
        {
            TrackId = trackId;
            RaceId = raceId;
            CurrentTick = new(1000);
        }

        public TickState GetNextTickState()
        {
            CurrentTick.Step();
            return CurrentTick;
        }

        public void LoadTrack()
        {
            var trackDefinition = File.ReadAllLines("SimpleTrack.json");
            StringBuilder sb = new();
            foreach (var str in trackDefinition)
            {
                sb.Append(str);
            }
            TrackContainer track = System.Text.Json.JsonSerializer.Deserialize<TrackContainer>(sb.ToString());
        }

        internal void RegisterVehicles(string[] racerIds)
        {
            if (Racers == null)
            {
                Racers = new(); 
            }

            foreach (string id in racerIds)
            {
                Racers[id] =new Racer(id);
            }
        }

        internal Racer GetVehicle(string vehicleId)
        {

            return Racers[vehicleId];
        }

        internal VehicleState Simulate(VehicleCommand newCommand)
        {
            var racer = GetVehicle(newCommand.VehicleId);

            racer.Velocity += newCommand.GasPedalPosition;
            racer.Heading += newCommand.SteeringAngle;

            //Drag
            racer.Velocity *= 0.95f;
            racer.Heading *= 0.95f;

            racer.Position.X = racer.Velocity * MathF.Cos(racer.Heading);
            racer.Position.Y = racer.Velocity * MathF.Sin(racer.Heading);

            racer.UpdateState(newCommand.CurrentTick + 1);

            return racer.CurrentState;
        }
    }
}
