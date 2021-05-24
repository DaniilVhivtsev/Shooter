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
        public static bool isCollide(Entity entity, Point dir)
        {
            for (int i = 0; i < MapController.mapObjects.Count; i++)
            {
                var currentObject = MapController.mapObjects[i];

                PointF delta = new PointF();
                delta.X = (Entity.posX + entity.size / 2) - (currentObject.position.X + currentObject.size.Width / 2);
                delta.Y = (Entity.posY + entity.size / 2) - (currentObject.position.Y + currentObject.size.Height / 2);

                if (Math.Abs(delta.X) <= entity.size / 2 + currentObject.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= entity.size / 2 + currentObject.size.Height / 2)
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

        public static bool isCollide(Point enemy, Point dir)
        {
            for (int i = 0; i < MapController.mapObjects.Count; i++)
            {
                var currentObject = MapController.mapObjects[i];

                PointF delta = new PointF();
                delta.X = (enemy.X + Enemy.Size / 2) - (currentObject.position.X + currentObject.size.Width / 2);
                delta.Y = (enemy.Y + Enemy.Size / 2) - (currentObject.position.Y + currentObject.size.Height / 2);

                if (Math.Abs(delta.X) <= Enemy.Size / 2 + currentObject.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= Enemy.Size / 2 + currentObject.size.Height / 2)
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
