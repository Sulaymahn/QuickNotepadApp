using Notepad.Models;
using System;

namespace Notepad
{
    public class Note
    {
        //Properties
        public string Title { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }
        public string Date { get; set; }

        //Constructors
        public Note()
        {
            Title = String.Empty;
            Content = String.Empty;
            ID = NoteId.GenerateCodeID();
            Date = string.Format("{0:d/M/yyyy}",DateTime.Now.ToString());
        }
    }
}
