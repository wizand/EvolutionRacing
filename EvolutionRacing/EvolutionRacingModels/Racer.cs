using System.Security.Cryptography.X509Certificates;


namespace  EvolutionRacingModels
{
    public class Racer
    {
        public Racer(string id)
        {
            if (id == null)
            {
                Id = Guid.NewGuid().ToString();
            } else
            {
                Id = id;
            }
            Position = new Point(0, 0);
            Heading = 0;
            Velocity = 0;
        }

        public Racer(Racer father, Racer mother)
        {
            string newId = Guid.NewGuid().ToString();
            this.Id = newId;
            //New properties based on evolution
        }

        public string Id { get; set;  }
        public Point Position { get; set; }
        public float Heading { get; set; }
        public float Velocity { get; set; }
        public bool IsOut { get; set; } = false;
        public bool IsFinished { get; set; } = false;

        private VehicleState? _currentState = null;
        

        public VehicleState CurrentState 
        { 
            get 
            { 
                if (_currentState == null)
                {
                    _currentState = new(Id);
                }
                return _currentState;
            } 
            set => _currentState = value; 
        }

        public void UpdateState(int tick)
        {
            CurrentState.Tick = tick;
            CurrentState.Position = Position;
            CurrentState.Heading = Heading;
            CurrentState.Velocity = Velocity;
            CurrentState.IsOut = IsOut;
            CurrentState.IsFinished = IsFinished;
        }
       
    }
}
