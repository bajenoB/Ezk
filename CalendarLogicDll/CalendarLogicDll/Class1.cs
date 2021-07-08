using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLogicDll
{
    

    public class Note
    {
        public string NoteName { get; private set; }

        public string Text { get; private set; }

        public DateTime CreationData { get; private set; }

        public Note()
        {
            this.NoteName = string.Empty;
            this.Text = string.Empty;
            this.CreationData = new DateTime();
        }

        public Note(string noteName, string text, DateTime creationData)
        {
            this.Text = text;
            this.NoteName = noteName;
            this.CreationData = creationData;
        }
    }

    

    public static class Manager
    {
        public static List<Note> notes { get; private set; } = new List<Note>();

        public static void CreateNote(string noteName, string text, DateTime creationData) => Manager.notes.Add(new Note(noteName, text, creationData));

        public static void DeleteNote(string noteName)
        {
            if (Manager.notes.FindIndex((Predicate<Note>)(item => item.NoteName == noteName)) == -1)
                return;
            Manager.notes.RemoveAt(Manager.notes.FindIndex((Predicate<Note>)(item => item.NoteName == noteName)));
        }

        public static void SaveAllNotes(string path) => NoteFileOperations.SaveNotes(path, Manager.notes.ToArray());

        public static void SaveNote(string noteName, string path) => NoteFileOperations.SaveNote(path, Manager.notes.Find((Predicate<Note>)(item => item.NoteName == noteName)));

        public static void ReadNotesFromFile(string path) => Manager.notes = NoteFileOperations.ReadFromFile(path);
    }
}
