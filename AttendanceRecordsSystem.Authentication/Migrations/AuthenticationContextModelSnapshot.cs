﻿// <auto-generated />
using AttendanceRecordsSystem.Authentication.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AttendanceRecordsSystem.Authentication.Migrations
{
    [DbContext(typeof(AuthenticationContext))]
    partial class AuthenticationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AttendanceRecordsSystem.Authentication.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'4', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AttendanceRecordsSystem.Authentication.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "123321",
                            Username = "vladimir35"
                        },
                        new
                        {
                            Id = 2,
                            Password = "111",
                            Username = "veta28"
                        });
                });

            modelBuilder.Entity("AttendanceRecordsSystem.Authentication.Models.Role", b =>
                {
                    b.HasOne("AttendanceRecordsSystem.Authentication.Models.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
