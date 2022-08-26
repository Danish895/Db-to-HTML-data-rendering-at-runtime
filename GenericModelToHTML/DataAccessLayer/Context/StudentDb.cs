using GenericModelToHTML.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericModelToHTML.DataAccessLayer.Context
{
    public class StudentDbContext : DbContext
    {
            public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options) { }

            public DbSet<Student> Students { get; set; }
            public DbSet<Document> Documents { get; set; }
    }
}
