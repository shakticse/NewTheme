using ISYS.Model;
using ISYS.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISYS.Repository
{
    public class RepositoryUser : IRepository<User>
    {
        MongoDBContext _dbContext;

        public RepositoryUser(string ConnString) => _dbContext = new MongoDBContext(ConnString);

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}