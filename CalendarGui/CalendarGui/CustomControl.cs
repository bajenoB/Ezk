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
        private Label TitleLabel;
        private Label TextLabel;
        private Label TimeLabel;
        public CustomControl()
        {
            TitleLabel = new Label();
            TextLabel = new Label();
            TimeLabel = new Label();
        }

        public CustomControl(string text, string name, int posX, int posY, DateTime time) : this()
        {
            this.BackColor = Color.LightGray;
            this.Location = new Point(50, 0);
            this.Size = new Size(150, 100);
            this.Visible = true;

            TitleLabel.Text = name;
            TitleLabel.Font = new Font("Times New Roman", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TitleLabel.Size = new Size(this.Width, posY + TitleLabel.Height);
            TitleLabel.Location = new Point(posX, posY);
            TitleLabel.Visible = true;

            TextLabel.Text = text;
            TextLabel.Font = new Font("Times New Roman", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TextLabel.Size = new Size(this.Width, 20);
            TextLabel.Location = new Point(posX, posY + TitleLabel.Height * 2);
            TextLabel.Visible = true;

            TimeLabel.Text = time.Date.ToString();
            TimeLabel.Font = new Font("Times New Roman", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            TimeLabel.Size = new Size(this.Width, posY + TitleLabel.Height * 3);
            TimeLabel.Location = new Point(posX, posY);
            TimeLabel.Visible = true;

            this.Controls.Add(TitleLabel);
            this.Controls.Add(TextLabel);
            this.Controls.Add(TimeLabel);
        }
    }
}
