using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    internal class SegmentSnake : Segment, ISegmentBehavior
    {
        public SegmentSnake(int x, int y, int radius, Color color) : base(x, y, radius) 
        {
            Color = color;
        }

        public void Draw(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(this.Color), this.X - this.Radius, this.Y - Radius, this.Radius * 2, this.Radius * 2);

        }
    }
}
