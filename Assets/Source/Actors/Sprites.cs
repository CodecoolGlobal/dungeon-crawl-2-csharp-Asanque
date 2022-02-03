using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Actors
{
    public static class Sprites
    {
        private const int DefId = -5;

        public static int wallId = DefId;
        public static int floorId = DefId;
        public static int doorId = DefId;
        public static int boatId = 922;
        public static int campfireId = 493;
        public static int logId = 384;
        public static int lakeId = 247;
        public static int treeTrunkId = 307;
        public static int treeLeavesId = 259;
        public static void SetSprites(int mapId)
        {
            

            switch (mapId)
            {
                case 1:
                    wallId = DefId;
                    floorId = DefId;
                    doorId = DefId;
                    break;
                case 2:
                    wallId = 144;
                    floorId = 4;
                    doorId = 146;
                    break;
                case 3:
                    break;


            }
        }
    }
}
