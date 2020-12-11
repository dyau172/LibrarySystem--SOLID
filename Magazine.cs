using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system {
    public class Magazine : Media, IUserInterfaceElement, IUpdate {
        [XmlIgnore]
        public static List<string> categories = new List<string> ();

        public string Editor { get; set; }

      

        public Magazine (string title, string publisher, string dateOfPublication, string editor)
        : base (title, publisher, dateOfPublication) {
            Title = title;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
           
            Editor = editor;
        }

        public override void Display () {
            Console.WriteLine (ID + ", " + Title + ", " + Publisher + ", " + DateOfPublication + ", " + Editor);
        }

        public override void Update () {
            throw new NotImplementedException ();
        }

    }
}