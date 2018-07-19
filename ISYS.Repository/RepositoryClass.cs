using ISYS.Model;
using ISYS.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISYS.Repository
{
    public class RepositoryClass : IRepository<Class>
    {
        MongoDBContext _dbContext;

        public RepositoryClass(string ConnString) => _dbContext = new MongoDBContext(ConnString);

        public Task<Result> Delete(Class entity)
        {
            throw new NotImplementedException();
        }

        public Task<Class> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            try
            {
                var filter = new BsonDocument();
                var distinctClass = _dbContext.Class.AsQueryable()
                    .GroupBy(g => new { g.ClassName, g.ClassDescription, g.ClassDisplayOrder })
                    .OrderBy(x => x.Key.ClassDisplayOrder)
                    .Select(x =>
                    new Class()
                    {
                        ClassName = x.First().ClassName,
                        ClassDescription = x.First().ClassDescription
                    });
                return await distinctClass.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        public Task<IEnumerable<Class>> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Insert(Class entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Update(Class entity)
        {
            throw new NotImplementedException();
        }
    }
}