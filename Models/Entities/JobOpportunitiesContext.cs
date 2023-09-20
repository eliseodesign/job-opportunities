using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace job_opportunities_asp_react.Models.Entities;

public partial class JobOpportunitiesContext : DbContext
{
    public JobOpportunitiesContext()
    {
    }

    public JobOpportunitiesContext(DbContextOptions<JobOpportunitiesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<EducationDegree> EducationDegrees { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<EducationSubject> EducationSubjects { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<FieldSector> FieldSectors { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<JobOffer> JobOffers { get; set; }

    public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applican__3214EC07F78F2844");

            entity.ToTable("Applicant");

            entity.HasIndex(e => e.Email, "UQ__Applican__A9D105347A1C2D75").IsUnique();

            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AditionalName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmAccount).HasDefaultValueSql("((0))");
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.MobilePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Pobox)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("POBox");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PrivatePhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RestartAccount).HasDefaultValueSql("((0))");
            entity.Property(e => e.SecondEmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ssn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SSN");
            entity.Property(e => e.Token).IsUnicode(false);
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Citizenship).WithMany(p => p.ApplicantCitizenships)
                .HasForeignKey(d => d.CitizenshipId)
                .HasConstraintName("FK__Applicant__Citiz__4E88ABD4");

            entity.HasOne(d => d.Country).WithMany(p => p.ApplicantCountries)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Applicant__Count__4D94879B");

            entity.HasOne(d => d.DegreeNavigation).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.Degree)
                .HasConstraintName("FK__Applicant__Degre__534D60F1");

            entity.HasOne(d => d.EducationLevelNavigation).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.EducationLevel)
                .HasConstraintName("FK__Applicant__Educa__5165187F");

            entity.HasOne(d => d.Gender).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Applicant__Gende__4F7CD00D");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.MaritalStatusId)
                .HasConstraintName("FK__Applicant__Marit__5070F446");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.Subject)
                .HasConstraintName("FK__Applicant__Subje__52593CB8");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC07F63ABA07");

            entity.ToTable("Application");

            entity.Property(e => e.ApplicationDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK__Applicati__Appli__5629CD9C");

            entity.HasOne(d => d.JobOffer).WithMany(p => p.Applications)
                .HasForeignKey(d => d.JobOfferId)
                .HasConstraintName("FK__Applicati__JobOf__571DF1D5");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC0758C6F5F1");

            entity.ToTable("Country");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EducationDegree>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC07DE051E3E");

            entity.ToTable("EducationDegree");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC072CFCE0B5");

            entity.ToTable("EducationLevel");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EducationSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC073945E3E5");

            entity.ToTable("EducationSubject");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employer__3214EC07FEFCD56F");

            entity.ToTable("Employer");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FieldSector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FieldSec__3214EC072CF8661E");

            entity.ToTable("FieldSector");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gender__3214EC07B4D88596");

            entity.ToTable("Gender");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobOffer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobOffer__3214EC079D5D0E97");

            entity.ToTable("JobOffer");

            entity.Property(e => e.AvailabilityDate).HasColumnType("date");
            entity.Property(e => e.AvailableReferences)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CoverLetter).HasColumnType("text");
            entity.Property(e => e.CurrentEmployer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CurrentPosition)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ExternalLinks).HasColumnType("text");
            entity.Property(e => e.HowDidYouHear)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RelevantWorkExperience)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Employer).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.EmployerId)
                .HasConstraintName("FK__JobOffer__Employ__5441852A");

            entity.HasOne(d => d.FieldSector).WithMany(p => p.JobOffers)
                .HasForeignKey(d => d.FieldSectorId)
                .HasConstraintName("FK__JobOffer__FieldS__5535A963");
        });

        modelBuilder.Entity<MaritalStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MaritalS__3214EC07DB2A4B65");

            entity.ToTable("MaritalStatus");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
