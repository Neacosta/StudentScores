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
    public partial class txtScore : Form
    {
        public txtScore()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Tag = Convert.ToDouble(txtScores.Text);
        }

        private void txtScore_Load(object sender, EventArgs e)
        {
            if (Text == "UpdateScore")
            {
                btnAdd.Text = "Update";
                txtScores.Text = Tag.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
