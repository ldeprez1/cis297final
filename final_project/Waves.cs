using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public static class Waves
    {
        private static int waveNum = 0;


        public static Control? parent;
        public static List<Enemy> currentEnemies { get; } = new List<Enemy>();

        public static void resetWaves()
        {
            waveNum = 0;
        }

        public static void nextWave()
        {
            waveNum++;
            switch(waveNum)

            {
                case < 1:
                    { waveNum = 0;  return; }
                case 1:
                    { wave1(); return; }
            }

            //code goes here
        }

        private static void addRowGroup(int y, int rows)
        {
            for (int n = 0; n < rows; n++)
            {
                for (int i = 0; i < 6; i++)
                    currentEnemies.Add(new GroupEnemy((int)(100 + 2100 * i), 100, 11900, y + n * 1200, 30, parent, (n%2 == 0)));
            }
        }


        private static void wave1()
        {
            addRowGroup(1000, 2);
        }



    }
}
