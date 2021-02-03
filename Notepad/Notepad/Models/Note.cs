using Notepad.Models;
using System;

namespace Notepad
{
    public class Note
    {
        //Field
        //private string noteID;
        //private string title;
        //private string content;
        //private DateTime creationDate;


        //Properties
        public string Title { get; set; }
        public string Content { get; set; }
        public string ID { get; set; }

        //Constructors
        public Note()
        {
            Title = String.Empty;
            Content = String.Empty;
            ID = NoteId.GenerateCodeID();
        }
    }
}
