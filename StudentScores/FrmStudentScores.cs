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
    public partial class FrmStudentScores : Form
    {
        public IList<Student> Students = new List<Student>();

        public FrmStudentScores()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
          
            var addForm = new FrmAddNewStudent();
            var button = addForm.ShowDialog();

            if (button == DialogResult.OK)
            {
                Students.Add((Student)addForm.Tag);
                LoadStudentsListBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Students.Count > 0)
            {
                var student = (Student)lstStudents.SelectedItem;


                var updateStudent = new FrmUpdateStudent();
                updateStudent.Tag = student;

                var button = updateStudent.ShowDialog();

                if (button == DialogResult.OK)
                {
                    Students.Insert(lstStudents.SelectedIndex, (Student)updateStudent.Tag);
                    Students.RemoveAt(lstStudents.SelectedIndex + 1);
                    LoadStudentsListBox();
                }
            }

        }
            

        private void FrmStudentScores_Load(object sender, EventArgs e)
        {
            Students = StudentDB.GetStudents();
   
            LoadStudentsListBox();
        }

        private void LoadStudentsListBox()
        {
            
            lstStudents.Items.Clear();

            foreach (var student in Students)
            {
                lstStudents.Items.Add(student);
            }
            StudentDB.SaveStudents(Students);

            if (lstStudents.Items.Count > 0)
            {
                lstStudents.SelectedIndex = -1;
            }
            else
            {
                ClearLabels();
            }
        }
        private void ClearLabels()
        {
            txtScoreCount.Text = string.Empty;
            txtScoreTotal.Text = string.Empty;
            txtAverage.Text = string.Empty;

        }

        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex != -1)
            {
                var student = (Student)lstStudents.SelectedItem;
                txtScoreCount.Text = student.ScoreCount.ToString();
                txtScoreTotal.Text = student.ScoreTotal.ToString();
                txtAverage.Text = student.ScoreAverage.ToString("n2");

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Students.Count > 0)
            {
                Students.RemoveAt(lstStudents.SelectedIndex);
                LoadStudentsListBox();
            }
        }
    }
}
