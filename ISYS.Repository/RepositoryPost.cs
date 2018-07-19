using ISYS.Model;
using ISYS.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISYS.Repository
{
    public class RepositoryPost : IRepository<Post>
    {
        MongoDBContext _dbContext;

        public RepositoryPost(string ConnString) => _dbContext = new MongoDBContext(ConnString);

        public Task<Post> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
