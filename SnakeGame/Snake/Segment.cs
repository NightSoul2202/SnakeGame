using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    internal class Segment
    {
        private int _x;
        private int _y;
        public Color Color;
        private int _radius;

        public int X { 
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }
        public Segment()
        {
            Radius = 15;
            X = 30;
            Y = 30;
        }
        public Segment(int x, int y, int radius) 
        { 
            Radius = radius;
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X: {X}; Y: {Y}; Radius: {Radius}.";
        }

    }
}
