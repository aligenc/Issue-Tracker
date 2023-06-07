using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.Models;
using MongoDB.Bson;

namespace IssueTracker.Repositories
{
    public interface IIssueRepository
    {
        Task<IList<Issue>> GetAllIssues();
        Task<Issue> GetIssueById(ObjectId id);
        Task<Issue> CreateIssue(Issue issue);
        Task<bool> UpdateIssue(Issue issue);
        Task<bool> DeleteIssue(ObjectId id);
    }
}
