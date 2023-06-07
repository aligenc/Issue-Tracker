using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IssueTracker.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly IMongoCollection<Issue> _issueCollection;

        public IssueRepository(IMongoDatabase database)
        {
            _issueCollection = database.GetCollection<Issue>("issues");
        }

        public async Task<IList<Issue>> GetAllIssues()
        {
            return await _issueCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Issue> GetIssueById(ObjectId id)
        {
            return await _issueCollection.Find(issue => issue.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Issue> CreateIssue(Issue issue)
        {
            await _issueCollection.InsertOneAsync(issue);
            return issue;
        }

        public async Task<bool> UpdateIssue(Issue issue)
        {
            var result = await _issueCollection.ReplaceOneAsync(i => i.Id == issue.Id, issue);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteIssue(ObjectId id)
        {
            var result = await _issueCollection.DeleteOneAsync(issue => issue.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
