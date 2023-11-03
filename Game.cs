using System;
using System.Collections.Generic;
using System.Threading;
using TD_Jeu_de_la_vie.Files;

namespace TD_Jeu_de_la_vie
{
    class Game
    {
        private int _gridSize;
        private int _iter;
        public Grid grid;
        List<Coords> AliveCellsCoords = new List<Coords>() { { new Coords(0, 1) }, new Coords(1, 1), new Coords(2, 1) };

        public Game(int nbCells, int nbIterations)
        {
            _gridSize = nbCells;
            _iter = nbIterations;
            grid = new Grid(nbCells, AliveCellsCoords);
        }

        public void RunGameConsole()
        {
            for (int i = 0; i < 10; i++)
            {
                grid.DisplayGrid();
                grid.UpdateGrid();
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
