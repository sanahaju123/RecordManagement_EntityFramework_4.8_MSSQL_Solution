
using RecordManagementApp.Models;
using System.Data.Entity;


namespace RecordManagementApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Record> Records { get; set; }
    }
}