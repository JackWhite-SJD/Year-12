using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trial_run_b4_courseworki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.BackColor = ColorTranslator.FromOle((redScrollBar.Value + (greenscrollbar.Value * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2) + (blue.Value * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2)));
        }

        private void green_Scroll(object sender, ScrollEventArgs e)
        {
            this.BackColor = ColorTranslator.FromOle((redScrollBar.Value + (greenscrollbar.Value * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2) + (blue.Value * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2)));

        }

        private void blue_Scroll(object sender, ScrollEventArgs e)
        {
            this.BackColor = ColorTranslator.FromOle((redScrollBar.Value + (greenscrollbar.Value * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2) + (blue.Value * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2)));

        }
    }
}
