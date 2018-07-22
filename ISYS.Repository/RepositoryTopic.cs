using ISYS.Model;
using ISYS.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISYS.Repository
{
    public class RepositoryTopic : IRepository<Topic>
    {
        private MongoDBContext _dbContext;

        public RepositoryTopic(string ConnString) => _dbContext = new MongoDBContext(ConnString);

        public Task<Topic> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Topic>> GetById(string id)
        {
            return await _dbContext.Topics.Find(x => x.ClassName == id).ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _dbContext.Topics.Find(x => true).ToListAsync();
        }

        public Task<Result> Insert(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}