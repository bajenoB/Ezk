using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarGui
{
    public partial class Form1 : Form
    {
        //DateTime time = DateTime.Now;
        List<CustomControl> notes = new List<CustomControl>() { };
        string path1;
        string filename1;
        int x = 0;
        int y = 0;

        public Form1()
        {
           
            CustomControl note = new CustomControl("text", "123", 200, 100, DateTime.Now);
            InitializeComponent();
            //Controls.Add(note);
            //Controls.Add(note);
            panel1.Controls.Add(note);


        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateNote form = new CreateNote();
            form.ShowDialog();
           
        }

       
    }
}
