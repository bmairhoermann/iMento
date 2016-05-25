using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SQLiteTestOutFinal
{
    class SaveHandler
    {
        private static SQLiteConnection DbConnection
        {
            get
            {
                return new SQLiteConnection(
                    new SQLitePlatformWinRT(),
                    Path.Combine(ApplicationData.Current.LocalFolder.Path, "Storage.sqlite"));
            }
        }

        public void addPerson(Person person)
        {
            // Create a new connection 
            using (var db = DbConnection)
            {
                // Activate Tracing 
                db.TraceListener = new DebugTraceListener();

                // Create the table if it does not exist 
                var c = db.CreateTable<Person>();
                var info = db.GetMapping(typeof(Person));

                // Insert or Replace Person
                //var i = db.InsertOrReplace(person);
                db.Insert(person);
            }
        }

        public void showDB()
        {
            using (var db = DbConnection)
            {
                var query = db.Table<Person>();
                string result = String.Empty;
                foreach(var item in query)
                {
                    result = String.Format("{0} : {1}", item.Id, item.Name);
                    Debug.WriteLine(result);
                }
            }
        }

    }

    /// <summary> 
    /// Writes SQLite.NET trace to the Debug window. 
    /// </summary> 
    public class DebugTraceListener : ITraceListener
    {
        public void Receive(string message)
        {
            Debug.WriteLine(message);
        }
    }

    public class Person
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [MaxLength(64)]
        public string Name { get; set; }

        /*
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the day of birth.
        /// </summary>
        public DateTime DayOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public byte[] Picture { get; set; }
        */
    }
}
