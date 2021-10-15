using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week6Test.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        List<TEntity> Fetch(Func<TEntity, bool> filter = null);
        TEntity GetById(int id);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
