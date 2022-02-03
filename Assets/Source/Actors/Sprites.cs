
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
        public static int river = 199;
        public static int bridgeUp = 580;
        public static int bridgeStraight = 581;
        public static int bridgeDown = 582;
        public static int road = 15;
        public static int houseRoofUp = 729;
        public static int houseRoofStraight = 730;
        public static int houseRoofDown = 731;
        public static int houseWall = 781;
        public static int houseDoor = 434;
        public static int flag = 400;
        public static int smallHouse = 912;
        public static int pig = 364;

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
                    lakeId = 247;
                    break;
                case 3:
                    wallId = 533;
                    floorId = 4;
                    doorId = 502;
                    lakeId = 144;
                    break;


            }
        }
    }
}
