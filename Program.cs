using System;
using TD_Jeu_de_la_vie;

namespace TD_Jeu_de_la_vie
{
    static class Program
    {
        static void Main()
        {
            Game game = new Game(3, 10);
            game.RunGameConsole();
        }
    }
}