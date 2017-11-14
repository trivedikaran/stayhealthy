using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;


namespace StayHealthy.Entities.Repository
{
    public interface IRepository<T> where T : class
    {
        DbRawSqlQuery<T> SQLQuery(string sql, params object[] parameters);
    }
}
