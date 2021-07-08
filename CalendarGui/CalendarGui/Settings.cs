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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CultureInfo ci = new CultureInfo((sender as ComboBox).SelectedItem.ToString());
            foreach (Control c in this.Controls)
                resources.ApplyResources(c, c.Name, ci);
            Form1 form = new Form1(ci);
        }
    }
}
