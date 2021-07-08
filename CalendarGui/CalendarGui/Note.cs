using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarGui
{
    public class Note
    {
        public Panel panel;
        public TextBox Title;
        public TextBox MainText;
        public Label Date;

        public Note()
        {
            this.panel = new Panel()
            {
                Size = new Size(120, 160),
                BackColor = Color.FromArgb(255, 230, 230, 230),
                Name = "Panel",
                Location = new Point(0, 0)
            };
            this.Title = new TextBox()
            {
                Text = "Заголовок",
                Name = "Title",
                Location = new Point(10, 10),
                Size = new Size(100, 40),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.FromArgb(255, 230, 230, 230)
            };
            this.MainText = new TextBox()
            {
                Text = "Основной текст",
                Name = "MainText",
                Location = new Point(10, 50),
                Size = new Size(100, 80),
                Multiline = true,
                ReadOnly = false,
                ScrollBars = ScrollBars.Vertical,
                BackColor = Color.FromArgb(255, 230, 230, 230)
            };
            this.Date = new Label()
            {
                Text = "Дата",
                Name = "Date",
                Location = new Point(15, 136),
                Size = new Size(100, 30)
            };

            panel.Controls.Add(Date);
            panel.Controls.Add(Title);
            panel.Controls.Add(MainText);

            panel.Region = new Region(RoundedRect(new Rectangle(0, 0, panel.Width, panel.Height), 30));
        }
        public Note(int Name) : this()
        {
            panel.Name = Name.ToString();
            panel.Location = new Point(this.panel.Location.X, this.panel.Location.Y + Name * (panel.Height + 20));
        }

        public Note(int Name, string Title, string MainText, DateTime date) : this(Name)
        {
            this.Title.Text = Title;
            this.MainText.Text = MainText;
            this.Date.Text = date.ToLongDateString();
        }

        public void AddToControls(Control.ControlCollection Controls)
        {
            Controls.Add(panel);
        }

        public void RemoveFromControls(Control.ControlCollection Controls)
        {
            Controls.Remove(this.panel);
            Controls.Remove(this.Title);
            Controls.Remove(this.MainText);
            Controls.Remove(this.Date);
        }

        public GraphicsPath RoundedRect(Rectangle baseRect, int radius)
        {
            var diameter = radius * 2;
            var sz = new Size(diameter, diameter);
            var arc = new Rectangle(baseRect.Location, sz);
            var path = new GraphicsPath();

            path.AddArc(arc, 180, 90);

            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
