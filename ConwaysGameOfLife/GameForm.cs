using System;
using System.Drawing;
using System.Windows.Forms;
using static ConwaysGameOfLife.GridFunctions;

namespace ConwaysGameOfLife
{
    public partial class GameForm : Form
    {
        private bool[,] _grid;

        private int _gridWidth;
        private int _gridHeight;
        private int _seed;
        private Bitmap _bitmap;

        public GameForm()
        {
            InitializeComponent ();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            _gridWidth = Properties.Settings.Default.Grid_Width;
            _gridHeight = Properties.Settings.Default.Grid_Height;

            _bitmap = new Bitmap (_gridWidth, _gridHeight);
            pictureBox1.BackgroundImage = _bitmap;

            _seed = Properties.Settings.Default.UseRandomSeed ? 
                new Random().Next(int.MaxValue) : 
                Properties.Settings.Default.Seed;

            GenerateGridFromSeed ();
            DisplayGrid();
        }

        private void GenerateGridFromSeed()
        {
            Random random = new Random (_seed);
            _grid = new bool[_gridWidth, _gridHeight];
            for (int i = 0; i < _gridHeight; i++)
            {
                for (int j = 0; j < _gridWidth; j++)
                {
                    _grid[i, j] = Convert.ToBoolean (random.Next (0, 2));
                }
            }
        }

        private void DisplayGrid()
        {
            for (int i = 0; i < _gridHeight; i++)
            {
                for (int j = 0; j < _gridWidth; j++)
                {
                    _bitmap.SetPixel(i, j, _grid[i, j] ? Color.Black : Color.White);
                }
            }
            pictureBox1.Invalidate();
        }

        private void UpdateGrid()
        {
            _grid = GetNextGeneration(_grid);
            DisplayGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGrid();
        }
    }
}
