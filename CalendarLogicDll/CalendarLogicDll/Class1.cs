using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarLogicDll
{
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

    public static class NoteFileOperations
    {
        public static bool SaveNote(string path, Note note)
        {
            bool flag = false;
            if (note != null)
            {
                try
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    File.WriteAllText(path, string.Format("{0}\n>{1}\n<{2}|\n\n*", (object)note.NoteName, (object)note.Text, (object)note.CreationData.Date));
                    flag = true;
                }
                catch
                {
                }
            }
            return flag;
        }

        public static bool SaveNotes(string path, params Note[] notes)
        {
            bool flag = false;
            if (((IEnumerable<Note>)notes).Where<Note>((Func<Note, bool>)(x => x != null)).Count<Note>() == notes.Length)
            {
                try
                {
                    if (File.Exists(path))
                        File.Delete(path);
                    ((IEnumerable<Note>)notes).ToList<Note>().ForEach((Action<Note>)(x => File.AppendAllText(path, string.Format("{0}>{1}\n<{2}|\n\n*", (object)x.NoteName, (object)x.Text, (object)x.CreationData.Date))));
                    flag = true;
                }
                catch
                {
                }
            }
            return flag;
        }

        public static List<Note> ReadFromFile(string path)
        {
            List<Note> notesFromFile = new List<Note>();
            if (path != null && File.Exists(path))
                ((IEnumerable<string>)File.ReadAllText(path).Split('*')).ToList<string>().ForEach((Action<string>)(x =>
                {
                    if (x.Count<char>() <= 5)
                        return;
                    notesFromFile.Add(new Note(new string(x.TakeWhile<char>((Func<char, bool>)(y => y != '>')).ToArray<char>()), x.Substring(x.LastIndexOf('>') + 1, x.LastIndexOf('<') - x.LastIndexOf('>') - 1), DateTime.Parse(x.Substring(x.IndexOf('<') + 1, x.LastIndexOf('|') - x.LastIndexOf('<') - 1))));
                }));
            else
                notesFromFile = (List<Note>)null;
            return notesFromFile;
        }
    }
}
