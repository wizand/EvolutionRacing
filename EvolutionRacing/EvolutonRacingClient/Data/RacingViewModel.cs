namespace EvolutonRacingClient.Data
{
    public class RacingViewModel
    {
        public RacingViewModel() 
        {
        
        }

        public string GameId { get; set; }
        public int Tick { get; set; } = -1;
        public string GameStatus 
        {
            get
            {
                if (Tick < 0)
                {
                    return "Not strted.";
                }
                else if (Tick == 0)
                {
                    return "Game id=["+GameId+"] started. Waiting to register vehicles.";
                }
                else
                {
                    return "Game simulation tick #" + Tick;
                }
             
            }
        }

        private ClientRacerManager? _racerManager = null;
        public ClientRacerManager Racers 
        { 
            get 
            { 
                if (_racerManager == null)
                {
                    _racerManager = new();
                }
                return _racerManager;
            }
            set => _racerManager = value; 
        }

    }

}