using LanguagesCourse.Domain;
using LanguagesCourse.Repository.Context;
using LanguagesCourse.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguagesCourse.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Student>?> GetAllAsync()
        {
            if(_context.Student == null)
                throw new ArgumentException("Context is null");

            return await _context.Student.AsNoTracking()
                .Include(x => x.Registrations).ThenInclude(x => x.Class).ToListAsync();
        }
        
        public async Task<Student?> GetByIdAsync(int id)
        {
            if(_context.Student == null)
                throw new ArgumentException("Context is null");

            return await _context.Student.AsNoTracking()
                .Include(x => x.Registrations).ThenInclude(x => x.Class).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> GetByCpfAsync(string cpf)
        {
            if(_context.Student == null)
                throw new ArgumentException("Context is null");
                
            return await _context.Student.AsNoTracking()
                .Include(x => x.Registrations).ThenInclude(x => x.Class).FirstOrDefaultAsync(x => x.Cpf == cpf);
        }
    }
}