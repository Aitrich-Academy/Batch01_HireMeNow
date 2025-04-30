using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class NewDbContext : DbContext
{
    public NewDbContext()
    {
    }

    public NewDbContext(DbContextOptions<NewDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<Breed> Breeds { get; set; }

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

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SavedJob> SavedJobs { get; set; }

    public virtual DbSet<SignUpRequest> SignUpRequests { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-C6EG1OJ;Initial Catalog=NewDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.ToTable("AuthUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConnectionId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Breed>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Breed");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CompanyUser>(entity =>
        {
            entity.ToTable("CompanyUser");

            entity.HasIndex(e => e.Company, "IX_CompanyUser_Company");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.CompanyNavigation).WithMany(p => p.CompanyUsers)
                .HasForeignKey(d => d.Company)
                .OnDelete(DeleteBehavior.Cascade)
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
            entity.HasIndex(e => e.ApplicationId, "IX_Interviews_ApplicationId");

            entity.HasIndex(e => e.CompanyId, "IX_Interviews_CompanyId");

            entity.HasIndex(e => e.JobId, "IX_Interviews_JobId");

            entity.HasIndex(e => e.SheduledBy, "IX_Interviews_SheduledBy");

            entity.HasIndex(e => e.Interviewee, "IX_Interviews_interviewee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Interviewee).HasColumnName("interviewee");

            entity.HasOne(d => d.Application).WithMany(p => p.Interviews).HasForeignKey(d => d.ApplicationId);

            entity.HasOne(d => d.Company).WithMany(p => p.Interviews).HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.IntervieweeNavigation).WithMany(p => p.Interviews).HasForeignKey(d => d.Interviewee);

            entity.HasOne(d => d.Job).WithMany(p => p.Interviews).HasForeignKey(d => d.JobId);

            entity.HasOne(d => d.SheduledByNavigation).WithMany(p => p.Interviews).HasForeignKey(d => d.SheduledBy);
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasIndex(e => e.Applicant, "IX_JobApplications_Applicant");

            entity.HasIndex(e => e.JobPostId, "IX_JobApplications_JobPost_id");

            entity.HasIndex(e => e.ResumeId, "IX_JobApplications_Resume_id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.JobPostId).HasColumnName("JobPost_id");
            entity.Property(e => e.ResumeId).HasColumnName("Resume_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.ApplicantNavigation).WithMany(p => p.JobApplications).HasForeignKey(d => d.Applicant);

            entity.HasOne(d => d.JobPost).WithMany(p => p.JobApplications).HasForeignKey(d => d.JobPostId);

            entity.HasOne(d => d.Resume).WithMany(p => p.JobApplications).HasForeignKey(d => d.ResumeId);
        });

        modelBuilder.Entity<JobCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("JobCategory");

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

            entity.HasIndex(e => e.LocationId, "IX_JobPost_JobLocation");

            entity.HasIndex(e => e.PostedBy, "IX_JobPost_PostedBy");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.JobSummary).HasMaxLength(50);
            entity.Property(e => e.JobTitle).IsUnicode(false);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Location).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Location");

            entity.HasOne(d => d.PostedByNavigation).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.PostedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Industry");
        });

        modelBuilder.Entity<JobProviderCompany>(entity =>
        {
            entity.ToTable("JobProviderCompany");

            entity.HasIndex(e => e.IndustryId, "IX_JobProviderCompany_IndustryId");

            entity.HasIndex(e => e.Location, "IX_JobProviderCompany_Location");

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

            entity.HasOne(d => d.Industry).WithMany(p => p.JobProviderCompanies).HasForeignKey(d => d.IndustryId);

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.JobProviderCompanies)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobProviderCompany_Location");
        });

        modelBuilder.Entity<JobResponsibility>(entity =>
        {
            entity.ToTable("JobResponsibility");

            entity.HasIndex(e => e.JobPost, "IX_JobResponsibility_JobPost");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.JobPostNavigation).WithMany(p => p.JobResponsibilities)
                .HasForeignKey(d => d.JobPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobResponsibility_JobPost");
        });

        modelBuilder.Entity<JobSeeker>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<JobSeekerProfile>(entity =>
        {
            entity.ToTable("JobSeekerProfile");

            entity.HasIndex(e => e.JobSeekerId, "IX_JobSeekerProfile_JobSeekerId");

            entity.HasIndex(e => e.ResumeId, "IX_JobSeekerProfile_ResumeId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.JobSeeker).WithMany(p => p.JobSeekerProfiles).HasForeignKey(d => d.JobSeekerId);

            entity.HasOne(d => d.Resume).WithMany(p => p.JobSeekerProfiles)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.Skills).WithMany(p => p.JobSeekerProfiles)
                .UsingEntity<Dictionary<string, object>>(
                    "JobSeekerProfileSkill",
                    r => r.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                    l => l.HasOne<JobSeekerProfile>().WithMany().HasForeignKey("JobSeekerProfileId"),
                    j =>
                    {
                        j.HasKey("JobSeekerProfileId", "SkillId");
                        j.ToTable("JobSeekerProfileSkill");
                        j.HasIndex(new[] { "SkillId" }, "IX_JobSeekerProfileSkill_SkillId");
                    });
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Discription)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Profile");

            entity.Property(e => e.Discription).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.ProfileName).HasMaxLength(50);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.ToTable("Qualification");

            entity.HasIndex(e => e.JobPostId, "IX_Qualification_JobPostId");

            entity.HasIndex(e => e.JobseekerProfileId, "IX_Qualification_JobseekerProfileId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.JobPost).WithMany(p => p.Qualifications)
                .HasForeignKey(d => d.JobPostId)
                .HasConstraintName("FK_Qualification_JobSeekerProfile");

            entity.HasOne(d => d.JobseekerProfile).WithMany(p => p.Qualifications).HasForeignKey(d => d.JobseekerProfileId);
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.ToTable("Resume");

            entity.Property(e => e.Id).ValueGeneratedNever();
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
            entity.HasIndex(e => e.Job, "IX_SavedJobs_Job");

            entity.HasIndex(e => e.SavedBy, "IX_SavedJobs_SavedBy");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.JobNavigation).WithMany(p => p.SavedJobs).HasForeignKey(d => d.Job);

            entity.HasOne(d => d.SavedByNavigation).WithMany(p => p.SavedJobs).HasForeignKey(d => d.SavedBy);
        });

        modelBuilder.Entity<SignUpRequest>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Id).ValueGeneratedNever();
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

            entity.HasIndex(e => e.JobSeekerProfileId, "IX_WorkExperience_JobSeekerProfileId");

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
