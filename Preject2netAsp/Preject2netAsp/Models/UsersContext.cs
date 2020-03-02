using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Preject2netAsp.Models
{
    
    public class UsersContext : DbContext
    {   
        public DbSet<Users> user { get; set; }
        public DbSet<PlayListModel> playList { get; set; }
        public DbSet<Friends> friend { get; set; }
        public DbSet<TracksTops> toptraks { get; set; }

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {

        }

        internal object Find(string email)
        {
            throw new NotImplementedException();
        }
    }

}
