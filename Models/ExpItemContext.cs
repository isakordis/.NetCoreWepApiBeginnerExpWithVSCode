using Microsoft.EntityFrameworkCore;




namespace Example.Models{



public class ExpItemContext:DbContext
{
        public ExpItemContext(DbContextOptions<ExpItemContext> options):base(options)
        {
            
        }

        public DbSet<ExpItem> ExpItems{get;set;}
}

}