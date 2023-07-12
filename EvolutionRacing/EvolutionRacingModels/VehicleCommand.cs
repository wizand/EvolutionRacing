namespace EvolutionRacingModels
{
    public class VehicleCommand
    {
        public string RaceId { get; set; }
        public string VehicleId { get; set; }
        public int CurrentTick { get; set; }
        public float GasPedalPosition { get; set; }
        public float SteeringAngle { get; set; }
    }
}