

namespace EvolutionRacingModels
{
    public class VehicleState
    {
        public VehicleState(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public int Tick { get; set; }
        public Point Position { get; set; }
        public float Heading { get; set; }
        public float Velocity { get; set; }
        public bool IsOut { get; set; } = false;
        public bool IsFinished { get; set; }
    }
}
