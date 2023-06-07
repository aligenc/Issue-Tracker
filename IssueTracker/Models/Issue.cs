using IssueTracker.Enums;
using MongoDB.Bson;

namespace IssueTracker.Models
{
    public class Issue
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IssueStatus Status { get; set; }
    }
}
