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
            pd.InitGameMoves();
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
            for (int i = 0; i < 9; i++)
            {
                cellName = "pctBox" + (i + 1);
                if (pd.GameMoves[i] == CellType.Cross)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("x_frame");
                }
                if (pd.GameMoves[i] == CellType.Nought)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("o_frame");
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
                if (pd.PlayerXTurn)
                {
                    pd.GameMoves[cellNum - 1] = CellType.Cross;
                    picture.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("x_frame");
                    PlaySound("ClickSound");
                }
                else
                {
                    pd.GameMoves[cellNum - 1] = CellType.Nought;
                    picture.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("o_frame");
                    PlaySound("ClickSound2");
                }
                pd.PlayerTurnCount++;
                pd.PlayerXTurn = !pd.PlayerXTurn;

                CheckForWin();
                if (!pd.WinResult)
                    CheckForDraw();
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
                ChangeCellsColors(pctBox3, pctBox6, pctBox9, Color.DeepPink);
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

        private void CheckForDraw()
        {
            if (pd.PlayerTurnCount == 9)
            {
                MessageBox.Show("No Winner. DRAW");
            }
        }

        private void GameOver()
        {
            string winner;
            if (pd.PlayerXTurn)
                winner = "O";
            else
                winner = "X";
            pd.WinResult = true;
            PlaySound("WinnerSound");
            DisableButtonClick();
            MessageBox.Show("Congrats, " + winner);
        }

        private void NewGame()
        {
            pd.InitGameMoves();
            InitializeCells();
            EnableButtonClick();
            pd.PlayerTurnCount = 0;
            pd.PlayerXTurn = true;
            pd.WinResult = false;
        }

        private void ChangeCellsColors(PictureBox labelOne, PictureBox labelTwo, PictureBox labelThree, Color color)
        {
            labelOne.BackColor = color;
            labelTwo.BackColor = color;
            labelThree.BackColor = color;
        }

        public void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }

        public void DisableButtonClick()
        {
            string cellName;
            PictureBox picture;
            for (int i = 0; i < 9; i++)
            {
                cellName = "pctBox" + (i + 1);
                picture = (PictureBox)tblPanelGrid.Controls[cellName];
                picture.Click -= this.pctBox_Click;
            }           
        }

        public void EnableButtonClick()
        {
            string cellName;
            PictureBox picture;
            for (int i = 0; i < 9; i++)
            {
                cellName = "pctBox" + (i + 1);
                picture = (PictureBox)tblPanelGrid.Controls[cellName];
                picture.Click += this.pctBox_Click;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileIO.SaveToFile(pd);
            MessageBox.Show("Game saved");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            pd = FileIO.LoadFromFile();
            if (pd == null)
            {
                MessageBox.Show("Error loading the game. A new game is created.");
                pd = new PlayData();
                NewGame();
                return;
            }
            InitializeCells();
            EnableButtonClick();
        }
    }
}
