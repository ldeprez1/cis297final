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
                case < 1: { waveNum = 0;  return; }
                case 1: { wave1(); return; }
                case 2: { wave2(); return; }
            }

            //code goes here
        }

        private static void addRowGroup(int y, int rows)
        {
            for (int n = 0; n < rows; n++)
            {
                for (int i = 0; i < 6; i++)
                {
                    int spawnPosX = 100 + 2100 * i;
                    if((n % 2 == 0)) { spawnPosX -= 12000; }
                    else { spawnPosX += 12000; }
                    currentEnemies.Add(new GroupEnemy(spawnPosX, 100, 11900, y + n * 1200, 30, parent, (n % 2 == 0)));
                }
            }
        }


        private static void wave1()
        {
            currentEnemies.Add(new GroupEnemy(4800, 100, 11900, 500, 30, parent, true));
            currentEnemies.Add(new GroupEnemy(6400, 100, 11900, 500, 30, parent, true));

            currentEnemies.Add(new GroupEnemy(4800, 100, 11900, 1500, 30, parent, false));
            currentEnemies.Add(new GroupEnemy(6400, 100, 11900, 1500, 30, parent, false));

            currentEnemies.Add(new GroupEnemy(4800, 100, 11900, 2500, 30, parent, true));
            currentEnemies.Add(new GroupEnemy(6400, 100, 11900, 2500, 30, parent, true));

        }

        private static void wave2()
        {
            addRowGroup(1000, 2);
        }



    }
}
