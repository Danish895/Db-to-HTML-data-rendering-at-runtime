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

        public async Task<Document> GetBodyData()
        {
            Document Bodydata = await _context.Documents.Where(t => t.Code == "HeadCode").FirstOrDefaultAsync();
            return Bodydata;
        }

        public Task<string> GetHeadData()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPageData()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> fileSaving(string htmlfiles)
        {
            AutoRenderingFile files = new AutoRenderingFile()
            {
                MyFile = htmlfiles
            };
            await _context.AutoRenderingFiles.AddAsync(files);
            _context.SaveChanges();
            return true;

        }
    }
}
