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
        GameFlow gf = new GameFlow();
        
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
            gf.InitGameMoves();
            for (int i = 0; i < 9; i++)
            {
                cellName = "pctBox" + (i + 1);
                if (gf.GameMoves[i] == CellType.Cross)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("x_frame_020");
                }
                if (gf.GameMoves[i] == CellType.Nought)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("o_frame_020");
                }
                if (gf.GameMoves[i] == CellType.Free)
                {
                    tblPanelGrid.Controls[cellName].BackgroundImage = null;
                }
            }
        }

        private void pctBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
            string cellNumber = picture.Name.Substring(6, 1);
            int cellNum = Convert.ToInt32(cellNumber);

            if (gf.GameMoves[cellNum - 1] == CellType.Free)
            {
                if (gf.playerXTurn)
                {
                    gf.GameMoves[cellNum - 1] = CellType.Cross;
                    picture.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("x_frame_020");
                    PlaySound("ClickSound");
                }
                else
                {
                    gf.GameMoves[cellNum - 1] = CellType.Nought;
                    picture.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("o_frame_020");
                    PlaySound("ClickSound2");
                }
                gf.playerTurnCount++;
                gf.playerXTurn = !gf.playerXTurn;

                gf.CheckForWin();
                //Check_For_Draw();
                //xPlayerTurn = !xPlayerTurn;
            }
        }

        static public void PlaySound(string soundName)
        {
            System.IO.Stream str = (System.IO.Stream)Properties.Resources.ResourceManager.GetObject(soundName);
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
        }
    }
}
