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
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();

        }

        private void InitializeGrid()
        {
            tblPanelGrid.BackColor = Color.LavenderBlush;
            tblPanelGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
        }

        private void pctBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
