﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebInsuranceCompany.Data;

namespace WebInsuranceCompany.Migrations
{
    [DbContext(typeof(InsuranceCompanyContext))]
    [Migration("20210520144106_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebInsuranceCompany.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnName("ClientID")
                        .HasColumnType("INT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("INT");

                    b.Property<string>("PassportData")
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Phone")
                        .HasColumnType("NVARCHAR(255)");

                    b.HasKey("ClientId");

                    b.HasIndex("GroupId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("INT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("Age")
                        .HasColumnType("INT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("PassportData")
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<string>("Phone")
                        .HasColumnType("NVARCHAR(255)");

                    b.Property<int>("PostId")
                        .HasColumnName("PostID")
                        .HasColumnType("INT");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PostId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.GroupOfClients", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnName("GroupID")
                        .HasColumnType("INT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.HasKey("GroupId");

                    b.ToTable("GroupOfClients");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Policy", b =>
                {
                    b.Property<int>("PolicyId")
                        .HasColumnName("PolicyID")
                        .HasColumnType("INT");

                    b.Property<int?>("ClientId")
                        .HasColumnName("ClientID")
                        .HasColumnType("INT");

                    b.Property<int>("Cost")
                        .HasColumnType("INT");

                    b.Property<DateTime>("DateOfFinish")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("DateOfStart")
                        .HasColumnType("DATE");

                    b.Property<int>("EmployeeId")
                        .HasColumnName("EmployeeID")
                        .HasColumnType("INT");

                    b.Property<string>("MarkOfEnd")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("PaymentAmount")
                        .HasColumnType("INT");

                    b.Property<string>("PaymentMark")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("TypeOfPolicyId")
                        .HasColumnName("TypeOfPolicyID")
                        .HasColumnType("INT");

                    b.HasKey("PolicyId");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TypeOfPolicyId");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnName("PostID")
                        .HasColumnType("INT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Responsibilities")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("Salary")
                        .HasColumnType("INT");

                    b.HasKey("PostId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Risk", b =>
                {
                    b.Property<int>("RiskId")
                        .HasColumnName("RiskID")
                        .HasColumnType("INT");

                    b.Property<double>("AverageProbability")
                        .HasColumnType("FLOAT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.HasKey("RiskId");

                    b.ToTable("Risk");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.TypeOfPolicy", b =>
                {
                    b.Property<int>("TypeOfPolicyId")
                        .HasColumnName("TypeOfPolicyID")
                        .HasColumnType("INT");

                    b.Property<string>("Conditions")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("RiskId1")
                        .HasColumnName("RiskID1")
                        .HasColumnType("INT");

                    b.Property<int>("RiskId2")
                        .HasColumnName("RiskID2")
                        .HasColumnType("INT");

                    b.Property<int>("RiskId3")
                        .HasColumnName("RiskID3")
                        .HasColumnType("INT");

                    b.HasKey("TypeOfPolicyId");

                    b.HasIndex("RiskId1");

                    b.HasIndex("RiskId2");

                    b.HasIndex("RiskId3");

                    b.ToTable("TypeOfPolicy");
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Client", b =>
                {
                    b.HasOne("WebInsuranceCompany.Models.GroupOfClients", "Group")
                        .WithMany("Client")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Employee", b =>
                {
                    b.HasOne("WebInsuranceCompany.Models.Post", "Post")
                        .WithMany("Employee")
                        .HasForeignKey("PostId")
                        .IsRequired();
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.Policy", b =>
                {
                    b.HasOne("WebInsuranceCompany.Models.Client", "Client")
                        .WithMany("Policy")
                        .HasForeignKey("ClientId");

                    b.HasOne("WebInsuranceCompany.Models.Employee", "Employee")
                        .WithMany("Policy")
                        .HasForeignKey("EmployeeId")
                        .IsRequired();

                    b.HasOne("WebInsuranceCompany.Models.TypeOfPolicy", "TypeOfPolicy")
                        .WithMany("Policy")
                        .HasForeignKey("TypeOfPolicyId")
                        .IsRequired();
                });

            modelBuilder.Entity("WebInsuranceCompany.Models.TypeOfPolicy", b =>
                {
                    b.HasOne("WebInsuranceCompany.Models.Risk", "RiskId1Navigation")
                        .WithMany("TypeOfPolicyRiskId1Navigation")
                        .HasForeignKey("RiskId1")
                        .IsRequired();

                    b.HasOne("WebInsuranceCompany.Models.Risk", "RiskId2Navigation")
                        .WithMany("TypeOfPolicyRiskId2Navigation")
                        .HasForeignKey("RiskId2")
                        .IsRequired();

                    b.HasOne("WebInsuranceCompany.Models.Risk", "RiskId3Navigation")
                        .WithMany("TypeOfPolicyRiskId3Navigation")
                        .HasForeignKey("RiskId3")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
