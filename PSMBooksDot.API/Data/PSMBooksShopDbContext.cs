using Microsoft.EntityFrameworkCore;
using PSMBooksDot.API.Models;

namespace PSMBooksDot.API.Data
{
    public class PSMBooksShopDbContext:DbContext
    {
        public PSMBooksShopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<BooksCategory> BooksCategories { get; set; }
        public DbSet<Books> books { get; set; }

    }
}
