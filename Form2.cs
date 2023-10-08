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
    public partial class Form2 : Form
    {
        private Form activeForm;

        public Form2()
        {
            InitializeComponent();
            CustomHideSubmenu();
        }

        private void CustomHideSubmenu()
        {
            teacherSubmenu.Visible = false;
            studentSubmenu.Visible = false;
            labAssistantSubmenu.Visible = false;
            sectionSubmenu.Visible = false;
        }

        private void HideSubmenu()
        {
            if(teacherSubmenu.Visible == true) teacherSubmenu.Visible = false;
            if(studentSubmenu.Visible == true) studentSubmenu.Visible = false;
            if(labAssistantSubmenu.Visible == true) labAssistantSubmenu.Visible = false;
            if(sectionSubmenu.Visible == true) sectionSubmenu.Visible = false;
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

        //Teacher Manu------------------------------------------------------------------
        private void teacherbtn_Click(object sender, EventArgs e)
        {
            ShowSubmenu(teacherSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new teachers_all());
            HideSubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new teachers_add());
            HideSubmenu();
        }

        //Student Manu----------------------------------------------------------------------
        private void student_Click(object sender, EventArgs e)
        {
            ShowSubmenu(studentSubmenu);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new students_all());
            HideSubmenu();
        }
        
        private void button5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new students_add());
            HideSubmenu();
        }

        //lab Assistant manu----------------------------------------------------------------
        private void LabAssistantbtn_Click(object sender, EventArgs e)
        {
            ShowSubmenu(labAssistantSubmenu);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new labassistants_all());
            HideSubmenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new labassistants_update());
            HideSubmenu();
        }

        //Section manu--------------------------------------------------------------------------------
        private void Sectionbtn_Click(object sender, EventArgs e)
        {
            ShowSubmenu(sectionSubmenu);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new sections_all());
            HideSubmenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new sections_add());
            HideSubmenu();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sectionSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labAssistantSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void studentSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void teacherSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Logo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void roundPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void roundPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
