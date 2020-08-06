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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.TibiaCharacters)
                .WithOne(e => e.User);

            modelBuilder.Entity<Huntings>()
                .HasKey(bc => new { bc.TibiaCharacterId, bc.CharacterHuntingInfoId, bc.HuntingInfoId});
            modelBuilder.Entity<Huntings>()
                .HasOne(bc => bc.TibiaCharacter)
                .WithMany(b => b.Huntings)
                .HasForeignKey(bc => bc.TibiaCharacterId);
            modelBuilder.Entity<Huntings>()
                .HasOne(bc => bc.CharacterHuntingInfo)
                .WithMany(b => b.Huntings)
                .HasForeignKey(bc => bc.CharacterHuntingInfoId);
            modelBuilder.Entity<Huntings>()
                .HasOne(bc => bc.HuntingInfo)
                .WithMany(b => b.Huntings)
                .HasForeignKey(bc => bc.HuntingInfoId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TibiaCharacter> TibiaCharacters { get; set; }
        public DbSet<Huntings> Huntings { get; set; }
        public DbSet<HuntingInfo> HuntingInfos { get; set; }
        public DbSet<CharacterHuntingInfo> CharacterHuntingInfos { get; set; }

    }
}