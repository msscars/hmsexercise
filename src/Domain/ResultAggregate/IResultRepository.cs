using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hms.Exercise.Domain.ResultAggregate
{
    public interface IResultRepository
    {
        IQueryable<Result> GetAll();

        Task<Result> AddAsync(Result entity);
    }
}
