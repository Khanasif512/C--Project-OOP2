using Lab_Hub.Student_Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Hub
{
    public partial class DashboardStudent : Form
    {
        private Form activeForm;

        public DashboardStudent()
        {
            InitializeComponent();
            CustomHideSubmenu();
        }

        private void CustomHideSubmenu()
        {
        /*    teacherSubmenu.Visible = false;
            studentSubmenu.Visible = false;
            labAssistantSubmenu.Visible = false;
            sectionSubmenu.Visible = false;*/
        }

        private void HideSubmenu()
        {
        /*    if (teacherSubmenu.Visible == true) teacherSubmenu.Visible = false;
            if (studentSubmenu.Visible == true) studentSubmenu.Visible = false;
            if (labAssistantSubmenu.Visible == true) labAssistantSubmenu.Visible = false;
            if (sectionSubmenu.Visible == true) sectionSubmenu.Visible = false;*/
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            openChildForm(new Grades());
        }
    }
}
