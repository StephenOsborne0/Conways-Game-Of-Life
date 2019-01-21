using System;
using System.Linq;
using System.Collections;
using System.Windows.Forms;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class PatternTests
    {
        private bool GridEquals(bool[,] grid1, bool[,] grid2)
        {
            var width = grid1.GetLength(0);
            var height = grid1.GetLength(1);

            if(grid2.GetLength(0) != width ||
               grid2.GetLength(1) != height)
                return false;

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(grid1[i, j] != grid2[i, j])
                        return false;
                }
            }

            return true;
        }

        [TestMethod]
        public void StillLifeTest1()
        {
            bool[,] grid = new bool[4, 4];

            //Block
            grid[1, 1] = true;
            grid[1, 2] = true;
            grid[2, 1] = true;
            grid[2, 2] = true;

            var newGrid = GridFunctions.GetNextGeneration(grid);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void StillLifeTest2()
        {
            bool[,] grid = new bool[6, 6];

            //Beehive
            grid[2, 1] = true;
            grid[3, 1] = true;
            grid[1, 2] = true;
            grid[4, 2] = true;
            grid[2, 3] = true;
            grid[3, 3] = true;

            var newGrid = GridFunctions.GetNextGeneration(grid);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void StillLifeTest3()
        {
            bool[,] grid = new bool[6, 6];

            //Loaf
            grid[2, 1] = true;
            grid[3, 1] = true;
            grid[1, 2] = true;
            grid[4, 2] = true;
            grid[2, 3] = true;
            grid[4, 3] = true;
            grid[3, 4] = true;

            var newGrid = GridFunctions.GetNextGeneration(grid);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void StillLifeTest4()
        {
            bool[,] grid = new bool[5, 5];

            //Boat
            grid[1, 1] = true;
            grid[1, 2] = true;
            grid[2, 1] = true;
            grid[3, 2] = true;
            grid[2, 3] = true;

            var newGrid = GridFunctions.GetNextGeneration(grid);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void StillLifeTest5()
        {
            bool[,] grid = new bool[5, 5];

            //Tub
            grid[2, 1] = true;
            grid[1, 2] = true;
            grid[3, 2] = true;
            grid[2, 3] = true;

            var newGrid = GridFunctions.GetNextGeneration(grid);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void OscillatorTest1()
        {
            bool[,] grid = new bool[5, 5];

            //Blinker
            grid[1, 2] = true;
            grid[2, 2] = true;
            grid[3, 2] = true;

            var newGrid = GridFunctions.GetGenerationNumber(grid, 2);
            Assert.IsTrue(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 3);
            Assert.IsFalse(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 4);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void OscillatorTest2()
        {
            bool[,] grid = new bool[6, 6];

            //Toad
            grid[2, 2] = true;
            grid[3, 2] = true;
            grid[4, 2] = true;
            grid[1, 3] = true;
            grid[2, 3] = true;
            grid[3, 3] = true;

            var newGrid = GridFunctions.GetGenerationNumber(grid, 2);
            Assert.IsTrue(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 3);
            Assert.IsFalse(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 4);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void OscillatorTest3()
        {
            bool[,] grid = new bool[6, 6];

            //Beacon
            grid[1, 1] = true;
            grid[2, 1] = true;
            grid[1, 2] = true;
            grid[4, 3] = true;
            grid[3, 4] = true;
            grid[4, 4] = true;

            var newGrid = GridFunctions.GetGenerationNumber(grid, 2);
            Assert.IsTrue(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 3);
            Assert.IsFalse(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 4);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void OscillatorTest4()
        {
            bool[,] grid = new bool[17, 17];

            //Pulsar

            //Top
            grid[5, 1] = true;
            grid[5, 2] = true;
            grid[5, 3] = true;
            grid[6, 3] = true;
            grid[11, 1] = true;
            grid[11, 2] = true;
            grid[11, 3] = true;
            grid[10, 3] = true;

            //Left hand side
            grid[1, 5] = true;
            grid[2, 5] = true;
            grid[3, 5] = true;
            grid[3, 6] = true;
            grid[1, 11] = true;
            grid[2, 11] = true;
            grid[3, 11] = true;
            grid[3, 10] = true;

            //Right hand side
            grid[13, 5] = true;
            grid[13, 6] = true;
            grid[14, 5] = true;
            grid[15, 5] = true;
            grid[13, 10] = true;
            grid[13, 11] = true;
            grid[14, 11] = true;
            grid[15, 11] = true;

            //Bottom
            grid[5, 13] = true;
            grid[6, 13] = true;
            grid[5, 14] = true;
            grid[5, 15] = true;
            grid[10, 13] = true;
            grid[11, 13] = true;
            grid[11, 14] = true;
            grid[11, 15] = true;

            //Center Top Left
            grid[6, 5] = true;
            grid[7, 5] = true;
            grid[5, 6] = true;
            grid[5, 7] = true;
            grid[7, 6] = true;
            grid[6, 7] = true;

            //Center Top Right
            grid[9, 5] = true;
            grid[10, 5] = true;
            grid[9, 6] = true;
            grid[11, 6] = true;
            grid[11, 7] = true;
            grid[10, 7] = true;

            //Center Bottom Left
            grid[5, 9] = true;
            grid[5, 10] = true;
            grid[6, 9] = true;
            grid[6, 11] = true;
            grid[7, 11] = true;
            grid[7, 10] = true;

            //Center Bottom Right
            grid[10, 9] = true;
            grid[11, 9] = true;
            grid[9, 10] = true;
            grid[9, 11] = true;
            grid[11, 10] = true;
            grid[10, 11] = true;

            var newGrid = GridFunctions.GetGenerationNumber(grid, 1);
            Assert.IsFalse(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 2);
            Assert.IsFalse(GridEquals(grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber(grid, 3);
            Assert.IsTrue(GridEquals(grid, newGrid));
        }

        [TestMethod]
        public void OscillatorTest5()
        {
            bool[,] grid = new bool[11, 18];

            //PentaDecathlon

            //Top
            grid[4, 3] = true;
            grid[5, 3] = true;
            grid[6, 3] = true;
            grid[5, 4] = true;
            grid[5, 5] = true;
            grid[4, 6] = true;
            grid[5, 6] = true;
            grid[6, 6] = true;

            //Middle
            grid[4, 8] = true;
            grid[5, 8] = true;
            grid[6, 8] = true;
            grid[4, 9] = true;
            grid[5, 9] = true;
            grid[6, 9] = true;

            //Bottom
            grid[4, 11] = true;
            grid[5, 11] = true;
            grid[6, 11] = true;
            grid[5, 12] = true;
            grid[5, 13] = true;
            grid[4, 14] = true;
            grid[5, 14] = true;
            grid[6, 14] = true;

            var newGrid = GridFunctions.GetGenerationNumber (grid, 5);
            Assert.IsFalse (GridEquals (grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber (grid, 10);
            Assert.IsFalse (GridEquals (grid, newGrid));

            newGrid = GridFunctions.GetGenerationNumber (grid, 15);
            Assert.IsTrue (GridEquals (grid, newGrid));
        }
    }
}