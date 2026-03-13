using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect4Winforms
{
    public partial class Form1 : Form
    {
        private int _left = 10;
        private int _top = 20;
        private int _globalWidth = 50;
        private int _globalHeight = 50;
        private player _currentPlayer;
        private bool _boolCurrentPlayer;
        private player[] _players;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Button[] btnRows = loadRowBtns();
            Cell[,] cellGrid = gridLoader();
             _players = setupPlayers();
            _boolCurrentPlayer = false; 
            _currentPlayer = _players[0];


        }

        private void changePlayer()
        {
            if (_boolCurrentPlayer)
            {
                _boolCurrentPlayer = false;
                _currentPlayer = _players[0];

            }
            else
            {
                _boolCurrentPlayer = true;
                _currentPlayer = _players[1];
            }
        }

        private player[] setupPlayers()
        {
            player[] players = new player[2];
            players[0] = new player(Color.Blue);
            players[1] = new player(Color.Red);
            return players;
        }

        private Cell[,] gridLoader()
        {
            Cell[,] grid = new Cell[6,7];
            for (int i = 0; i <6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Cell c = new Cell(i, j, _globalWidth, _globalHeight, _top, _left);
                    this.Controls.Add(c);
                    grid[i, j] = c;

                }
            }
            return grid;
        }

        private Button[] loadRowBtns()
        {

            Button[] btnRowBnt = new Button[7];
            for (int i = 0; i < btnRowBnt.Length; i++)
            {
                btnRowBnt[i] = new Button();
                setupBTN(btnRowBnt[i], i);
            }
            return btnRowBnt;
        
        }

        private void setupBTN(Button btn, int btnNumber)
        {
            btn.Width = 50;
            btn.Height = 50;
            btn.Left = _left + (60*btnNumber);
            btn.Top = _top;

            btn.Text = (btnNumber + 1).ToString();
            this.Controls.Add(btn);
        }

        private void _BntClick(object sender , EventArgs e)
        {
            Button btn = sender as Button;
            int col = Convert.ToInt32(btn.Text.ToString())-1;           
        }

    }

    public class Cell : PictureBox
    {

        private bool _filled = false;
        private int _col;
        private int _row;
        
        public Cell(int row, int col , int width, int height,int top, int left)
        {
            _col = col;
            _row = row;
            Left = left + (60 * col + 1);
            Top = top +60+ (60*row);
            Width = width;
            Height = height;
            BackColor = Color.Gray;
        }


        public bool getFilled() { return _filled; }
        
        public int getCol() { return _col; }

        public int getRow() { return _row; }
        public void setFilled(bool filled) { _filled = filled; }

        
    }

    public class player
    {

        private Color _colour;

        public player(Color colour)
        { 
            _colour = colour;
        }

        public Color getColour() { return _colour; }

    }
}
