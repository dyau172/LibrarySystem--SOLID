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

        public FictionBook(string title, string author, string publisher, string dateOfPublication, string category, string genre)
        : base (title, publisher, dateOfPublication, category) 
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            DateOfPublication = dateOfPublication;
            Genre = genre;
            Category = category;
           // categories.Add(category); //Add to categories list so we can easily count how many we have
            //int count = categories.Where(x => x.Equals(category)).Count(); //Using LINQ Count the number of existing books of this category
           // ID = category.Substring(0, 4) + count.ToString("00");
            
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
