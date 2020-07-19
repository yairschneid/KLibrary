using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KofmanLibrary.Models
{
    public class Book
    {
        public Book()
        {

        }

        public Book(BsonDocument document)
        {
            foreach (var bsonElement in document)
            {
                switch (bsonElement.Name)
                {
                    case "_id":
                        Id = bsonElement.Value.ToString();
                        break;

                    case "name":
                        Name = bsonElement.Value.ToString();
                        break;

                    case "discription":
                        Discription = bsonElement.Value.ToString();
                        break;

                    case "author":
                        Author = bsonElement.Value.ToString();
                        break;

                    case "type":
                        Type = bsonElement.Value.ToString();
                        break;

                    case "copyright":
                        Copyright = bsonElement.Value.ToString();
                        break;

                    case "cost":
                        Cost = Convert.ToDouble(bsonElement.Value);
                        break;

                    case "borrow":
                        Borrow = Convert.ToBoolean(bsonElement.Value);
                        break;

                    case "client":
                        ClientName = bsonElement.Value.ToString();
                        break;

                    case "borrow_time":
                        BorrowTime = Convert.ToDateTime(bsonElement.Value);
                        break;

                    case "picture":
                        PicturePath = bsonElement.Value.ToString();
                        break;

                }
            }
        }



        #region Data Members

        public string Id { get; internal set; }
        public string Name { get; private set; }
        public string Discription { get; private set; }
        public string Type { get; private set; }
        public string Author { get; private set; }
        public string ClientName { get; private set; }
        public string Copyright { get; private set; }
        public double Cost { get; private set; }
        public bool Borrow { get; private set; }
        public DateTime BorrowTime { get; private set; }
        public string PicturePath { get; private set; }


        #endregion
    }
}
