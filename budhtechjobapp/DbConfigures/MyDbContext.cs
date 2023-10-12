using budhtechjobapp.Models;
using Microsoft.EntityFrameworkCore;

namespace budhtechjobapp.DbConfigures
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        // DbSet for entity
        public DbSet<SignupRequest> SignupRequests { get; set; }

        public DbSet<JobListingRequest> JobListingRequests { get; set; }

        public DbSet<JobApplication> JobTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations, including primary keys and relationships, go here
            modelBuilder.Entity<SignupRequest>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<SignupRequest>()
                .ToTable("SignupRequests", schema: "public");

            modelBuilder.Entity<JobListingRequest>()
                .HasKey(j => j.JobId);
            modelBuilder.Entity<JobListingRequest>()
                .ToTable("JobListingRequests", schema: "public");

            modelBuilder.Entity<JobApplication>().HasKey(j => j.Id);
            modelBuilder.Entity<JobApplication>().ToTable("JobTable", schema: "public");

            
           /* modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobListing)       
                .WithMany(jl => jl.JobApplications) // JobListing has many JobApplications
                .HasForeignKey(ja => ja.JobListingId); // Foreign key is JobListingId

            
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.SignupRequest)    // JobApplication has one SignupRequest
                .WithMany(sr => sr.JobApplications) // SignupRequest has many JobApplications
                .HasForeignKey(ja => ja.SignupId);  // Foreign key is SignupId
*/
        }
    }
}
