using Shooter.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Shooter.Controllers
{
    public class Phisics_Of_Shoot
    {
        public Point position;
        public int stepX;
        public int stepY;
        public const int speed = 10;

        public int countOfStep;

        public Phisics_Of_Shoot(Point dir)
        {
            position.X = dir.X;
            position.Y = dir.Y;

            
            stepX = (Cursor.Position.X - position.X) / speed;
            stepY = (Cursor.Position.Y - position.Y) / speed;

            countOfStep = 0;
        }

        public void PlayShoot (Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Black, 5), position.X, position.Y, 5, 5);
            g.DrawEllipse(new Pen(Color.Black, 5), Cursor.Position.X, Cursor.Position.Y, 5, 5);
        }

        public bool MakeShoot()
        {
            if (countOfStep == 10) return false;
            countOfStep++;
            position.X += stepX;
            position.Y += stepY;
            KillEnemy();
            return true;
        }

        public void KillEnemy()
        {
            for (int i = 0; i < MapController.enemies.Count; i++)
            {
                var enemy = MapController.enemies[i];
/*                if (position.X >= enemy.Position.X - enemy.Size / 2 && position.X <= enemy.Position.X + enemy.Size / 2)
                    if (position.Y >= enemy.Position.Y - enemy.Size / 2 && position.Y <= enemy.Position.Y + enemy.Size / 2)*/

                if (position.X == enemy.Position.X)
                    if (position.Y == enemy.Position.Y)
                        enemy.Health -= 50;
            }
        }
    }
}
