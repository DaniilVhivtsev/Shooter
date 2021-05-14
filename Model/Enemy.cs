using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Shooter.Model
{
    public class Enemy
    {
        public int Health
        {
            get; set;
        }
        public Point Position;
        public int Size;
        public Image spriteSheetForEnemy;
        public bool Death;

        public Enemy(Point position, int size, int health)
        {
            this.Position.X = position.X * size;
            this.Position.Y = position.Y * size;
            this.Size = size;
            this.Health = health;
            spriteSheetForEnemy = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString(), "Sprites\\Man.png"));
            Death = false;
        }

        public void DrawEnemy(Graphics g)
        {
            if (Health > 0)
                g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(Position.X, Position.Y), new Size(17, 21)), 5, 11, 17, 21, GraphicsUnit.Point);
            else 
                g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(Position.X, Position.Y), new Size(31, 31)), 32 * 6, 32 * 4, 31, 31, GraphicsUnit.Pixel);

            g.DrawEllipse(new Pen(Color.Black, 5), Position.X, Position.Y , 5, 5);
        }
    }
}
