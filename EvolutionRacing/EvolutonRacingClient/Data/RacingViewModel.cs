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

        private VehicleManager? _vehicleManager = null;
        public VehicleManager Vehicles 
        { 
            get 
            { 
                if (_vehicleManager == null)
                {
                    _vehicleManager = new();
                }
                return _vehicleManager;
            }
            set => _vehicleManager = value; 
        }
        
    }

    public class VehicleManager
    {

        public VehicleManager()
        {
            vehicleGeneration = GenerateInitialGeneration();
        }


        public VehicleManager(List<Vehicle> previousGeneration) 
        {
            vehicleGeneration = GenerateNewGenerationBasedOnTheOldOne(previousGeneration);
        }


        List<Vehicle> vehicleGeneration = new();
        
        
        private List<Vehicle> GenerateInitialGeneration()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 10000; i++)
            {
                vehicles.Add(new Vehicle());
            }

            return vehicles;
        }
        private List<Vehicle> GenerateNewGenerationBasedOnTheOldOne(List<Vehicle> previousGeneration)
        {

            //TODO: Use the previous generation genes
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 10000; i++)
            {
                vehicles.Add(new Vehicle());
            }

            return vehicles;
        }



    }
    public class Vehicle
    {
        
    }
}