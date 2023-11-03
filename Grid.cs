using System;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;

namespace TD_Jeu_de_la_vie.Files
{
    class Grid
    {
        private int _gridSize;
        public int GridSize { get { return _gridSize; } set { _gridSize = value; } }

        Cell[,] TabCells;

        public Grid(int nbCells, List<Coords> AliveCellsCoords)
        {
            this.GridSize = nbCells;
            TabCells = new Cell[GridSize, GridSize];

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    TabCells[i, j] = new Cell(false);
                    for (int k = 0; k < AliveCellsCoords.Count; k++)
                    {
                        if (AliveCellsCoords[k].X == i && AliveCellsCoords[k].Y == j)
                        {
                            TabCells[i, j] = new Cell(true);
                            break;
                        }
                    }
                }
            }
        }

        public int GetNbAliveNeighboor(int i, int j)
        {
            /*int closeCells = 0;
            for (int x = -1; i <= 1; i++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if TabCells[i + x, j + y] != null
                        closeCells += 1;
                }
            }*/

            if (TabCells[i, j] != null) return 1;
            else return 0;
        }

        public List<Coords> GetCoordsNeighboors(int i, int j)
        {
            List<Coords> validCoords = new List<Coords>();
            for (int x = -1; x <= 1; i++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (i - x >= 0 && j - y >= 0)
                    {
                        validCoords.Add(new Coords(i + x, j + y));
                    }
                }
            }

            return validCoords;
        }

        public List<Coords> GetCoordsCellsAlive()
        {
            return new List<Coords>();
        }

        public void DisplayGrid()
        {
            const string upDownString = "+---";

            for (int x = 0; x < GridSize; x++)
            {
                for (int i = 0; i < GridSize; i++)
                {
                    Console.Write(upDownString);
                }
                Console.Write("+\n");
                for (int i = 0; i < GridSize; i++)
                {
                    Console.Write("| {0} ", TabCells[i, x].IsAlive ? "X" : " ");
                }
                Console.Write("|\n");
            }
            for (int i = 0; i < GridSize; i++)
            {
                Console.Write(upDownString);
            }
            Console.Write("+");
        }

        public void UpdateGrid()
        {
            int closeCells = 0;
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    closeCells = 0;
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (!(x == 0 && y == 0))
                            {
                                if (i + x >= 0 && j + y >= 0 && i + x < GridSize && j + y < GridSize)
                                {
                                    if (TabCells[i + x, j + y].IsAlive)
                                        closeCells++;
                                }
                            }
                        }
                    }
                    if (TabCells[i, j].IsAlive && (closeCells == 2 || closeCells == 3))
                    {
                        TabCells[i, j].NextState = true;
                    }
                    else if (!TabCells[i, j].IsAlive && closeCells == 3)
                    {
                        TabCells[i, j].NextState = true;
                    }
                    else
                    {
                        TabCells[i, j].NextState = false;
                    }
                }
            }

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    TabCells[i, j].Update();
                }
            }
        }
    }
}