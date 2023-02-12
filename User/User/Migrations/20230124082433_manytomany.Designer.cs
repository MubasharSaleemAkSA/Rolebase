﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using User.Context;

#nullable disable

namespace User.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20230124082433_manytomany")]
    partial class manytomany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("User.Models.Activity", b =>
                {
                    b.Property<int>("activityid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("activityid"), 1L, 1);

                    b.Property<string>("activityname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("activityid");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("User.Models.Role", b =>
                {
                    b.Property<int>("roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleid"), 1L, 1);

                    b.Property<string>("rolename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleid");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("User.Models.RoleActivity", b =>
                {
                    b.Property<int>("RAid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RAid"), 1L, 1);

                    b.Property<int>("activityid")
                        .HasColumnType("int");

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.HasKey("RAid");

                    b.HasIndex("activityid");

                    b.HasIndex("roleid");

                    b.ToTable("RoleActivity");
                });

            modelBuilder.Entity("User.Models.UserData", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"), 1L, 1);

                    b.Property<int>("Fid")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.HasIndex("Fid");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("User.Models.RoleActivity", b =>
                {
                    b.HasOne("User.Models.Activity", "Activities")
                        .WithMany("RoleActivity")
                        .HasForeignKey("activityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User.Models.Role", "Role")
                        .WithMany("RoleActivity")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activities");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("User.Models.UserData", b =>
                {
                    b.HasOne("User.Models.Role", "Role")
                        .WithMany("users")
                        .HasForeignKey("Fid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("User.Models.Activity", b =>
                {
                    b.Navigation("RoleActivity");
                });

            modelBuilder.Entity("User.Models.Role", b =>
                {
                    b.Navigation("RoleActivity");

                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
