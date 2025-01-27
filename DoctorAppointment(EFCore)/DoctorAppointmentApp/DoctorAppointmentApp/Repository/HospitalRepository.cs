using DoctorAppointmentApp.Contexts;
using Microsoft.EntityFrameworkCore;


namespace DoctorAppointmentApp.Repository
{
    public class HospitalRepository<T> where T : class  //generic class
    {
        private readonly HospitalContext _context;
        private readonly DbSet<T> _dbSet;

        public HospitalRepository(HospitalContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);     //find using Primary key
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
