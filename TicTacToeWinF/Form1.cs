using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeWinF
{
    public partial class Form1 : Form
    {
        PlayData pd = new PlayData();
        
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeCells();
        }      

        private void InitializeGrid()
        {
            tblPanelGrid.BackColor = Color.LavenderBlush;
            tblPanelGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
        }

        private void InitializeCells()
        {
            string cellName;
            pd.InitGameMoves();
            for (int i = 0; i < 9; i++)
            {
                cellName = "pctBox" + (i + 1);
                if (pd.GameMoves[i] == CellType.Cross)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("x_frame_020");
                }
                if (pd.GameMoves[i] == CellType.Nought)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("o_frame_020");
                }
                if (pd.GameMoves[i] == CellType.Free)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = null;
                }
                tblPanelGrid.Controls[cellName].BackColor = Color.Transparent;
            }
        }

        private void pctBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            string cellNumber = picture.Name.Substring(6, 1);
            int cellNum = Convert.ToInt32(cellNumber);

            if (pd.GameMoves[cellNum - 1] == CellType.Free)
            {
                if (pd.playerXTurn)
                {
                    pd.GameMoves[cellNum - 1] = CellType.Cross;
                    picture.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("x_frame_020");
                    PlaySound("ClickSound");
                }
                else
                {
                    pd.GameMoves[cellNum - 1] = CellType.Nought;
                    picture.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("o_frame_020");
                    PlaySound("ClickSound2");
                }
                pd.playerTurnCount++;
                pd.playerXTurn = !pd.playerXTurn;

                CheckForWin();
                //Check_For_Draw();
                //xPlayerTurn = !xPlayerTurn;
            }
        }

        public void CheckForWin()
        {
            if (pd.GameMoves[0] == pd.GameMoves[1] && pd.GameMoves[0] == pd.GameMoves[2] && pd.GameMoves[0] != CellType.Free)
            {
                ChangeCellsColors(pctBox1, pctBox2, pctBox3, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[3] == pd.GameMoves[4] && pd.GameMoves[3] == pd.GameMoves[5] && pd.GameMoves[3] != CellType.Free)
            {
                ChangeCellsColors(pctBox4, pctBox5, pctBox6, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[6] == pd.GameMoves[7] && pd.GameMoves[6] == pd.GameMoves[8] && pd.GameMoves[6] != CellType.Free)
            {
                ChangeCellsColors(pctBox7, pctBox8, pctBox9, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[0] == pd.GameMoves[3] && pd.GameMoves[0] == pd.GameMoves[6] && pd.GameMoves[0] != CellType.Free)
            {
                ChangeCellsColors(pctBox1, pctBox4, pctBox7, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[1] == pd.GameMoves[4] && pd.GameMoves[1] == pd.GameMoves[7] && pd.GameMoves[1] != CellType.Free)
            {
                ChangeCellsColors(pctBox2, pctBox5, pctBox8, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[2] == pd.GameMoves[5] && pd.GameMoves[2] == pd.GameMoves[8] && pd.GameMoves[2] != CellType.Free)
            {
                ChangeCellsColors(pctBox3, pctBox6, pctBox8, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[0] == pd.GameMoves[4] && pd.GameMoves[0] == pd.GameMoves[8] && pd.GameMoves[0] != CellType.Free)
            {
                ChangeCellsColors(pctBox1, pctBox5, pctBox9, Color.DeepPink);
                GameOver();
            }
            if (pd.GameMoves[2] == pd.GameMoves[4] && pd.GameMoves[2] == pd.GameMoves[6] && pd.GameMoves[2] != CellType.Free)
            {
                ChangeCellsColors(pctBox3, pctBox5, pctBox7, Color.DeepPink);
                GameOver();
            }
        }

        private void GameOver()
        {
            string winner;
            if (pd.playerXTurn)
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

        private void ChangeCellsColors(PictureBox labelOne, PictureBox labelTwo, PictureBox labelThree, Color color)
        {
            labelOne.BackColor = color;
            labelTwo.BackColor = color;
            labelThree.BackColor = color;
        }

        static public void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
    }
}
