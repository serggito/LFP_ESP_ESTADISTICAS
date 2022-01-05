using API_Partidos_Futbol.Models.Autenticacion;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Partidos_Futbol.Context
{
    public class UserDbContext : IdentityDbContext<Usuario>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
