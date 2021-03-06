﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinF
{
    class PlayData
    {
        public PlayData()
        {
        }
        
        public bool PlayerXTurn { get; set; } = true;
        public bool WinResult { get; set; } = false;
        public int PlayerTurnCount { get; set; } = 0;
        public CellType[] GameMoves { get; set; } = new CellType[9];
    
        public void InitGameMoves()
        {
            for (int i = 0; i < 9; i++)
                GameMoves[i] = CellType.Free;
        }       
    }  
}
