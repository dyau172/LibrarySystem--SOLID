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

      

        public Magazine (string title, string publisher, string dateOfPublication, string editor,string category) {
            Title = title;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Category = category;
            categories.Add (category); //Add to categories list so we can easily count how many we have
            int count = categories.Where (x => x.Equals (category)).Count (); //Using LINQ Count the number of existing books of this category
            ID = "M-" + category.Substring (0, 4) + count.ToString ("00");
            Editor = editor;
        }

        public override void Display () {
            Console.WriteLine (ID + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }

        public override void Update () {
            throw new NotImplementedException ();
        }

    }
}