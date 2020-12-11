using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace library_system {
    class App {
        private string filetype = "JSON";
        private LibraryHelper libraryHelper = new LibraryHelper ();
        private List<NonFictionBook> books;
        //private List<FictionBook> nonbooks;
        //private List<Magazines> mags;
        CurrentTime time = new CurrentTime ();
        public App () {

        }

        public void Run () {
            SaveToFile();
            AddNew();
            DisplayAll();
            
         
        }

        //---for some reason, inserting colons ------------------------------------------------------------------------------------------------------------
        public static string Input (string prompt) {
            Console.Write (prompt + ": ");
            return Console.ReadLine ();
        }

        public void SaveToFile () {
              Console.Clear ();
                time.Update ();
                time.Display ();

                //---saving to file ------------------------------------------------------------------------------------

                switch (filetype) {
                    case "JSON":
                        if (File.Exists (@"library.json")) {
                            string exisitingData;
                            using (StreamReader reader = new StreamReader (@"library.json", Encoding.Default)) {
                                exisitingData = reader.ReadToEnd ();
                            }
                            books = JsonConvert.DeserializeObject<List<NonFictionBook>> (exisitingData);
                        } else {
                            books = new List<NonFictionBook> ();
                        }
                        break;
                    case "XML":
                        if (File.Exists (@"library.xml")) {
                            var serializer = new XmlSerializer (typeof (List<NonFictionBook>));
                            using (var reader = new StreamReader (@"library.xml")) {
                                try {
                                    books = (List<NonFictionBook>) serializer.Deserialize (reader);
                                } catch {
                                    Console.WriteLine ("Could not load file");
                                } // Could not be deserialized to this type.
                            }
                        } else {
                            books = new List<NonFictionBook> ();
                        }
                        break;
                }

        }

        public void AddNew () {
            bool done = false;
            string another = Input ("Add a book y/n");
            if (another == "n") {
                done = true;
            }

            // insert a menu option here
            // select which type of media (fiction, non-fiction or magazine)

            // switch statement -  1 - fiction, 2 - non-fiction, 3 - magazine
            // copy code below to add new types
            // for fiction books - change all the "NonFiction" parts to fiction and all the categories to genre
            // magazine doesn't need categories or genres, change author to editors 


            //---category ------------------------------------------------------------------------------------------------------------
            while (!done) {
                Console.Clear ();

                Console.WriteLine ("Select a category:");
                for (int i = 0; i < libraryHelper.Categories.Count; i++) {
                    Console.WriteLine (i + ": " + libraryHelper.Categories[i]);
                }

                int selectedCategoryID = 0;
                bool validID = false;
                do {
                    try {
                        selectedCategoryID = Convert.ToInt32 (Console.ReadLine ());
                        if (selectedCategoryID >= 0 && selectedCategoryID < libraryHelper.Categories.Count) {
                            validID = true;
                        } else {
                            Console.WriteLine ("Option not available. Please try again");
                        }
                    } catch (Exception ex) {
                        Console.WriteLine (ex);
                        Console.WriteLine ("Please try again");
                    }
                } while (!validID);

                string selectedCategory = libraryHelper.Categories[selectedCategoryID];
                Console.WriteLine ("You have sected {0}", selectedCategory);

                string title = Input ("Title");

                // Number of authors 
                // Option to include more than one author here
                // User inputs the number of authors 
                // Convert number to int 
                // for loop (int i = 0; i < numOfAuthors; i++)

                string author = Input ("Author");
                string publisher = Input ("Publisher");
                string dateOfPublication = Input ("Date of publication");

                books.Add (new NonFictionBook (title, author, publisher, dateOfPublication, selectedCategory));

                another = Input ("Add another? y/n");
                if (another == "n") {
                    done = true;
                }

            };
        }

        public void DisplayAll () {
            Console.Clear ();
            Console.WriteLine ("All books in library\n");
            foreach (var book in books) {
                book.Display ();
            }

            if (filetype == "JSON") {
                using (StreamWriter file = File.CreateText (@"library.json")) {
                    JsonSerializer serializer = new JsonSerializer ();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize (file, books);
                }
            }

            if (filetype == "XML") {
                var serializer = new XmlSerializer (typeof (List<NonFictionBook>));
                using (var writer = new StreamWriter (@"library.xml")) {
                    serializer.Serialize (writer, books);
                }

            }

            //Console.WriteLine(itemsSerialized);
            Console.ReadKey (true);
        }
    }
}