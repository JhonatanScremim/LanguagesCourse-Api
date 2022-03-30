using LanguagesCourse.Domain;
using LanguagesCourse.Repository.Context;
using LanguagesCourse.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguagesCourse.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly DataContext _context;

        public RegistrationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Registration>> GetAllAsync()
        {
            if(_context.Registration == null)
                throw new ArgumentException("Context is null");

            return await _context.Registration.AsNoTracking()
                .Include(x => x.Class).Include(x => x.Student).ToListAsync();
        }

        public async Task<Registration?> GetByIdAsync(int id)
        {
            if(_context.Registration == null)
                throw new ArgumentException("Context is null");

            return await _context.Registration.AsNoTracking()
                .Include(x => x.Class).Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Registration?> GetByStudentClass(int studentId, int classId)
        {
            if(_context.Registration == null)
                throw new ArgumentException("Context is null");

            return await _context.Registration.AsNoTracking()
                .Include(x => x.Class).Include(x => x.Student)
                .FirstOrDefaultAsync(x => x.StudentId == studentId && x.ClassId == classId);
        }
    }
}