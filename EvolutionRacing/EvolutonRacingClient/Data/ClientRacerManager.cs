using EvolutionRacingModels;

namespace EvolutonRacingClient.Data
{
    public class ClientRacerManager
    {

        public ClientRacerManager()
        {
            vehicleGeneration = GenerateInitialGeneration();
        }


        public ClientRacerManager(List<Racer> previousGeneration) 
        {
            vehicleGeneration = GenerateNewGenerationBasedOnTheOldOne(previousGeneration);
        }


        List<Racer> vehicleGeneration = new();
        
        
        public List<Racer> GenerateInitialGeneration()
        {
            List<Racer> racers = new List<Racer>();
            for (int i = 0; i < 10000; i++)
            {
                string guid = Guid.NewGuid().ToString();
                racers.Add(new Racer(guid));
            }

            return racers;
        }
        public List<Racer> GenerateNewGenerationBasedOnTheOldOne(List<Racer> previousGeneration)
        {
            List<Racer> nextGeneration = new();
            for (int i = -1; i < previousGeneration.Count / 4; i++)
            {
                if (i < 0)
                {
                    nextGeneration.Add(new Racer(previousGeneration[0], previousGeneration[0]));
                }
                else
                {
                    nextGeneration.Add(new Racer(previousGeneration[i], previousGeneration[i+1]));
                }
            }
            //TODO: Use the previous generation genes
            List<Racer> vehicles = new List<Racer>();
            for (int i = 0; i < 10000; i++)
            {
                vehicles.Add(new Racer());
            }

            return vehicles;
        }



    }
}