using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system {
    public abstract class Media : IUserInterfaceElement, IUpdate {

        static List<string> categories = new List<string> ();
       
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string DateOfPublication { get; set; }
        public string ID { get; set; }

        

        public Media (string title, string publisher, string dateOfPublication) {
            Title = title;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            
            
        }

        public virtual void Display () {

        }

        public virtual void Update () {

        }

    }
}