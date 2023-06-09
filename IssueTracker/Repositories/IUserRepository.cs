using System.Collections.Generic;
using System.Threading.Tasks;
using IssueTracker.Models;
using MongoDB.Bson;

namespace IssueTracker.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
    }
}
