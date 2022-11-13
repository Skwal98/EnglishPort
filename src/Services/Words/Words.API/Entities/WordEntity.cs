using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Words.API.Entities
{
    public sealed class WordEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Text")]
        public string Text { get; set; }
        public List<string> Translates { get; set; }
    }
}
