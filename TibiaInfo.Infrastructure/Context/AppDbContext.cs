using System;
using Microsoft.EntityFrameworkCore;
using TibiaInfo.Core.Models;

namespace TibiaInfo.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hunting> Huntings { get; set; }
        public DbSet<CharacterHuntingInfo> CharacterHuntingInfos { get; set; }

    }
}