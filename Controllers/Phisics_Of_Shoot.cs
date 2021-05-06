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
        public PointF position;
        public float stepX;
        public float stepY;
        public const int speed = 10;

        public int countOfStep;

        public Phisics_Of_Shoot(PointF dir)
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
            return true;
        }

        public void KillEnemy()
        {
            if (array[position.X, position.Y] == 100 )
        }
    }
}
