﻿using System;
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
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse);
        public Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel3.Height = btnDashboard.Height;
            panel3.Top = btnDashboard.Top;
            panel3.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Dashboard";
            this.PnlFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
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

            lblTitle.Text = "Dashboard";
            this.PnlFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            panel3.Height = btnPackages.Height;
            panel3.Top = btnPackages.Top;
            panel3.Left = btnPackages.Left;
            btnPackages.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Packages";
            this.PnlFormLoader.Controls.Clear();
            frmPackages FrmPackages_Vrb = new frmPackages() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmPackages_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmPackages_Vrb);
            FrmPackages_Vrb.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            panel3.Height = btnProduct.Height;
            panel3.Top = btnProduct.Top;
            panel3.Left = btnProduct.Left;
            btnProduct.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Products";
            this.PnlFormLoader.Controls.Clear();
            frmProducts FrmProducts_Vrb = new frmProducts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmProducts_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmProducts_Vrb);
            FrmProducts_Vrb.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            panel3.Height = btnSupplier.Height;
            panel3.Top = btnSupplier.Top;
            panel3.Left = btnSupplier.Left;
            btnSupplier.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Suppliers";
            this.PnlFormLoader.Controls.Clear();
            frmSuppliers FrmSuppliers_Vrb = new frmSuppliers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmSuppliers_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmSuppliers_Vrb);
            FrmSuppliers_Vrb.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            panel3.Height = btnAdmin.Height;
            panel3.Top = btnAdmin.Top;
            panel3.Left = btnAdmin.Left;
            btnAdmin.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Admin";
            this.PnlFormLoader.Controls.Clear();
            frmAdmin FrmAdmin_Vrb = new frmAdmin() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmAdmin_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmAdmin_Vrb);
            FrmAdmin_Vrb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            panel3.Height = btnSettings.Height;
            panel3.Top = btnSettings.Top;
            panel3.Left = btnSettings.Left;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Settings";
            this.PnlFormLoader.Controls.Clear();
            frmSettings FrmSettings_Vrb = new frmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmSettings_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(FrmSettings_Vrb);
            FrmSettings_Vrb.Show();
        }
    }
}
