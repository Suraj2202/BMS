﻿// <auto-generated />
using System;
using LoginSecurity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoginSecurity.Migrations
{
    [DbContext(typeof(BankManagementDbContext))]
    [Migration("20221127173707_comment")]
    partial class comment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoginSecurity.Models.Domains.LoanDetail", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoanDuration")
                        .HasColumnType("int");

                    b.Property<string>("LoanType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("RateOfInterest")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserDetailUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanId");

                    b.HasIndex("UserDetailUserName");

                    b.ToTable("LoanDetails");
                });

            modelBuilder.Entity("LoginSecurity.Models.Domains.UserDetail", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Contact")
                        .HasColumnType("bigint");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PAN")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("LoginSecurity.Models.Domains.LoanDetail", b =>
                {
                    b.HasOne("LoginSecurity.Models.Domains.UserDetail", null)
                        .WithMany("LoanDetails")
                        .HasForeignKey("UserDetailUserName");
                });

            modelBuilder.Entity("LoginSecurity.Models.Domains.UserDetail", b =>
                {
                    b.Navigation("LoanDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
