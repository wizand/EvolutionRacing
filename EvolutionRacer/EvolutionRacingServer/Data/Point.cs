namespace EvolutionRacingServer.Services
{
    public class Point
    {
        private float _x;
        private float _y;
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }



    }
}
