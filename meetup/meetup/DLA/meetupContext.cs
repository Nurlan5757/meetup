using meetup.Models;
using Microsoft.EntityFrameworkCore;

namespace meetup.DLA
{
    public class meetupContext :DbContext
    {
        public meetupContext(DbContextOptions<meetupContext> options) :base(options) { }
        
         public DbSet<Meet> Meets { get; set; }

        
    }
}
