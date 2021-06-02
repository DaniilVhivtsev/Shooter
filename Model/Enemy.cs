using Shooter.Controllers;
using Shooter.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Shooter.Model
{
    public class Enemy
    {
        private int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health <= 0)
                    Death = true;
            }
        }

        public static int Speed;
        public static int NumberOfEnemies;

        public Point Position;
        public static int Size;
        public Image SpriteSheetForEnemy;
        public bool Death;

        public Enemy(Point position, int size, int health)
        {
            this.Position.X = position.X * size;
            this.Position.Y = position.Y * size;
            Size = size;
            this.Health = health;
            SpriteSheetForEnemy = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));
            Death = false;
        }

        public Enemy(int health)
        {
            this.Health = health;
            Death = false;
        }

        /*public void DrawEnemy(Graphics g)
        {
            if (!Death)
                g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(Position.X, Position.Y), new Size(17, 21)), 5, 11, 17, 21, GraphicsUnit.Point);
            else 
                g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(Position.X, Position.Y), new Size(31, 31)), 32 * 6, 32 * 4, 31, 31, GraphicsUnit.Pixel);

            g.DrawRectangle(new Pen(Color.Black, 2), Position.X, Position.Y, 17, 21);
        }*/

        public void EnemyMovement(Point heroPont)
        {
            var value = (new Random()).Next(0, 15);

            if (value > 4)
            {
                var posX = (heroPont.X - Position.X) >= 2 ? 2 : (heroPont.X - Position.X) < 2 ? -2 : 0;
                var posY = (heroPont.Y - Position.Y) >= 2 ? 2 : (heroPont.Y - Position.Y) < 2 ? -2 : 0;
                if (!PhysicsController.IsCollide(Position, new Point(posX, posY)))
                {
                    Position.X += posX;
                    Position.Y += posY;
                }
            }
            else
            {
                var posX = (heroPont.X - Position.X) >= 2 ? -2 : (heroPont.X - Position.X) < 2 ? 2 : 0;
                var posY = (heroPont.Y - Position.Y) >= 2 ? -2 : (heroPont.Y - Position.Y) < 2 ? 2 : 0;
                if (!PhysicsController.IsCollide(Position, new Point(posX, posY)))
                {
                    Position.X += posX;
                    Position.Y += posY;
                }
            }
        }
    }
}
