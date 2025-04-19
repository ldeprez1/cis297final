using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public static class Waves
    {
        public static int waveNum = 0;


        public static Control? parent;
        public static List<Enemy> currentEnemies { get; } = new List<Enemy>();

        public static void resetWaves()
        {
            waveNum = 0;
        }

        public static void nextWave()
        {
            waveNum++;
            switch (waveNum)

            {
                case < 1: { waveNum = 0; return; }
                case 1: { wave1(); return; }
                case 2: { wave2(); return; }
                case 3: { wave3(); return; }
                case 4: { wave4(); return; }
                case 6: { wave6(); return; }
                case 7: { wave7(); return; }
                case 8: { wave8(); return; }
                case 9: { wave2D(); return; }



                    //boss waves
                case 5: { bossWave();  return; }
                case int n when (n % 10 == 0): { bossWave(); return; }

                default: // to be changed
                    {
                        switch (Enemy.rnd.Next(2, 9))
                        {
                            case 2: { wave2D(); return; }
                            case 3: { wave3D(); return; }
                            case 4: { wave4(); return; }
                            case 5: { wave5(); return; } //needs coding
                            case 6: { wave6D(); return; }
                            case 7: { wave7D(); return; }
                            case 8: { wave8(); return; }
                        }
                        return;
                    }
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
                    if ((n % 2 == 0)) { spawnPosX -= 12000; }
                    else { spawnPosX += 12000; }
                    currentEnemies.Add(new GroupEnemy(spawnPosX, 100, 11900, y + n * 1200, 30, parent, (n % 2 == 0)));
                }
            }
        }
        private static void addRowGroup(int y, int rows, int speed)
        { //alternative version of the above function to give enemies higher speeds
            for (int n = 0; n < rows; n++)
            {
                for (int i = 0; i < 6; i++)
                {
                    int spawnPosX = 100 + 2100 * i;
                    if ((n % 2 == 0)) { spawnPosX -= 12000; }
                    else { spawnPosX += 12000; }
                    currentEnemies.Add(new GroupEnemy(spawnPosX, 100, 11900, y + n * 1200, speed, parent, (n % 2 == 0)));
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
        private static void wave2D()
        { //for infinite difficulty scaling
            addRowGroup(1000, 2, (int)(30 * Math.Log2(waveNum)));
        }
        private static void wave3()
        {
            addRowGroup(1000, 1);
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, true));
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, false));
        }
        private static void wave3D()
        {
            addRowGroup(1000, 1, (int)(10 * Math.Log2(waveNum)));
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, true));
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, false));
        }

        private static void wave4()
        {
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, true));
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, false));
            currentEnemies.Add(new ChaserEnemy(500, 150, parent, true));
            currentEnemies.Add(new ChaserEnemy(500, 150, parent, false));
            currentEnemies.Add(new ChaserEnemy(1000, 100, parent, true));
            currentEnemies.Add(new ChaserEnemy(1000, 100, parent, false));
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, true));
            currentEnemies.Add(new ChaserEnemy(0, 200, parent, false));
        }


        private static void wave5()
        {
            //put something here for rand
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -1000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -3000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -5000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -7000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -9000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -1000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -3000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -5000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -7000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -9000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -11000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -13000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -15000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -17000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -19000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -11000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -13000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -15000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -17000, 2 * (int)(10 * Math.Log2(waveNum))));
            currentEnemies.Add(new Boulder(parent, Enemy.rnd.Next(0, GameEntity.MAX_XCOORD - 1000), -19000, 2 * (int)(10 * Math.Log2(waveNum))));
        }

        private static void wave6()
        {
            addRowGroup(1000, 3, 60);
            currentEnemies.Add(new Phaser(100, 100, parent));
            currentEnemies.Add(new Phaser(11900, 100, parent));
        }

        private static void wave6D()
        {
            addRowGroup(1000, 3, (int)(20 * Math.Log2(waveNum)));
            currentEnemies.Add(new Phaser(100, 100, parent));
            currentEnemies.Add(new Phaser(11900, 100, parent));
        }

        private static void wave7()
        {
            addRowGroup(3000, 1, 75);
            currentEnemies.Add(new SplitterEnemy(-100, 100, 11900, 100, 45, parent, true));
            currentEnemies.Add(new SplitterEnemy(12100, 100, 11900, 100, 45, parent, false));
        }

        private static void wave7D()
        {
            addRowGroup(3000, 1, (int)(25 * Math.Log2(waveNum)));
            currentEnemies.Add(new SplitterEnemy(-100, 100, 11900, 100, 45, parent, true));
            currentEnemies.Add(new SplitterEnemy(12100, 100, 11900, 100, 45, parent, false));
        }

        private static void wave8()
        {
            Random rnd = new Random();
            for(int i = 0; i<10; i++)
            {
                currentEnemies.Add(new Phaser(rnd.Next(0, 120000), rnd.Next(0, 100000), parent));
            }
            wave4();
        }

        private static void bossWave()
        {
            currentEnemies.Add(new Miniboss(parent));
        }
    }
}
