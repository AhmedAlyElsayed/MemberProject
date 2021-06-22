using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MemberProject.Models
{
    public partial class MemberdbContext : DbContext
    {
        public MemberdbContext()
        {
        }

        public MemberdbContext(DbContextOptions<MemberdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Member> Member { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configBuilder = new ConfigurationBuilder();
                configBuilder.AddJsonFile("appSettings.json");
                var config = configBuilder.Build();

                optionsBuilder.UseSqlServer(config["ConnectionStrings:MemberConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
