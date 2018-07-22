using ISYS.Model;
using ISYS.MongoDB;
using MongoDB.Driver;
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

        public async Task<Post> Get(string id)
        {
            return await _dbContext.Posts.Find(x => x.CourseId == id).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Insert(Post entity)
        {
            try
            {
                await _dbContext.Posts.InsertOneAsync(entity);
                return new Result()
                {
                    RecordId = entity.Id,
                    HasError = false,
                    Message = "Record Saved Successfully",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    HasError = true,
                    Message = "Error Saving Record",
                    StatusCode = 200
                };
            }
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
