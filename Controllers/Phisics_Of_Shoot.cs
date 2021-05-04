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
        public double stepX;
        public double stepY;

        public Phisics_Of_Shoot(PointF dir)
        {
            position.X = dir.X;
            position.Y = dir.Y;

            var cursorX = Cursor.Position.X;
            var cursorY = Cursor.Position.Y;

            var gipotenusa = Math.Sqrt(Math.Abs(cursorX - position.X) * Math.Abs(cursorX - position.X) + Math.Abs(cursorY - position.Y) * Math.Abs(cursorY - position.Y));
            stepX = Math.Abs(cursorX - position.X) / gipotenusa;
            stepY = Math.Abs(cursorY - position.Y) / gipotenusa;
        }

        public void PlayShoot (Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Black, 5), position.X, position.Y, 10, 10);

        }

        public void MakeShoot()
        {
            

            position.X += (float)stepX;
            position.Y += (float) stepY;
        }
    }
}
