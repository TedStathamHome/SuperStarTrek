using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    public class Galaxy
    {
        public Galaxy()
        {
            InitializeQuadrants();
        }

        private const int GalaxyWidthHeight = 8;

        public Quadrant[,] Quadrants { get; set; } = new Quadrant[GalaxyWidthHeight, GalaxyWidthHeight];

        public List<Star> Stars { get; set; } = new List<Star>();

        public List<FederationStarbase> FederationStarbases { get; set; } = new List<FederationStarbase>();

        public List<KlingonBattleCruiser> KlingonBattleCruisers { get; set; } = new List<KlingonBattleCruiser>();

        public FederationStarship UssEnterprise { get; set; }

        internal void InitializeQuadrants()
        {
            for (int i = 0; i < GalaxyWidthHeight; i++)
            {
                for (int j = 0; j < GalaxyWidthHeight; j++)
                {
                    Quadrants[i, j] = new Quadrant();
                }
            }
        }
    }
}
