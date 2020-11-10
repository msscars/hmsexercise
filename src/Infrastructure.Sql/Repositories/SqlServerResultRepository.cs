using Hms.Exercise.Domain.ResultAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Exercise.Infrastructure.Sql.Repositories
{
    public class SqlServerResultRepository : IResultRepository
    {
        private readonly HmsDbContext dbContext;

        public SqlServerResultRepository(HmsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Result> GetAll()
        {
            try
            {
                return this.dbContext.Set<Result>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Result> AddAsync(Result entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            await this.dbContext.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
