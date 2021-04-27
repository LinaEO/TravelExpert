using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TravelExpert
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse);
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = btnDashboard.Height;
            panel3.Top = btnDashboard.Top;
            panel3.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPackages_Leave(object sender, EventArgs e)
        {
            btnPackages.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnProduct_Leave(object sender, EventArgs e)
        {
            btnProduct.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSupplier_Leave(object sender, EventArgs e)
        {
            btnSupplier.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAdmin_Leave(object sender, EventArgs e)
        {
            btnAdmin.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panel3.Height = btnDashboard.Height;
            panel3.Top = btnDashboard.Top;
            panel3.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
                
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            panel3.Height = btnPackages.Height;
            panel3.Top = btnPackages.Top;
            panel3.Left = btnPackages.Left;
            btnPackages.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panel3.Height = btnProduct.Height;
            panel3.Top = btnProduct.Top;
            panel3.Left = btnProduct.Left;
            btnProduct.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            panel3.Height = btnSupplier.Height;
            panel3.Top = btnSupplier.Top;
            panel3.Left = btnSupplier.Left;
            btnSupplier.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            panel3.Height = btnAdmin.Height;
            panel3.Top = btnAdmin.Top;
            panel3.Left = btnAdmin.Left;
            btnAdmin.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
