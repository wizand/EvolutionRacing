
namespace EvolutionRacingServer.Services
{
    public class RaceManagerService
    {

        public RaceManagerService()
        {
            _racerManagers = new();
        }

        Dictionary<string, RacerManager> _racerManagers;

        public string AddNewRace(string trackId)
        {
            string raceId = Guid.NewGuid().ToString(); 
            _racerManagers.Add(raceId, new RacerManager(trackId, raceId));
            return raceId;
        }

        public RacerManager GetRace(string id) 
        {
            return _racerManagers[id];
        }

        internal void UpdateRacerManager(RacerManager racerManager)
        {
            _racerManagers[racerManager.RaceId] = racerManager;
        }
    }
}
