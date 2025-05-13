// CapitolareAI.Infrastructure/Data/ApplicationDbContext.cs
using CapitolareAI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapitolareAI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<DonorInterest> DonorInterests { get; set; }
        public DbSet<Manuscript> Manuscripts { get; set; }
        public DbSet<ManuscriptCategory> ManuscriptCategories { get; set; }
        public DbSet<ManuscriptStoryAngle> ManuscriptStoryAngles { get; set; }
        public DbSet<DonorScore> DonorScores { get; set; }
        public DbSet<ManuscriptAffinity> ManuscriptAffinities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<DonorInterest>()
                .HasOne(di => di.Donor)
                .WithMany(d => d.Interests)
                .HasForeignKey(di => di.DonorId);

            modelBuilder.Entity<DonorScore>()
                .HasOne(ds => ds.Donor)
                .WithOne(d => d.Score)
                .HasForeignKey<DonorScore>(ds => ds.DonorId);

            modelBuilder.Entity<ManuscriptCategory>()
                .HasOne(mc => mc.Manuscript)
                .WithMany(m => m.Categories)
                .HasForeignKey(mc => mc.ManuscriptId);

            modelBuilder.Entity<ManuscriptStoryAngle>()
                .HasOne(msa => msa.Manuscript)
                .WithMany(m => m.StoryAngles)
                .HasForeignKey(msa => msa.ManuscriptId);

            modelBuilder.Entity<ManuscriptAffinity>()
                .HasOne(ma => ma.DonorScore)
                .WithMany(ds => ds.ManuscriptAffinities)
                .HasForeignKey(ma => ma.DonorScoreId);

            modelBuilder.Entity<ManuscriptAffinity>()
                .HasOne(ma => ma.Manuscript)
                .WithMany(m => m.DonorAffinities)
                .HasForeignKey(ma => ma.ManuscriptId);

            // Apply seed data
            SeedData.Initialize(modelBuilder);
        }
    }
}