using StayHealthy.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayHealthy.Entities.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;
    }
}
