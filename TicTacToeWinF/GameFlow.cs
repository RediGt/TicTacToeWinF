using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeWinF
{
    class GameFlow
    {
        public GameFlow()
        {
        }
        
        public bool playerXTurn { get; set; } = true;
        public int playerTurnCount { get; set; } = 0;
        public CellType[] GameMoves { get; set; } = new CellType[9];
    
        public void InitGameMoves()
        {
            for (int i = 0; i < 9; i++)
                GameMoves[i] = CellType.Free;
            //GameMoves[4] = CellType.Cross;
            //GameMoves[0] = CellType.Nought;
        }

        public void CheckForWin()
        {
            if ((GameMoves[0] == GameMoves[1] && GameMoves[0] == GameMoves[2] && GameMoves[0] != CellType.Free) ||
                (GameMoves[3] == GameMoves[4] && GameMoves[3] == GameMoves[5] && GameMoves[3] != CellType.Free) ||
                (GameMoves[6] == GameMoves[7] && GameMoves[6] == GameMoves[8] && GameMoves[6] != CellType.Free) ||
                (GameMoves[0] == GameMoves[3] && GameMoves[0] == GameMoves[6] && GameMoves[0] != CellType.Free) ||
                (GameMoves[1] == GameMoves[4] && GameMoves[1] == GameMoves[7] && GameMoves[1] != CellType.Free) ||
                (GameMoves[2] == GameMoves[5] && GameMoves[2] == GameMoves[8] && GameMoves[2] != CellType.Free) ||
                (GameMoves[0] == GameMoves[4] && GameMoves[0] == GameMoves[8] && GameMoves[0] != CellType.Free) ||
                (GameMoves[2] == GameMoves[4] && GameMoves[2] == GameMoves[6] && GameMoves[2] != CellType.Free))
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            string winner;
            if (playerXTurn)
                winner = "X";
            else
                winner = "O";
            //WinnerCellsChangeColor();
            Form1.PlaySound("WinnerSound");
            //MessageBox.Show("Congrats, " + winner);
            //this.Hide();
            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            //this.Close();
            //RestartGame();
        }
    }  
}
