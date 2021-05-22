using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherManager.API.Models.Users
{
    public class UsersCollection : IUsersCollection
    {
        internal MongoDBRepository repository = new MongoDBRepository();
        private IMongoCollection<Users> Collection;

        public UsersCollection()
        {
            Collection = repository.db.GetCollection<Users>("Users");
        }
        public async Task DeleteUsers(string id)
        {
            var filter = Builders<Users>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Users> GetUsersById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();

        }

        public async Task InsertUsers(Users user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task UpdateUsers(Users user)
        {
            var filter = Builders<Users>.Filter.Eq(s => s.Id, user.Id);
            await Collection.ReplaceOneAsync(filter, user);
        }
    }
}
