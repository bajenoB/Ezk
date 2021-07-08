// Decompiled with JetBrains decompiler
// Type: Logic.NoteFileOperations
// Assembly: Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3FA60C7B-585E-4C7F-A7D7-CDBEF7B6199B
// Assembly location: d:\Users\Danil\Downloads\Logic.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalendarLogicDll
{
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
