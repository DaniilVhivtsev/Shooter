using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Entites
{
    public class MapEntity
    {
        public PointF position;
        public Size size;

        public MapEntity(PointF pos, Size size)
        {
            this.position = pos;
            this.size = size;
        }
    }
}
