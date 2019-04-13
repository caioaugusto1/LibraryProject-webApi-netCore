using MongoDB.Bson.Serialization.Attributes;

namespace Library.Models
{
    public class Writer : EntityBase
    {
        [BsonElement("name")]
        public string Name { get; set; }
        
    }
}
