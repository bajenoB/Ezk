using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CalendarGui
{
    class CustomControl : Control
    {
        private Label titleLabel ;
        private Label textLabel ;
        private Label dateLabel ;
        public CustomControl()
        {
            titleLabel = new Label();
            textLabel = new Label();
            dateLabel = new Label();
    }

        public CustomControl(string text, string name,int x,int y, DateTime date):this()
        {
            //Name = "rec";
            this.BackColor = Color.Gray;
            this.Location = new Point(10, 20);
            this.Size = new Size(x, y);
            //263; 244
            this.Visible = true;
            

            
            textLabel.Text = text;
            textLabel.ForeColor = Color.White;
           // textLabel.Font = new Font("Times New Roman", FontStyle.Regular,GraphicsUnit.Point);
            textLabel.Size = new Size(x, y/4);
            textLabel.Location = new Point(0, 50);
            textLabel.Visible = true;

            titleLabel.Text = name;
            titleLabel.ForeColor = Color.White;
            titleLabel.Size = new Size(x, y/6);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Visible = true;


            dateLabel.Text = date.Date.ToString();
            dateLabel.ForeColor = Color.White;
            dateLabel.Size = new Size(x, y/6);
            dateLabel.Location = new Point(0, 200);
            dateLabel.Visible = true;

            this.Controls.Add(titleLabel);
            this.Controls.Add(textLabel);
            this.Controls.Add(dateLabel);

        }
    }
}
