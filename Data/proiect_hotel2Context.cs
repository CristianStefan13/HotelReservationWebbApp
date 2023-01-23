using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect_hotel2.Models;

namespace proiect_hotel2.Data
{
    public class proiect_hotel2Context : DbContext
    {
        public proiect_hotel2Context (DbContextOptions<proiect_hotel2Context> options)
            : base(options)
        {
        }

        public DbSet<proiect_hotel2.Models.Reservation> Reservation { get; set; } = default!;

        public DbSet<proiect_hotel2.Models.Guest> Guest { get; set; }

        public DbSet<proiect_hotel2.Models.Category> Type { get; set; }

        public DbSet<proiect_hotel2.Models.Member> Member { get; set; }
    }
}
