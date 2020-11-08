using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Survey
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            this.Hide();
            Result result = new Result(); //this is the change, code for redirect  
            result.ShowDialog();
        }

        private void btnSurvey_Click(object sender, EventArgs e)
        {
            this.Hide();
            Survey survey = new Survey(); //this is the change, code for redirect to fill survey form 
            survey.ShowDialog();
        }
    }
}
