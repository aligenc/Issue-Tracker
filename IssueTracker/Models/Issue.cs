using IssueTracker.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IssueTracker.Models
{
    public class Issue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
    }
}
