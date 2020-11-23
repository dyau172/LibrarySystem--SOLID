using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system {
    public abstract class Media : IUserInterfaceElement, IUpdate {

        static List<string> categories = new List<string> ();
        public string Category { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }

        public Media (string title, string publisher, string dateOfPublication, string category) {
            Title = title;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Category = category;
            categories.Add (category); //Add to categories list so we can easily count how many we have
            int count = categories.Where (x => x.Equals (category)).Count (); //Using LINQ Count the number of existing books of this category
            ID = category.Substring (0, 4) + count.ToString ("00");
        }

        public virtual void Display () {

        }

        public virtual void Update () {

        }

    }
}