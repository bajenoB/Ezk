using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarGui
{
    public partial class Form1 : Form
    {
        //DateTime time = DateTime.Now;
        
        public Form1()
        {
            CustomControl note = new CustomControl("text", "123", 400, 100, DateTime.Now);
            InitializeComponent();
            //Controls.Add(note);
            panel1.Controls.Add(note);


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
