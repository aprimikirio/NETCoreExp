using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCGame.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Square> Squares { get; set; }
        public DbSet<Game> Games { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
