
namespace EvolutionRacingServer.Services
{
    public class RaceManagerService
    {

        public RaceManagerService()
        {
            _racerManagers = new();
        }

        Dictionary<string, ServerRacerManager> _racerManagers;

        public string AddNewRace(string trackId)
        {
            string raceId = Guid.NewGuid().ToString(); 
            _racerManagers.Add(raceId, new ServerRacerManager(trackId, raceId));
            return raceId;
        }

        public ServerRacerManager GetRace(string id) 
        {
            return _racerManagers[id];
        }

        internal void UpdateRacerManager(ServerRacerManager racerManager)
        {
            _racerManagers[racerManager.RaceId] = racerManager;
        }
    }
}
