using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.

namespace CalendarGui
{
    public partial class CreateNote : Form
    {
        public CreateNote()
        {
            InitializeComponent();
            textBox1.GotFocus += (sender, args) => { if (textBox1.Text == "Заголовок") textBox1.Text = string.Empty; };
            textBox1.LostFocus += (sender, args) => { if (textBox1.Text == string.Empty) textBox1.Text = "Заголовок"; };
            textBox2.GotFocus += (sender, args) => { if (textBox2.Text == "Основной текст") textBox2.Text = string.Empty; };
            textBox2.LostFocus += (sender, args) => { if (textBox2.Text == string.Empty) textBox2.Text = "Основной текст"; };

            this.FormClosing += (sender, args) =>
            {
                this.Title = textBox1.Text;
                this.MainText = textBox2.Text;
                this.dateTime = dateTimePicker1.Value.Date;
            };
        }

        
    }
}
