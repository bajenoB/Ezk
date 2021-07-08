using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarGui
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {

            Manager manager= new Manager();
            ManagerNotes managerNotes = new ManagerNotes();
            InitializeComponent();
            monthCalendar1.DateSelected += (sender, args) =>
            {
                manager.RemoveFromControls(Controls);
                manager.AddNotes(managerNotes.DisplayAllNotes(monthCalendar1.SelectionStart));
                manager.AddToControls(Controls);
            };

            manager = new Manager();
            manager.InitToControls(Controls);
            managerNotes = new ManagerNotes();

            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 7)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 6)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 6)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 9)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 10)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 9)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 7)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 6)));
            managerNotes.AddNote(new NoteL("Заголовок1", "Текст1", new DateTime(2021, 7, 5)));

            manager.AddToControls(Controls);
            manager.RemoveFromControls(Controls);

            manager.RemoveFromControls(Controls);
            manager.AddNotes(managerNotes.DisplaySearchedNotes(monthCalendar1.SelectionStart, toolStripTextBox1.Text));
            manager.AddToControls(Controls);


        }

        

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CreateNote form = new CreateNote();
            form.ShowDialog();
           
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
        }
    }
}
