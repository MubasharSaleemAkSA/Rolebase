﻿// <auto-generated />
using System;
using EmpAuthApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmpAuthApi.Migrations
{
    [DbContext(typeof(EmpDbContext))]
    [Migration("20230122152539_ActivityManytoMany")]
    partial class ActivityManytoMany
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmpAuthApi.Models.Activity", b =>
                {
                    b.Property<int>("activityid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("activityid"));

                    b.Property<string>("activityname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("activityid");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Activityrole", b =>
                {
                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.Property<int>("activityid")
                        .HasColumnType("int");

                    b.HasKey("roleid", "activityid");

                    b.HasIndex("activityid");

                    b.ToTable("Activityrole");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Role", b =>
                {
                    b.Property<int>("roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleid"));

                    b.Property<string>("rolename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleid");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EmpAuthApi.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"));

                    b.Property<string>("cnic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("confirmpassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmpAuthApi.Models.UserRole", b =>
                {
                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.HasKey("userid", "roleid");

                    b.HasIndex("roleid");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Activityrole", b =>
                {
                    b.HasOne("EmpAuthApi.Models.Activity", "Activity")
                        .WithMany("activityroles")
                        .HasForeignKey("activityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpAuthApi.Models.Role", "Roles")
                        .WithMany("activityroles")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EmpAuthApi.Models.UserRole", b =>
                {
                    b.HasOne("EmpAuthApi.Models.Role", "Roles")
                        .WithMany("UserRoles")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpAuthApi.Models.User", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Activity", b =>
                {
                    b.Navigation("activityroles");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Role", b =>
                {
                    b.Navigation("UserRoles");

                    b.Navigation("activityroles");
                });

            modelBuilder.Entity("EmpAuthApi.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
