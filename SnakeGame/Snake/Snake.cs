using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Snake
{
    internal class Snake : ISegmentBehavior
    {
        List<Segment> _snake;
        public Snake()
        {
            _snake = new List<Segment>();
            _snake.Add(new HeadSnake(45, 45, 15, Direction.RIGHT));
            _snake.Add(new SegmentSnake(Head.X - Head.Radius * 2, Head.Y, Head.Radius, Color.LawnGreen));
            _snake.Add(new TailSnake(Head.X - Head.Radius * 4, Head.Y, Head.Radius, Color.DarkGreen));
        }
        public bool IsCanMove(int width, int height)
        {
            switch (Head.CurrentDiraction)
            {
                case Direction.UP:
                    if (Head.Y - Head.Radius * 2 > 0)
                        return true;
                    break;
                case Direction.DOWN:
                    if (Head.Y + Head.Radius * 2 < height)
                        return true;
                    break;
                case Direction.LEFT:
                    if (Head.X - Head.Radius * 2 > 0)
                        return true;
                    break;
                case Direction.RIGHT:
                    if (Head.X + Head.Radius * 2 < width)
                        return true;
                    break;
            }
            return false;
        }
        public List<Segment> BodySnake
        {
            get {
                return _snake;
            }

        }
        public HeadSnake Head
        {
            get
            {
                return (HeadSnake)_snake.FirstOrDefault();
            }
        }

        public void Draw(Graphics graphics)
        {
            foreach (var item in _snake)
            {
                if (item is HeadSnake)
                {
                    ((HeadSnake)item).Draw(graphics);
                }
                else if (item is SegmentSnake)
                {
                    ((SegmentSnake)item).Draw(graphics);
                }
                else if (item is TailSnake)
                {
                    ((TailSnake)item).Draw(graphics);
                }
            }
        }

        public void Move()
        {
            int step = this.Head.Radius * 2;
            int oldX = Head.X;
            int oldY = Head.Y;

            switch (Head.CurrentDiraction)
            {
                case Direction.RIGHT:
                    Head.X += step;
                    break;
                case Direction.LEFT:
                    Head.X -= step;
                    break;
                case Direction.UP:
                    Head.Y -= step;
                    break;
                case Direction.DOWN:
                    Head.Y += step;
                    break;
            }

            for (int i = _snake.Count - 1; i > 1; i--)
            {
                _snake[i].X = _snake[i - 1].X;
                _snake[i].Y = _snake[i - 1].Y;
            }
            _snake[1].X = oldX;
            _snake[1].Y = oldY;
        }

        internal bool IsCanEat(Food food)
        {
            return food.X == Head.X && food.Y == Head.Y ? true : false;
        }

        public void Grow()
        { 
            _snake.Insert(2, new SegmentSnake(Head.X - Head.Radius * Head.X, Head.Y, Head.Radius, Color.LawnGreen));
        }
        public bool IsDead(int width, int height)
        {
           
            bool isBodySnake = false;
            for(int i = 1; i < _snake.Count; i++)
            {
                if (_snake[i].X == Head.X && _snake[i].Y == Head.Y)
                {
                    isBodySnake = true;
                }
            }
            return isBodySnake;
        }
    }
}
