using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebInsuranceCompany.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebInsuranceCompany.Data
{
    public partial class InsuranceCompanyContext : DbContext
    {
        public InsuranceCompanyContext()
        {
        }

        public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<GroupOfClients> GroupOfClients { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Risk> Risk { get; set; }
        public virtual DbSet<TypeOfPolicy> TypeOfPolicy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite("Data Source=C:\\Users\\Даша\\Source\\Repos\\ssmlnsk\\WebInsuranceCompany\\InsuranceCompany.db");
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=InsuranceCompany.db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .HasColumnType("INT");

                entity.Property(e => e.PassportData).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(255)");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.GroupId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Age).HasColumnType("INT");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.PassportData).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(255)");

                entity.Property(e => e.PostId)
                    .HasColumnName("PostID")
                    .HasColumnType("INT");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupOfClients>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupId)
                    .HasColumnName("GroupID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.PolicyId)
                    .HasColumnName("PolicyID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId)
                    .HasColumnName("ClientID")
                    .HasColumnType("INT");

                entity.Property(e => e.Cost).HasColumnType("INT");

                entity.Property(e => e.DateOfFinish)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.DateOfStart)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasColumnType("INT");

                entity.Property(e => e.MarkOfEnd)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.PaymentAmount).HasColumnType("INT");

                entity.Property(e => e.PaymentMark)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.TypeOfPolicyId)
                    .HasColumnName("TypeOfPolicyID")
                    .HasColumnType("INT");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.ClientId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TypeOfPolicy)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.TypeOfPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId)
                    .HasColumnName("PostID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Responsibilities)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Salary).HasColumnType("INT");
            });

            modelBuilder.Entity<Risk>(entity =>
            {
                entity.Property(e => e.RiskId)
                    .HasColumnName("RiskID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.AverageProbability).HasColumnType("FLOAT");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<TypeOfPolicy>(entity =>
            {
                entity.Property(e => e.TypeOfPolicyId)
                    .HasColumnName("TypeOfPolicyID")
                    .HasColumnType("INT")
                    .ValueGeneratedNever();

                entity.Property(e => e.Conditions)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR (255)");

                entity.Property(e => e.RiskId1)
                    .HasColumnName("RiskID1")
                    .HasColumnType("INT");

                entity.Property(e => e.RiskId2)
                    .HasColumnName("RiskID2")
                    .HasColumnType("INT");

                entity.Property(e => e.RiskId3)
                    .HasColumnName("RiskID3")
                    .HasColumnType("INT");

                entity.HasOne(d => d.RiskId1Navigation)
                    .WithMany(p => p.TypeOfPolicyRiskId1Navigation)
                    .HasForeignKey(d => d.RiskId1)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RiskId2Navigation)
                    .WithMany(p => p.TypeOfPolicyRiskId2Navigation)
                    .HasForeignKey(d => d.RiskId2)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.RiskId3Navigation)
                    .WithMany(p => p.TypeOfPolicyRiskId3Navigation)
                    .HasForeignKey(d => d.RiskId3)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
