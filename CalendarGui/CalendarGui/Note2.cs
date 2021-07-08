using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarGui
{
    public class NoteL
    {
        public string Title = string.Empty;
        public string MainText = string.Empty;
        public DateTime date;

        public string border = "_____________";

        public NoteL() { }
        public NoteL(string Title, string MainText, DateTime dateTime)
        {
            this.Title = Title;
            this.MainText = MainText;
            this.date = dateTime;
        }

        public string GetText()
        {
            string output = string.Empty;

            output += border += "\n";
            output += Title += "\n";
            output += MainText;
            output += border += "\n\n";

            return output;
        }
    }
}
