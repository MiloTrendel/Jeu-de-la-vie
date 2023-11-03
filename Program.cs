using System;
using TD_Jeu_de_la_vie;

namespace TD_Jeu_de_la_vie
{
    static class Program
    {
        static void Main()
        {
            Game game = new Game(10, 10);
            game.RunGameConsole();
        }
    }
}