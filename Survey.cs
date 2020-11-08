using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey
{
    public partial class Survey : Form
    {
        public Survey()
        {
            InitializeComponent();

        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                e.Cancel = true;
                txtSurname.Focus();
                errorProvider1.SetError(txtSurname, "Surname should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSurname, "");
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider1.SetError(txtFirstName, "First names should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFirstName, "");
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                e.Cancel = true;
                txtContact.Focus();
                errorProvider1.SetError(txtContact, "Contact should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtContact, "");
            }
        }

        private void txtAge_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                e.Cancel = true;
                txtAge.Focus();
                errorProvider1.SetError(txtAge, "Age should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAge, "");
            }
        }

        String food;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"data source=(local);initial catalog=survey;persist security info=True;user id=sa;password=P@SSW0RD;pooling=False;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand("InsertUser", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
            cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@age", txtAge.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            SqlCommand cmd1 = new SqlCommand("InsertAnswer", con);

            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@contact", txtContact.Text);
            cmd1.Parameters.AddWithValue("@questionId", label23.Text);
            //cmd1.Parameters.AddWithValue("@answer", checkBox1.Text, checkBox2.Text, checkBox3.Text, checkBox4.Text, checkBox5.Text, checkBox6.Text);

            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();

            if (radioButton17.Checked==true)
            {

            }
        }

        private void Survey_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"data source=(local);initial catalog=survey;persist security info=True;user id=sa;password=P@SSW0RD;pooling=False;MultipleActiveResultSets=True");
            con.Open();
            SqlCommand com = new SqlCommand("select questionId,question from tblQuestion where questionId = 1", con);
            SqlDataReader reader = com.ExecuteReader();

            reader.Read();
            label23.Text = reader["questionId"].ToString();
            label7.Text = reader["question"].ToString();
            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            food = "Pizza";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            food = "Pasta";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            food = "Pap and Wors";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            food = "Chicken stir fry";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            food = "Beef stir fry";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            food = "Other";
        }
    }
}
