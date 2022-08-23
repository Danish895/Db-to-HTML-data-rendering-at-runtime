using GenericModelToHTML.DataAccessLayer.Context;
using GenericModelToHTML.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericModelToHTML.DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentDbContext _context;

        public UserRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> AllStudent()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
