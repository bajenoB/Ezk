using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CalendarGui
{
    public partial class Settings : Form
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));

        public Settings()
        {
            InitializeComponent();
            this.FormClosing += (sender, args) =>
            {
                this.ci = new CultureInfo((sender as ComboBox).SelectedIndex.ToString());
                Form1 form = new Form1(ci);

            };
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ci = new CultureInfo((sender as ComboBox).SelectedIndex.ToString());


        }
    }
}
