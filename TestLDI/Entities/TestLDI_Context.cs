using Microsoft.EntityFrameworkCore;

namespace TestLDI.Entities
{
    public class TestLDI_Context:DbContext
    {
        public TestLDI_Context(DbContextOptions<TestLDI_Context> options):base(options)
        {

        }
        public DbSet<PhoneDirectory> phoneDirectories { get; set; }
    }
}
