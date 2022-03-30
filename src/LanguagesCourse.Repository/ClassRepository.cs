using LanguagesCourse.Domain;
using LanguagesCourse.Repository.Context;
using LanguagesCourse.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanguagesCourse.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContext _context;

        public ClassRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Class?> GetByIdAsync(int id)
        {
            if(_context.Class == null)
                throw new ArgumentException("Context is null");
            
            return await _context.Class.AsNoTracking()
                .Include(x => x.Registrations).ThenInclude(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Class>> GetClassesByListIdsAsync(List<int> ids)
        {
            if(_context.Class == null)
                throw new ArgumentException("Context is null");

            var classes = new List<Class>();

            foreach(var id in ids)
            {
                var classFind = await _context.Class.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if(classFind != null)
                    classes.Add(classFind);
            }

            return classes;
        }
    }
}