using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {

        public DbSet<Author> Authors { get; set; }  = default!;
        public DbSet<Post> Posts { get; set; } = default!;
        
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}