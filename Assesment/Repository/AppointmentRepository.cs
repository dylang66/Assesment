using Assesment.Data;
using Assesment.Models;
using Assesment.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assesment.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private ApplicationDbContext _db;
        internal DbSet<Appointment> _dbSet;
        public AppointmentRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Appointment>();
        }
        public void Add(Appointment entity)
        {
            _dbSet.Add(entity);
        }

        //Can take properties to be included
        public IEnumerable<Appointment> GetAll()
        {
            return _dbSet;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
