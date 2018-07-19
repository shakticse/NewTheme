using ISYS.Model;
using MongoDB.Driver;
using System.Configuration;

namespace ISYS.MongoDB
{
    public class MongoDBContext
    {
        public const string CONNECTION_STRING_NAME = "AddNSubtract";
        public const string DATABASE_NAME = "addnsubtract";
        public const string POSTS_COLLECTION_NAME = "posts";
        public const string USERS_COLLECTION_NAME = "users";
        public const string TOPICS_COLLECTION_NAME = "topic";

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDBContext(string ConnStringName)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings[ConnStringName].ConnectionString;
            _client = new MongoClient(ConnStringName);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        private IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Post> Posts
        {
            get { return _database.GetCollection<Post>(POSTS_COLLECTION_NAME); }
        }

        public IMongoCollection<User> Users
        {
            get { return _database.GetCollection<User>(USERS_COLLECTION_NAME); }
        }

        public IMongoCollection<Topic> Topics
        {
            get { return _database.GetCollection<Topic>(TOPICS_COLLECTION_NAME); }
        }

        public IMongoCollection<Class> Class
        {
            get { return _database.GetCollection<Class>(TOPICS_COLLECTION_NAME); }
        }
    }
}
