using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            //jenach dem, welcher Spieler dran ist, wird das passende Symbol gesetzt
            ((PictureBox)sender).Image = Spieler.Image;
            ((PictureBox)sender).Enabled = false;
            if ((string)Spieler.Image.Tag == "Kreuz")
            {
                Spieler.Image = Resource1.OOO;
                Spieler.Image.Tag = "OOO";
                ((PictureBox)sender).Image.Tag = "Kreuz";
            }
            else
            {
                Spieler.Image = Resource1.Kreuz;
                Spieler.Image.Tag = "Kreuz";
                ((PictureBox)sender).Image.Tag = "OOO";

            }
            //hat einer gewonnen?
            TableLayoutPanelCellPosition p = tableLayoutPanel1.GetPositionFromControl((Control)sender);
            int[,] vek = { { 1, 2 }, { -1, 1 }, { -2, -1 } };
            bool win = false;
            PictureBox s = (PictureBox)sender;
            //horizontal prüf
            win = win ||
                ((string)s.Image.Tag
                == (string)((PictureBox)tableLayoutPanel1.GetControlFromPosition(p.Column + vek[p.Column, 0], p.Row)).Image.Tag
                &&
                (string)s.Image.Tag
                == (string)((PictureBox)tableLayoutPanel1.GetControlFromPosition(p.Column + vek[p.Column, 1], p.Row)).Image.Tag
                );
            //vertikal prüf
            win = win ||
                ((string)s.Image.Tag
                == (string)((PictureBox)tableLayoutPanel1.GetControlFromPosition(p.Column, p.Row + vek[p.Row, 0])).Image.Tag
                &&
                (string)s.Image.Tag
                == (string)((PictureBox)tableLayoutPanel1.GetControlFromPosition(p.Column, p.Row + vek[p.Row, 1])).Image.Tag
                );
            //backslash
            win = win || ((p.Column == p.Row) &&
               ((string)s.Image.Tag
               == (string)((PictureBox)tableLayoutPanel1.GetControlFromPosition(p.Column + vek[p.Column, 0], p.Row + vek[p.Row, 0])).Image.Tag
               &&
               (string)s.Image.Tag
               == (string)((PictureBox)tableLayoutPanel1.GetControlFromPosition(p.Column + vek[p.Column, 1], p.Row + vek[p.Row, 1])).Image.Tag
               ));

            if (win)
            {
                MessageBox.Show("Einer hat gewonnen");
                return;
            }
            //unentschieden
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl.Enabled)
                {
                    return;
                }
            }
            MessageBox.Show("Game over! Unentschieden!");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Spieler.Image.Tag = "OOO";
        }
    }
}
