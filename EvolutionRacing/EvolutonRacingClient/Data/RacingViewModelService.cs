namespace EvolutonRacingClient.Data
{
  
    
   public class RacingViewModelService
    {

        public RacingViewModelService() { }

        private RacingViewModel _racingViewModel = null;
        public RacingViewModel RacingViewModel 
        {
            get
            { 
                if (_racingViewModel == null) 
                {
                    _racingViewModel = new RacingViewModel();
                }

                return _racingViewModel;
            }
        }

    }
}