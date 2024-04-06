using Microsoft.EntityFrameworkCore;
using WebAPI_In_DotNet_Core.Models;

namespace WebAPI_In_DotNet_Core
{
    public class ApplicationDBContext : DbContext
    {
        //Constructors
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        //Add models to database context
        public virtual DbSet<StudentModel> Students { get; set; }

    }
}
