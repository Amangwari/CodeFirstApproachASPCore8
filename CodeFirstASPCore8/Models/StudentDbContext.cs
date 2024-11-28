using Microsoft.EntityFrameworkCore;

namespace CodeFirstASPCore8.Models
{
    //  here studentdbcontext is inheriting a parent class which is DbContext. 
    // DbContext interacts with database and its tables
    // Without dbcontext class we cannot implement code first approach
    public class StudentDbContext : DbContext
    {
        // class name and constructor name always be same
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            // by using base keyword we are calling parent class constructor 


        }

        // dbset => it will represent a table in database and our table name will be students - dbset name will always name of table in db
        public DbSet<Student> Students { get; set; }



    }
}
