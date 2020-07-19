using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace KofmanLibrary.Models
{
    public class Database
    {
        public Database()
        {
            Books = new Dictionary<string, Book>();
            var client = new MongoClient("mongodb+srv://kofmanmona:mona1970@cluster0.uiuju.mongodb.net/Cluster0?retryWrites=true&w=majority");
            Collection = client.GetDatabase("Books").GetCollection<BsonDocument>("books");
            var documents = Collection.Find(new BsonDocument()).ToList();
            foreach(var document in documents)
            {
                var book = new Book(document);
                Books.Add(book.Id, book);
            }
            Borrowed = GetBorrowed();
        }

        /// <summary>
        /// gets the number of books borrowed at the moment
        /// </summary>
        /// <returns>integer representing the number of borrowed books</returns>
        internal int GetNumOfBorrows()
        {
            return Borrowed.Count;
        }

        /// <summary>
        /// gets a list of all the borrowed books in database
        /// filter the list by borrowed books and count
        /// </summary>
        /// <returns>list of Book</returns>
        internal List<Book> GetBorrowed()
        {
            return Books.Select(x => x.Value).Where(x => x.Borrow == true).ToList();
        }

        #region Data Members

        public Dictionary<string, Book> Books { get; set; }
        public IMongoCollection<BsonDocument> Collection { get; set; }
        public List<Book> Borrowed { get; set; }
       

        #endregion
    }
}
