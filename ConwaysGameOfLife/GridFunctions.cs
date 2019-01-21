using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class GridFunctions
    {
        public static bool[,] GetNextGeneration(bool[,] oldGrid)
        {
            var width = oldGrid.GetLength(0);
            var height = oldGrid.GetLength(1);

            bool[,] newGrid = new bool[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var neighbouringCellCount = GetAliveNeighbourCount (oldGrid, i, j);

                    switch (oldGrid[i, j])
                    {
                        case true when neighbouringCellCount < 2:
                        case true when neighbouringCellCount > 3:
                            {
                                newGrid[i, j] = false;
                                break;
                            }
                        case true when neighbouringCellCount == 2 ||
                                       neighbouringCellCount == 3:
                            {
                                newGrid[i, j] = true;
                                break;
                            }
                        case false:
                            {
                                newGrid[i, j] = neighbouringCellCount == 3;
                                break;
                            }
                    }
                }
            }

            return newGrid;
        }

        public static bool[,] GetGenerationNumber(bool[,] grid, int generationNumber)
        {
            var tempGrid = grid;
            for(int i = 0; i < generationNumber; i++)
            {
                tempGrid = GetNextGeneration(tempGrid);
            }
            return tempGrid;
        }

        //Might be a bit overcomplicated.
        public static int GetAliveNeighbourCount(bool[,] grid, int i, int j)
        {
            var width = grid.GetLength (0);
            var height = grid.GetLength (1);

            var aliveNeighbours = 0;

            //if not first row
            if (i > 0)
            {
                //if not first column
                if (j > 0 &&
                   grid[i - 1, j - 1])
                    aliveNeighbours++;

                //current column
                if (grid[i - 1, j])
                    aliveNeighbours++;

                //if not last column
                if (j < height - 1 &&
                   grid[i - 1, j + 1])
                    aliveNeighbours++;
            }

            //current row
            if (j > 0 &&
                grid[i, j - 1])
                aliveNeighbours++;

            //current row
            if (j < height - 1 &&
                grid[i, j + 1])
                aliveNeighbours++;


            //if not last row
            if (i < width - 1)
            {
                //if not first column
                if (j > 0 &&
                    grid[i + 1, j - 1])
                    aliveNeighbours++;

                //current column
                if (grid[i + 1, j])
                    aliveNeighbours++;

                //if not last column
                if (j < height - 1 &&
                    grid[i + 1, j + 1])
                    aliveNeighbours++;
            }

            return aliveNeighbours;
        }
    }
}
