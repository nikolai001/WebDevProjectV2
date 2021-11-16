﻿// <auto-generated />
using System;
using AAO_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AAO_App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211116100643_CreateTableDriverLicensTypeAForeignKey")]
    partial class CreateTableDriverLicensTypeAForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AAO_App.Models.AvailabilityType", b =>
                {
                    b.Property<int>("AvailabilityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AvailabilityTypeId");

                    b.ToTable("AvailabilityTypes");
                });

            modelBuilder.Entity("AAO_App.Models.DriverLicensType", b =>
                {
                    b.Property<int>("DriverLicensTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("LicensTypeId")
                        .HasColumnType("int");

                    b.HasKey("DriverLicensTypeId");

                    b.HasIndex("LicensTypeId");

                    b.ToTable("DriverLicensTypes");
                });

            modelBuilder.Entity("AAO_App.Models.LicensType", b =>
                {
                    b.Property<int>("LicensTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LicensExpDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("LicensImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("LicensName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicensTypeId");

                    b.ToTable("LicensTypes");
                });

            modelBuilder.Entity("AAO_App.Models.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("AAO_App.Models.DriverLicensType", b =>
                {
                    b.HasOne("AAO_App.Models.LicensType", "LicensTypes")
                        .WithMany()
                        .HasForeignKey("LicensTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LicensTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
