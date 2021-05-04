﻿using Shooter.Entites;
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
                delta.X = (entity.posX + entity.size / 2) - (currentObject.position.X + currentObject.size.Width / 2);
                delta.Y = (entity.posY + entity.size / 2) - (currentObject.position.Y + currentObject.size.Height / 2);

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
    }
}