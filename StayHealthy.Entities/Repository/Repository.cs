using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace StayHealthy.Entities.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext entities = null;

        public Repository(DbContext _entities)
        {
            entities = _entities;
        }

        public DbRawSqlQuery<T> SQLQuery(string sql, params object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                return entities.Database.SqlQuery<T>(sql, parameters);
            }
            else
            {
                return entities.Database.SqlQuery<T>(sql);
            }
        }
    }
}
