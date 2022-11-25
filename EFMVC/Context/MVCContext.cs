using Microsoft.EntityFrameworkCore;
using EFMVC.Models;

namespace EFMVC.Context
{
    public class MVCContext: DbContext
    {
        public MVCContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
    }
}
