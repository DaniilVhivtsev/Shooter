using Shooter.Entites;
using Shooter.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Shooter.Controllers
{
    public static class MapController
    {

        public static int mapHeight;
        public static int mapWidth;
        public static int cellSize = 31;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;
        public static List<MapEntity> mapObjects;

        public static Image spriteSheetForEnemy;
        public static List<Enemy> enemies;

/*        C:\Users\Данил\Source\Repos\DaniilVhivtsev\Shooter\Sprites\Forest.png
*/        public static void Init()
        {
            map = GetMap();
            mapHeight = map.GetLength(1);
            mapWidth = map.GetLength(0);
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Forest.png"));
            mapObjects = new List<MapEntity>();
            spriteSheetForEnemy = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));
            enemies = new List<Enemy>();
            MakeEnemies();
        }
        public static int[,] GetMap() => new int[,]
            {
                {1, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 2 },
                {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                {5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0, 7 },
                {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                {3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 4 }
            };

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 10)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(107, 114)), 203, 298, 107, 114, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(107, 114));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 12)), 581, 114, 19, 11, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(20, 12));
                        mapObjects.Add(mapEntity);
                    }
                    if (map[i, j] == 20)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(20, 18)), 453, 225, 18, 22, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * cellSize, i * cellSize), new Size(20, 18));
                        mapObjects.Add(mapEntity);
                    }
                    /*if (map[i, j] == 100)
                    {
                        *//*g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(31, 31)), 32 * 1, 32 * 1, 31, 31, GraphicsUnit.Pixel);*//*
                        var enemyObject = new Enemy(new Point(i, j), 31, 100);
                        *//*enemyObject.DrawEnemy(g);*//*
                        enemies.Add(enemyObject);
                    }*/
                }
        }

        public static void MakeEnemies()
        {
            for (int i = 0; i < mapWidth; i++)
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 100)
                    {
                        /*g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(31, 31)), 32 * 1, 32 * 1, 31, 31, GraphicsUnit.Pixel);*/
                        var enemyObject = new Enemy(new Point(j, i), 31, 100);
                        /*enemyObject.DrawEnemy(g);*/
                        enemies.Add(enemyObject);
                    }
                }
        }

        public static void DrawEnemies(Graphics g)
        {
            foreach (var enemy in enemies)
            {
                enemy.DrawEnemy(g);
            }
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapWidth; i++)
                for (int j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 170,30, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                }
            DrawEnemies(g);
            SeedMap(g);
        }

        public static int GetWidth()
        {
            return cellSize * (mapWidth) + 5;
        }

        public static int GetHeight()
        {
            return cellSize * (mapHeight + 1) - 5 ;
        }
    }
}
