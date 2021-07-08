using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarGui
{
    public class ManagerNotes
    {
        public List<NoteL> notes;
        public ManagerNotes()
        {
            notes = new List<NoteL>();
        }
        public ManagerNotes(List<NoteL> notes)
        {
            this.notes = notes;
        }

        public void AddNote(NoteL note)
        {
            this.notes.Add(note);
        }
        public void RemoveNote(NoteL note)
        {
            this.notes.Remove(note);
        }
        public List<NoteL> DisplayAllNotes(DateTime datetime)
        {
            return notes.Where(x => x.date == datetime).ToList();
        }
        public List<NoteL> DisplaySearchedNotes(DateTime datetime, string key)
        {
            return notes.Where(x => x.date == datetime).ToList().Where(x => x.Title.Contains(key)).ToList();
        }
    }
}
