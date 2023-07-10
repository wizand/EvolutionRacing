namespace EvolutionRacingServer.Services
{
    public class TickState
    {
        public int MaxTick { get; }
        private int _currentTick = -1;
        public int CurrentTick { get => _currentTick; set => _currentTick = value; }
        
        
        public TickState(int maxTick)
        {
            MaxTick = maxTick;
            CurrentTick = 0;
        }

        internal void Step()
        {
            CurrentTick++;
        }

        public bool IsRunning
        {
            get { if ( CurrentTick < MaxTick) return true; return false; }
        }
        public bool IsFinished 
        {
            get { return !IsRunning; }
        }
    }
}