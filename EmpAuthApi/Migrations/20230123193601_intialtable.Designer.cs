// <auto-generated />
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
    [Migration("20230123193601_intialtable")]
    partial class intialtable
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

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Activityrole", b =>
                {
                    b.Property<int>("acid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("acid"));

                    b.Property<int>("activityid")
                        .HasColumnType("int");

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.HasKey("acid");

                    b.HasIndex("activityid");

                    b.HasIndex("roleid");

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

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EmpAuthApi.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userid"));

                    b.Property<int?>("Rolesroleid")
                        .HasColumnType("int");

                    b.Property<int>("URid")
                        .HasColumnType("int");

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

                    b.HasIndex("Rolesroleid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Activityrole", b =>
                {
                    b.HasOne("EmpAuthApi.Models.Activity", "Activities")
                        .WithMany("activityrole")
                        .HasForeignKey("activityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpAuthApi.Models.Role", "Role")
                        .WithMany("activityrole")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activities");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EmpAuthApi.Models.User", b =>
                {
                    b.HasOne("EmpAuthApi.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("Rolesroleid");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Activity", b =>
                {
                    b.Navigation("activityrole");
                });

            modelBuilder.Entity("EmpAuthApi.Models.Role", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("activityrole");
                });
#pragma warning restore 612, 618
        }
    }
}
