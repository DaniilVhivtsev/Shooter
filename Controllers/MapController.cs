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

        public static int MapHeight;
        public static int MapWidth;
        public static int CellSize = 31;
        public static int[,] Map = new int[MapHeight, MapWidth];
        public static Image SpriteSheet;
        public static List<MapEntity> MapObjects;

        public static Image SpriteSheetForEnemy;
        public static List<Enemy> Enemies;

/*        C:\Users\Данил\Source\Repos\DaniilVhivtsev\Shooter\Sprites\Forest.png
*/        public static void Init()
        {
            Map = GetMap();
            MapHeight = Map.GetLength(1);
            MapWidth = Map.GetLength(0);
            SpriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Forest.png"));
            MapObjects = new List<MapEntity>();
            SpriteSheetForEnemy = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));
            Enemies = new List<Enemy>();
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
                {5, 10, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 100, 0, 0, 0, 0, 0, 0, 100, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 7 },
                {5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0, 0, 7 },
                {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                {5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },
                {3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 4 }
            };

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                {
                    if (Map[i, j] == 10)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(107, 114)), 203, 298, 107, 114, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * CellSize, i * CellSize), new Size(107, 114));
                        MapObjects.Add(mapEntity);
                    }
                    if (Map[i, j] == 11)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(20, 12)), 581, 114, 19, 11, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * CellSize, i * CellSize), new Size(20, 12));
                        MapObjects.Add(mapEntity);
                    }
                    if (Map[i, j] == 20)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(20, 18)), 453, 225, 18, 22, GraphicsUnit.Pixel);
                        MapEntity mapEntity = new MapEntity(new Point(j * CellSize, i * CellSize), new Size(20, 18));
                        MapObjects.Add(mapEntity);
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
            var numberOfEnemies = 0;
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                {
                    if (Map[i, j] == 100)
                    {
                        if (numberOfEnemies < Game.NumberOfEnemiesNumericNumber)
                        {
                            /*g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(31, 31)), 32 * 1, 32 * 1, 31, 31, GraphicsUnit.Pixel);*/
                            var enemyObject = new Enemy(new Point(j, i), 31, 100);
                            /*enemyObject.DrawEnemy(g);*/
                            Enemies.Add(enemyObject);
                            numberOfEnemies++;
                        }
                    }
                }
        }

        public static void DrawEnemies(Graphics g)
        {
            foreach (var enemy in Enemies)
            {
                DrawEnemy(g, enemy);
            }
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < MapWidth; i++)
                for (int j = 0; j < MapHeight; j++)
                {
                    if (Map[i, j] == 1)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 96, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 2)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 170, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 3)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 96, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 4)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 170, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 5)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 96, 20, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 6)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 120, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 7)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 170,30, 20, 20, GraphicsUnit.Pixel);
                    }
                    else if(Map[i, j] == 8)
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 120, 75, 20, 20, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g.DrawImage(SpriteSheet, new Rectangle(new Point(j * CellSize, i * CellSize), new Size(CellSize, CellSize)), 0, 0, 20, 20, GraphicsUnit.Pixel);
                    }
                }
            DrawEnemies(g);
            SeedMap(g);
        }

        public static int GetWidth()
        {
            return CellSize * (MapWidth) + 5;
        }

        public static int GetHeight()
        {
            return CellSize * (MapHeight + 1) - 5 ;
        }

        public static void PlayAnimation(Graphics g, Entity player)
        {
            if (player.CurrentFrame < player.CurrentLimit - 1)
                player.CurrentFrame++;
            else if (!Entity.Death)
                player.CurrentFrame = 0;

            g.DrawImage(player.SpriteSheet, new Rectangle(new Point(Entity.PosX, Entity.PosY), new Size(player.Size, player.Size)), 32 * player.CurrentFrame, 32 * player.CurrentAnimation, player.Size, player.Size, GraphicsUnit.Pixel);
        }

        public static void DrawEnemy(Graphics g, Enemy enemy)
        {
            if (!enemy.Death)
                g.DrawImage(SpriteSheetForEnemy, new Rectangle(new Point(enemy.Position.X, enemy.Position.Y), new Size(17, 21)), 5, 11, 17, 21, GraphicsUnit.Point);
            else
                g.DrawImage(SpriteSheetForEnemy, new Rectangle(new Point(enemy.Position.X, enemy.Position.Y), new Size(31, 31)), 32 * 6, 32 * 4, 31, 31, GraphicsUnit.Pixel);

            g.DrawRectangle(new Pen(Color.Black, 2), enemy.Position.X, enemy.Position.Y, 17, 21);
        }
    }
}
