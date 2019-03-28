using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Library.Models
{
    public class Book : EntityBase
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }

        [BsonElement("pages")]
        public int Pages { get; set; } = 0;

        [BsonElement("avaliable")]
        public bool Avaliable { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
