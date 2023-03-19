using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    internal class GameField
    {
        private PictureBox _gameFieldControl;
        private Snake.Snake _snake;
        public Snake.Food Food { get; set; }
        public Snake.Snake Snake { get { return _snake; } }
        public PictureBox GameFieldControl { get { return _gameFieldControl; } }
        public GameField()
        {
            _snake= new Snake.Snake();
            _gameFieldControl = new PictureBox();
            _gameFieldControl.BackColor = Color.Black;
            _gameFieldControl.Dock = DockStyle.Fill;
            _gameFieldControl.Paint += _gameFieldControl_Paint;
            _snake = new Snake.Snake();
            Food = new Snake.Food(_snake.Head.Radius);
        }

        private void _gameFieldControl_Paint(object sender, PaintEventArgs e)
        {
            _snake.Draw(e.Graphics);
            Food.Draw(e.Graphics);
        }
    }
}
