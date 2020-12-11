using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace library_system
{
    public class FictionBook : Media, IUserInterfaceElement, IUpdate
    {
        [XmlIgnore]
        public string Author { get; set; }
      
        public string Genre { get; set; }      

        public FictionBook(string title, string author, string publisher, string dateOfPublication, string genre)
        : base (title, publisher, dateOfPublication) 
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Genre = genre;
          
        }

        public override void Display()
        {
            Console.WriteLine(ID + ", " + Author + ", " + Title + ", " + Publisher + ", " + DateOfPublication);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

    }
}
