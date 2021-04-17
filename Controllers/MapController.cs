using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Controllers
{
    public static class MapController
    {

        public const int mapHeight = 20;
        public const int mapWidth =20;
        public static int cellSize = 31;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;


        public static void Init()
        {
            map = GetMap();
            spriteSheet = new Bitmap("C:\\Users\\Данил\\source\\repos\\Shooter\\Sprites\\Forest.png");
        }
        public static int[,] GetMap()
        {
            var array = new int[mapHeight, mapWidth];
            for (int i = 0; i < mapHeight; i++)
                for (int j = 0; j < mapWidth; j++)
                    array[i, j] = 1;
            return array;
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                }
        }

    }
}
