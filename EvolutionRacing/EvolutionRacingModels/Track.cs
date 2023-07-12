using System;

using System.Drawing;
using EvolutionRacingModels;
using System.Text;


namespace EvolutionRacingModels
{
    internal class Track
    {



        List<TrackBlock> blocks;

        public string GetTrackAsSvg()
        {
            StringBuilder sb = new StringBuilder("<svg width=\"500\" height=\"500\">");




            sb.AppendLine("</svg>");

            return sb.ToString();
        }
    }

    internal class TrackBlock
    {
        
        public TrackBlock(int width, int height, Point origin) 
        { 
            P1 = origin;
            P2 = new Point(P1.X, P1.Y + height);
            P3 = new Point(x: P2.X + width, y: P2.Y);
            P4 = new Point(x: P3.X, y: P1.Y);
        }

        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<polygon points=\"{P1} {P2} {P3} {P4}\" style=\"fill:lime;stroke:purple;stroke-width:1\"");
            return sb.ToString();
            
        }

    }
}
