﻿// <auto-generated />
using GrpcServicegWithEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrpcServicegWithEF.Data.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GrpcServicegWithEF.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            FirstName = "Ali",
                            LastName = "khan",
                            School = "Nursing"
                        },
                        new
                        {
                            StudentId = 2,
                            FirstName = "khasd",
                            LastName = "tzhr",
                            School = "Mining"
                        },
                        new
                        {
                            StudentId = 3,
                            FirstName = "Hosna",
                            LastName = "Ahmed",
                            School = "Doctoer"
                        },
                        new
                        {
                            StudentId = 4,
                            FirstName = "Rhana",
                            LastName = "Bosra",
                            School = "University"
                        },
                        new
                        {
                            StudentId = 5,
                            FirstName = "Momin",
                            LastName = "HOssain",
                            School = "Bachelor"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
