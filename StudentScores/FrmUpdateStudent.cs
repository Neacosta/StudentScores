using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentScores
{
    public partial class FrmUpdateStudent : Form
    {
        private Student student = new Student("");
        public FrmUpdateStudent()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateForm = new txtScore();
            updateForm.Text = "Update Score";
            updateForm.Tag = lstStudentScores.SelectedItem;

            var button = updateForm.ShowDialog();
            if (button == DialogResult.OK)
            {
                var score = (double)updateForm.Tag;
                student.Scores.Insert(lstStudentScores.SelectedIndex, score);
                student.Scores.RemoveAt(lstStudentScores.SelectedIndex + 1);
                DisplayScores();
            }
        }
        private void DisplayScores()
        {
            lstStudentScores.Items.Clear();

            if (student.Scores.Count > 0)
            {
                foreach (double score in student.Scores)
                {
                    lstStudentScores.Items.Add(score);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new txtScore();
            addForm.Text = "Add Score";

            var button = addForm.ShowDialog();

            if(button == DialogResult.OK)
            {
                var score = (double)addForm.Tag;
                student.Scores.Add(score);
                DisplayScores();
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstStudentScores.SelectedIndex > 1)
            {
                student.Scores.RemoveAt(lstStudentScores.SelectedIndex);
                DisplayScores();
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            student.Scores.Clear();
            DisplayScores();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Tag = student;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUpdateStudent_Load(object sender, EventArgs e)
        {
            var currentStudent = (Student)Tag;

            student = currentStudent.Clone();
            txtName.Text = student.Name;
            DisplayScores();

            if (student.Scores.Count > 1)
            {
                 lstStudentScores.SelectedIndex = 0;
            }
        }
    }
}
