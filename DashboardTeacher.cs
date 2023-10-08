using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab_Hub.Teacher_Dashboard;

namespace Lab_Hub
{
    public partial class DashboardTeacher : Form
    {
        private Form activeForm;

        public DashboardTeacher()
        {
            InitializeComponent();
            subPanelLabReport.Visible = false;
        }

        private void HideSubmenu()
        {
            if (subPanelLabReport.Visible == true) subPanelLabReport.Visible = false;
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Size = panelChildForm.Size;
            //childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                HideSubmenu();
                subMenu.Visible = true;
            }
            else subMenu.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            openChildForm(new Grades());
            HideSubmenu();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            openChildForm(new Student());
            HideSubmenu();
        }

        private void LabAssistantbtn_Click(object sender, EventArgs e)
        {
            openChildForm(new LabAssisstant());
            HideSubmenu();
        }

        private void btnLabReport_Click(object sender, EventArgs e)
        {
            ShowSubmenu(subPanelLabReport);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            openChildForm(new LabReports());
            HideSubmenu();
        }
    }
}
