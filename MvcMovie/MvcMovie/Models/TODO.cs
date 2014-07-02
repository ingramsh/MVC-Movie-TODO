using System.Data.Entity;

namespace MvcMovie.Models
{
    public class TODO
    {
        public int ID { get; set; }
        public string Task { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    public class TODODBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MvcMovie.Models.TODO> TODOes { get; set; }
    }
}