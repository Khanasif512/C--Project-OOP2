using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Lab_Hub
{
    public partial class Form1 : Form
    {
        //server connection
        //string LH = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string id;
        SqlConnection DBconnect = new SqlConnection(Config.LH);

        public Form1()
        {
            InitializeComponent();
        }

        //Check All Boxes If null or Empty
        public static bool check(params string[] s)
        {
            foreach (string i in s)
            {
                if (i == null || i == String.Empty)
                    return true;
            }
            return false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Blue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.DarkViolet;
        }

        private void userid_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userid.Text) == true)
            {
                userid.Focus();
                errorProvider1.SetError(this.userid, "Input user id");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text) == true)
            {
                password.Focus();
                errorProvider2.SetError(this.password, "Input user password");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = false;
            pictureBox4.BringToFront();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
            pictureBox5.BringToFront();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            id = userid.Text;
            string pass = password.Text;

            if(check(id,pass))
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DBconnect.Open();
                SqlCommand cmd0 = new SqlCommand("Select * from Teacher where ID='" + id + "'", DBconnect);
                SqlDataReader flag0 = cmd0.ExecuteReader();

                if (flag0.HasRows)
                {
                    DBconnect.Close();
                    new DashboardTeacher().Show();
                    this.Hide();
                }
                else
                {
                    //cmd0.Dispose();
                    flag0.Close();
                    SqlCommand cmd1 = new SqlCommand("Select * from Student where ID ='" + id + "';", DBconnect);
                    SqlDataReader flag1 = cmd1.ExecuteReader();

                    if (flag1.HasRows)
                    {
                        DBconnect.Close();
                        new DashboardStudent().Show();
                        this.Hide();
                    }
                    else
                    {
                        //cmd1.Dispose();
                        flag1.Close();
                        SqlCommand cmd2 = new SqlCommand("Select * from LabAssistant where ID ='" + id + "';", DBconnect);
                        SqlDataReader flag2 = cmd2.ExecuteReader();

                        if (flag2.HasRows)
                        {
                            DBconnect.Close();
                            new DashboardLabAssistant().Show();
                            this.Hide();
                        }
                        else
                        {
                            if (id == "admin" && pass == "admin")
                            {
                                DBconnect.Close();
                                this.Hide();
                                new Form2().Show();
                            }
                            else
                            {
                                DBconnect.Close();
                                MessageBox.Show("ID not found!");
                            }
                        }
                    }
                }
            }
            catch (Exception exc) { MessageBox.Show(exc.ToString()); }

        /*    if (userid.Text!="" && password.Text != "")
            {
                /*SqlConnection con = new SqlConnection(LH);
                string query = "select * from user_table where userid = @user and pass = @pass"; 
                SqlCommand sc = new SqlCommand(query, con);
                sc.Parameters.AddWithValue("@user", userid.Text);
                sc.Parameters.AddWithValue("@pass", password.Text);

                con.Open();
                SqlDataReader dr = sc.ExecuteReader();
                if (dr.HasRows == true)
                {*/
         //           this.Hide();
         //           Form2 f2 = new Form2();
         //           f2.Show();
               /* }
                else
                {
                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close(); */  
        /*    }
            else
            {
                MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        */
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }
    }
}
