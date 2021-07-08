// Decompiled with JetBrains decompiler
// Type: Logic.Note
// Assembly: Logic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3FA60C7B-585E-4C7F-A7D7-CDBEF7B6199B
// Assembly location: d:\Users\Danil\Downloads\Logic.dll

using System;

namespace CalendarLogic
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
}
