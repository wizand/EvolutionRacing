using System.Net;
using System.Net.Mime;

namespace EvolutonRacingClient.Data
{
    public class RacingServerCommService
    {
        public RacingServerCommService(string serverUrl) 
        {
            _url = serverUrl;
        }

        private RacingServerCommunicator? _instance = null;
        public RacingServerCommunicator RacingServerCommunicator 
        { 
            get 
            { 
                if (_instance == null || _instance.Url != _url)
                {
                    if ( _instance != null ) 
                    {
                        _instance.Dispose();
                    }
                    _instance = new RacingServerCommunicator(_url);
                }

                return _instance; 
            } 
        }

        private string _url { get; set; }

        public void UpdateUrl(string url) 
        {
            _url = url;            
        }
    }

    public class RacingServerCommunicator : IDisposable
    {
        public RacingServerCommunicator(string url)
        {
            Url = url;
        }
        public string Url { get; }

        private HttpClient _httpClient;
        public HttpClient RacingHttpClient
        {
            get
            {
                if (this._httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri(this.Url);
                }

                return _httpClient;
            }
        }

        public async Task<string> RegisterNewGameAsync(string trackId = "SimpleTrack")
        {

            string requestUri = "/GameManager/NewGame?trackId=" + trackId;
            var request = await RacingHttpClient.GetAsync(requestUri);
            if (request.StatusCode == HttpStatusCode.OK)
            {
                var content = await request.Content.ReadAsStringAsync();
                
                return content;
            }

            return "NA";
        }

        public void Dispose() 
        {
            if ( _httpClient != null ) 
            {
                _httpClient.Dispose();
            }
        }
    }
}
