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
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context = null;

        public UnitOfWork()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["StayHealthyConnection"].ToString();
            _context = new DbContext(connectionString);
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

    }
}
