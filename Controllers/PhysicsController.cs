using Shooter.Entites;
using Shooter.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Controllers
{
    public static class PhysicsController
    {
        public static bool IsCollide(Entity entity, Point dir)
        {
            for (int i = 0; i < MapController.MapObjects.Count; i++)
            {
                var currentObject = MapController.MapObjects[i];

                PointF delta = new PointF();
                delta.X = (Entity.PosX + entity.Size / 2) - (currentObject.Position.X + currentObject.Size.Width / 2);
                delta.Y = (Entity.PosY + entity.Size / 2) - (currentObject.Position.Y + currentObject.Size.Height / 2);

                if (Math.Abs(delta.X) <= entity.Size / 2 + currentObject.Size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= entity.Size / 2 + currentObject.Size.Height / 2)
                    {
 
                        if (delta.X < 0 && dir.X == 2)
                            return true;

                        if (delta.X > 0 && dir.X == -2)
                            return true;

                        if (delta.Y < 0 && dir.Y == 2)
                            return true;

                        if (delta.Y > 0 && dir.Y == -2)
                            return true;

                    }
                }
            }

            return false;
        }

        public static bool IsCollide(Point enemy, Point dir)
        {
            for (int i = 0; i < MapController.MapObjects.Count; i++)
            {
                var currentObject = MapController.MapObjects[i];

                PointF delta = new PointF();
                delta.X = (enemy.X + Enemy.Size / 2) - (currentObject.Position.X + currentObject.Size.Width / 2);
                delta.Y = (enemy.Y + Enemy.Size / 2) - (currentObject.Position.Y + currentObject.Size.Height / 2);

                if (Math.Abs(delta.X) <= Enemy.Size / 2 + currentObject.Size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= Enemy.Size / 2 + currentObject.Size.Height / 2)
                    {

                        if (delta.X < 0 && dir.X == 2)
                            return true;

                        if (delta.X > 0 && dir.X == -2)
                            return true;

                        if (delta.Y < 0 && dir.Y == 2)
                            return true;

                        if (delta.Y > 0 && dir.Y == -2)
                            return true;

                    }
                }
            }

            return false;
        }
    }
}
