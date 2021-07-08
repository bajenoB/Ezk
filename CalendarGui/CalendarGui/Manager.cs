using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarGui
{
    public class Manager
    {
        public Panel panel;
        public List<Note> notes;
        public VScrollBar vScrollBar;

        public Manager()
        {
            notes = new List<Note>();

            notes.Add(new Note(0));
            notes.Add(new Note(1));
            notes.Add(new Note(2));

            panel = new Panel()
            {
                Size = new Size(150, 180),
                //BackColor = Color.FromArgb(255, 140, 140, 140),
                Location = new Point(214, 18),
            };
            panel.Size = new Size(150, 180);

            vScrollBar = new VScrollBar()
            {
                Anchor = AnchorStyles.Bottom,
                Size = new Size(20, 180),
                Location = new Point(344, 18),
                Minimum = 0,
                SmallChange = 20,
                LargeChange = 100,
                Maximum = notes.Count * 180
            };

            panel.VerticalScroll.Maximum = notes.Count * 180;

            vScrollBar.Scroll += (sender, e) => { panel.VerticalScroll.Value = vScrollBar.Value; };
        }
        public void AddNotes(List<NoteL> notes)
        {
            for (int i = 0; i < notes.Count; i++)
            {
                this.notes.Add(new Note(i, notes[i].Title, notes[i].MainText, notes[i].date));
            }
            this.notes.ForEach(x => panel.Controls.Add(x.panel));
            this.vScrollBar.Maximum = notes.Count * 180;
            this.panel.VerticalScroll.Maximum = notes.Count * 180;
        }
        public void InitToControls(Control.ControlCollection Controls)
        {
            Controls.Add(vScrollBar);
        }
        public void AddToControls(Control.ControlCollection Controls)
        {
            Controls.Add(panel);
        }
        public void RemoveFromControls(Control.ControlCollection Controls)
        {
            notes.ForEach(x => panel.Controls.Remove(x.panel));
            notes.Clear();
        }
    }
}
