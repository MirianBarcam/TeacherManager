using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherManager.API.Models
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://mirian:200793@teachermanagerbd-shard-00-00.frkxn.mongodb.net:27017,teachermanagerbd-shard-00-01.frkxn.mongodb.net:27017,teachermanagerbd-shard-00-02.frkxn.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-y4vabr-shard-0&authSource=admin&retryWrites=true&w=majority");
            db = client.GetDatabase("TeacherManager");
        }
    }
}
