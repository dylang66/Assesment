using Assesment.Data;
using Assesment.Models;
using Assesment.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assesment.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private ApplicationDbContext _db;
        internal DbSet<Product> _dbSet;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Product>();
        }
        public void Add(Product entity)
        {
            _dbSet.Add(entity);
        }

        //Can take properties to be included
        public IEnumerable<Product> GetAll()
        {
            return _dbSet;
        }
    }
}
