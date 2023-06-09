using System.Threading.Tasks;
using IssueTracker.Models;
using MongoDB.Driver;

namespace IssueTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public UserRepository(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<User>("users");
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            return await _usersCollection.Find(filter).FirstOrDefaultAsync();
        }
    }

}
