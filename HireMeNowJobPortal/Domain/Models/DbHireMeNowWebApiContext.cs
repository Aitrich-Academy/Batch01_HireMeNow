using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class DbHireMeNowWebApiContext : DbContext
{
    public DbHireMeNowWebApiContext()
    {
    }

    public DbHireMeNowWebApiContext(DbContextOptions<DbHireMeNowWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }
    public virtual DbSet<CompanyUser> CompanyUsers { get; set; }
    public virtual DbSet<Industry> Industries { get; set; }
    public virtual DbSet<Interview> Interviews { get; set; }
    public virtual DbSet<JobApplication> JobApplications { get; set; }
    public virtual DbSet<JobCategory> JobCategories { get; set; }
    public virtual DbSet<JobPost> JobPosts { get; set; }
    public virtual DbSet<JobProviderCompany> JobProviderCompanies { get; set; }
    public virtual DbSet<JobResponsibility> JobResponsibilities { get; set; }
    public virtual DbSet<JobSeeker> JobSeekers { get; set; }
    public virtual DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
    public virtual DbSet<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Qualification> Qualifications { get; set; }
    public virtual DbSet<Resume> Resumes { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<SavedJob> SavedJobs { get; set; }
    public virtual DbSet<SignUpRequest> SignUpRequests { get; set; }
    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Your Connection String").UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.ToTable("CompanyUser");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.CompanyUsers)
                .HasForeignKey(d => d.Company)
                .HasConstraintName("FK_CompanyUser_JobProviderCompany");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.ToTable("Industry");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.ToTable("Interview");

            entity.HasOne(d => d.Job).WithMany(p => p.Interviews)
               .HasForeignKey(d => d.JobId)
               .HasConstraintName("FK_Interview_JobId");

            entity.HasOne(d => d.Jobseeker).WithMany(p => p.Interviews)
               .HasForeignKey(d => d.Interviewee)
               .HasConstraintName("FK_Interview_Interviewee");

            entity.HasOne(d => d.Application).WithMany(p => p.Interviews)
              .HasForeignKey(d => d.ApplicationId)
              .HasConstraintName("FK_Interview_ApplicationId");

            entity.HasOne(d => d.CompanyUser).WithMany(p => p.Interviews)
              .HasForeignKey(d => d.ScheduledBy)
              .HasConstraintName("FK_Interview_ScheduledBy");

            entity.HasOne(d => d.Company).WithMany(p => p.Interviews)
              .HasForeignKey(d => d.CompanyId)
              .HasConstraintName("FK_Interview_CompanyId");
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.ToTable("JobApplication");

            entity.HasOne(d => d.JobPost).WithMany(p => p.JobApplications)
               .HasForeignKey(d => d.JobPost_id)
               .HasConstraintName("FK_JobApplication_JobPostId");

            entity.HasOne(d => d.Seeker).WithMany(p => p.JobApplications)
               .HasForeignKey(d => d.Applicant)
               .HasConstraintName("FK_Application_Applicant");

            entity.HasOne(d => d.Resume).WithMany(p => p.JobApplications)
               .HasForeignKey(d => d.Resume_id)
               .HasConstraintName("FK_Application_ResumeId");
        });

        modelBuilder.Entity<JobCategory>(entity =>
        {
            entity.ToTable("JobCategory");

            entity.Property(e => e.Description)
               .HasMaxLength(50)
               .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        
        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.ToTable("JobPost");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.JobSummary).HasMaxLength(50);
            entity.Property(e => e.JobTitle)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.PostedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Location).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_JobPost_LocationId");

            entity.HasOne(d => d.PostedByNavigation).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.PostedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_CompanyUser");

            entity.HasOne(d => d.Company).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_CompanyId");

            entity.HasOne(d => d.JobCategory).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_CategoryId");

            entity.HasOne(d => d.Industry).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_JobPost_Industry");
        });

        modelBuilder.Entity<JobProviderCompany>(entity =>
        {
            entity.ToTable("JobProviderCompany");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LegalName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Summary)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.JobProviderCompanies)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_JobProviderCompany_Location");

            entity.HasOne(d => d.Industry).WithMany(p => p.JobProviderCompanies)
               .HasForeignKey(d => d.IndustryId)
               .OnDelete(DeleteBehavior.SetNull)
               .HasConstraintName("FK_JobProviderCompany_Industry");
        });

        modelBuilder.Entity<JobResponsibility>(entity =>
        {
            entity.ToTable("JobResponsibility");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.JobPostNavigation).WithMany(p => p.JobResponsibilities)
                .HasForeignKey(d => d.JobPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobResponsibility_JobPost");
        });


        modelBuilder.Entity<JobSeekerProfile>(entity =>
        {
            entity.ToTable("JobSeekerProfile");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Resume).WithMany(p => p.JobSeekerProfiles).HasForeignKey(d => d.ResumeId);

            entity.HasOne(d => d.JobSeeker).WithMany(p => p.JobSeekerProfiles)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobSeekerProfile_JobSeekerId");

        });

        modelBuilder.Entity<JobSeekerProfileSkill>(entity =>
        {
            entity.ToTable("JobSeekerProfileSkill");

            entity.HasKey(jps => new { jps.JobSeekerProfileId, jps.SkillId });

            entity.HasOne(d => d.JobSeekerProfile).WithMany(p => p.JobSeekerProfileSkills)
                .HasForeignKey(d => d.JobSeekerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobSeekerProfileSkill_JobSeekerProfileId");

            entity.HasOne(d => d.Skill).WithMany(p => p.JobSeekerProfileSkills)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobSeekerProfileSkill_Skill");

        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.ToTable("Qualification");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.JobPost).WithMany(e => e.Qualifications)
                .HasForeignKey(d => d.JobPostId)
                .HasConstraintName("FK_Qualification_JobPostId");


            entity.HasOne(d => d.JobSeekerProfile).WithMany(e => e.Qualifications)
                .HasForeignKey(d => d.JobseekerProfileId)
                .HasConstraintName("FK_Qualification_JobSeekerProfileId");
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.ToTable("Resume");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.HasOne(d => d.JobSeeker).WithMany(d => d.Resumes)
                  .HasForeignKey(d => d.JobSeekerId)
                  .HasConstraintName("FK_Resume_JobSeekerId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Role");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SavedJob>(entity =>
        {
            entity.ToTable("SavedJob");

            entity.HasOne(d => d.JobSeekerNavigation).WithMany(e => e.SavedJobs)
                .HasForeignKey(d => d.SavedBy)
                .HasConstraintName("FK_SavedJob_SavedBy");


            entity.HasOne(d => d.JobPost).WithMany(e => e.SavedJobs)
                .HasForeignKey(d => d.Job)
                .HasConstraintName("FK_SavedJob_JobSeekerProfile");

        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Id);
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Experiences");

            entity.ToTable("WorkExperience");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.JobSeekerProfile).WithMany(p => p.WorkExperiences)
                .HasForeignKey(d => d.JobSeekerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkExperience_JobSeekerProfile");
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}





