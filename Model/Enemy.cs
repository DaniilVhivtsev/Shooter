using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Model
{
    public class Enemy
    {
        public int Health;
        public Point Position;
        public int Size;
        public Image spriteSheetForEnemy;
        public bool Death;


        public Enemy(Point position, int size, int health)
        {
            this.Position = position;
            this.Size = size;
            this.Health = health;
            spriteSheetForEnemy = new Bitmap("C:\\Users\\Полли\\Source\\Repos\\DaniilVhivtsev\\Shooter\\Sprites\\Man.png");
            Death = false;
        }

        public void DrawEnemy(Graphics g)
        {
            if (Health > 0)
                g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(Position.Y * Size, Position.Y * Size), new Size(31, 31)), 32 * 1, 32 * 1, 31, 31, GraphicsUnit.Pixel);
            else
                g.DrawImage(spriteSheetForEnemy, new Rectangle(new Point(Position.Y * Size, Position.Y * Size), new Size(31, 31)), 32 * 1, 32 * 4, 31, 31, GraphicsUnit.Pixel);
        }
    }
}
