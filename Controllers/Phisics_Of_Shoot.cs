using Shooter.Entites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Controllers
{
    public class Phisics_Of_Shoot
    {
        public PointF position;

        public Phisics_Of_Shoot(PointF dir)
        {
            position.X = dir.X;
            position.Y = dir.Y;
        }

        public void PlayShoot (Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black, 5), position.X, position.Y, 10, 10);

        }

        public void MakeShoot()
        {
            position.X += 1;
            position.Y += 11;
        }
    }
}
