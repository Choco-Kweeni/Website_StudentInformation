using Microsoft.EntityFrameworkCore;
using StudentInformation.Models;

namespace Website_StudentInformation.Models
{
    public class STDBContext : DbContext
    {
        public STDBContext(DbContextOptions<STDBContext> options) : base (options) { }
        public DbSet <Student> Students { get; set; }
    }
}
