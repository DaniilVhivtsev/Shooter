using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Shooter.Entites
{
    public class MapEntity
    {
        public PointF Position;
        public Size Size;

        public MapEntity(PointF pos, Size size)
        {
            this.Position = pos;
            this.Size = size;
        }
    }
}
