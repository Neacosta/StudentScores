using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class FrmAddNewStudent : Form
    {
        private Student student = new Student(string.Empty);
        public FrmAddNewStudent()
        {
            InitializeComponent();
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            var score = Convert.ToDouble(txtScore.Text);
            student.Scores.Add(score);

            DisplayScores();
            txtScore.Focus();


        }
        private void DisplayScores()
        {
            txtScores.Text = string.Empty;

            foreach(double score in student.Scores)
            {
                txtScores.Text += score.ToString() + "";
            }

        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            student.Scores.Clear();
            DisplayScores();
            txtScore.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            student.Name = txtName.Text;
            DialogResult = DialogResult.OK;
            Tag = student;
        }
    }
   
}
