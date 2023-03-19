using SnakeGame.Snake;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class MainForm : Form
    {
        Timer _gameTimer;
        private GameField _gameField;
        private int _result;
        private int _stay;

        bool _isStandartOrHard = false;
       
        public MainForm()
        {
            InitializeComponent();
            
            _gameField = new GameField();
            PanelMainWindow.Controls.Add(_gameField.GameFieldControl);

            _gameTimer = new Timer();
            _gameTimer.Interval = 100;
            _gameTimer.Tick += _gameTimer_Tick;
            _gameField.Food.Respawn(_gameField.GameFieldControl.Width, _gameField.GameFieldControl.Height, _gameField.Snake);
        }
        private void _gameTimer_Tick(object sender, EventArgs e)
        {
            if(!_gameField.Snake.IsDead(_gameField.GameFieldControl.Width, _gameField.GameFieldControl.Height))
            {
                if (_gameField.Snake.IsCanMove(_gameField.GameFieldControl.Width, _gameField.GameFieldControl.Height))
                {
                    _gameField.Snake.Move();
                    if (_gameField.Snake.IsCanEat(_gameField.Food))
                    {
                        _result = int.Parse(toolStripLabel2.Text);
                        _result++;
                        toolStripLabel2.Text = _result.ToString();
                        _stay = int.Parse(toolStripLabel4.Text);
                        _stay--;
                        toolStripLabel4.Text = _stay.ToString();
                        _gameField.Snake.Grow();
                        _gameField.Food.Respawn(_gameField.GameFieldControl.Width, _gameField.GameFieldControl.Height, _gameField.Snake);
                        if(_isStandartOrHard && _gameTimer.Interval > 30)
                        {
                            _gameTimer.Interval -= 5;
                        }
                        if((!_isStandartOrHard && _result == 20) || (_isStandartOrHard && _result == 50))
                        {
                            _gameTimer.Stop();
                            var dialogResult = MessageBox.Show("Level complete", "Huray", MessageBoxButtons.OK);
                            if (dialogResult == DialogResult.OK)
                            {
                                SpawnGame();
                                toolStripButton1.Text = "Start";
                            }
                        }
                    }
                }
            }
            else
            {
                _gameTimer.Stop();
                var dialogResult = MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK);
                if(dialogResult == DialogResult.OK)
                {
                    SpawnGame();
                    toolStripButton1.Text = "Start";
                }
            }

            _gameField.GameFieldControl.Refresh();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.Text = e.KeyCode.ToString();
            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.UP;
                        break;
                    }
                case Keys.S:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.DOWN;
                        break;
                    }
                case Keys.A:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.LEFT;
                        break;
                    }
                case Keys.D:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.RIGHT;
                        break;
                    }



                case Keys.Up:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.UP;
                        break;
                    }
                case Keys.Down:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.DOWN;
                        break;
                    }
                case Keys.Left:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.LEFT;
                        break;
                    }
                case Keys.Right:
                    {
                        _gameField.Snake.Head.CurrentDiraction = Snake.Direction.RIGHT;
                        break;
                    }
            }
        }
        private void SpawnGame()
        {
            toolStripLabel2.Text = "0";
            if (_isStandartOrHard) 
                toolStripLabel4.Text = "50";
            else
                toolStripLabel4.Text = "20";

            PanelMainWindow.Controls.Clear();
            _gameField = new GameField();
            PanelMainWindow.Controls.Add(_gameField.GameFieldControl);

            _gameTimer = new Timer();
            _gameTimer.Interval = 100;
            _gameTimer.Tick += _gameTimer_Tick;
            _gameField.Food.Respawn(_gameField.GameFieldControl.Width, _gameField.GameFieldControl.Height, _gameField.Snake);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if(toolStripButton1.Text == "Start")
            {
                _gameTimer.Start();
                
                toolStripButton1.Text = "Stop";
            }
            else if(toolStripButton1.Text == "Stop")
            {
                _gameTimer.Stop();
                SpawnGame();
                toolStripButton1.Text = "Start";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(toolStripButton1.Text != "Start")
            {
                if (toolStripButton2.Text == "Pause")
                {
                    _gameTimer.Stop();

                    toolStripButton2.Text = "Resume";
                }
                else if (toolStripButton2.Text == "Resume")
                {
                    _gameTimer.Start();

                    toolStripButton2.Text = "Pause";
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (toolStripButton1.Text != "Stop")
            {
                if (toolStripButton3.Text == "Standart")
                {
                    toolStripLabel4.Text = "50";
                    _isStandartOrHard = true;
                    toolStripButton3.Text = "Hard";
                }
                else if (toolStripButton3.Text == "Hard")
                {
                    toolStripLabel4.Text = "20";
                    _isStandartOrHard = false;
                    toolStripButton3.Text = "Standart";
                }
            }
        }
    }
}
