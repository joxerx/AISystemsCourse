using System;
using System.Windows.Forms;

namespace rolling
{
    public partial class Form1 : Form
    {
        Output manager = new Output();
        public Form1()
        {
            InitializeComponent();
        }

        private void Bt_check_Click(object sender, EventArgs e)
        {
            var text1 = Convert.ToDouble(tCourse.Text);
            var text2 = Convert.ToDouble(tPsi.Text);
            var text3 = Convert.ToDouble(tTeta.Text);
            manager.Input(text1, text2, text3);
            outputBox.Text = manager.Predict();
            diag.Image = manager.Draw();
        }
    }
}
