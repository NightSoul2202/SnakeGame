using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    internal class Food : Segment, ISegmentBehavior
    {
        private Random _random ;
        public Food(int radius)
        {
            _random= new Random();
            Radius = radius;

        }
        public Food(int x, int y, int radius) : base(x, y, radius) 
        {
            _random = new Random();
        }

        public void Draw(Graphics graphics)
        {
            Bitmap bitmap = new Bitmap(GameResource.apple);
            bitmap.MakeTransparent();
            graphics.DrawImage(bitmap, new Rectangle(this.X - Radius, this.Y - Radius, this.Radius * 2, this.Radius * 2));
        }

        public void Respawn(int width, int height, Snake snake)
        {
            int pX = 0; 
            int pY = 0;

            bool IsValidPosition = false;
            do
            {
                pX = (_random.Next(Radius * 2, width - Radius) / (Radius * 2) * (Radius * 2)) - Radius;
                pY = (_random.Next(Radius * 2, height - Radius) / (Radius * 2) * (Radius * 2)) - Radius;

                bool isBodySnake = true;
                foreach (Segment item in snake.BodySnake)
                {
                    if(item.X == pX && item.Y == pY)
                    {
                        isBodySnake = false;
                        break;
                    }
                }
                if( isBodySnake)
                {
                    X = pX;
                    Y = pY;
                    IsValidPosition= true;
                }
            } while (!IsValidPosition);
        }
    }
}
