using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinF
{
    class GameFlow
    {
        public bool player1Turn { get; set; } = true;
        public int playerTurnCount { get; set; } = 0;
        public string[] GameMoves { get; set; } = new string[9];
    }
}
