﻿// <auto-generated />
using System;
using CountryHolidaySolution.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CountryHolidaySolution.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.FromDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FromDate");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.HolidayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SupportedCountryId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupportedCountryId");

                    b.ToTable("HolidayType");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.RegionCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupportedCountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupportedCountryId");

                    b.ToTable("RegionCode");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.SupportedCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<int?>("FromDateId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ToDateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromDateId");

                    b.HasIndex("ToDateId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.ToDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ToDate");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.HolidayType", b =>
                {
                    b.HasOne("CountryHolidaySolution.Domain.Models.SupportedCountry", null)
                        .WithMany("HolidayTypes")
                        .HasForeignKey("SupportedCountryId");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.RegionCode", b =>
                {
                    b.HasOne("CountryHolidaySolution.Domain.Models.SupportedCountry", null)
                        .WithMany("Regions")
                        .HasForeignKey("SupportedCountryId");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.SupportedCountry", b =>
                {
                    b.HasOne("CountryHolidaySolution.Domain.Models.FromDate", "FromDate")
                        .WithMany()
                        .HasForeignKey("FromDateId");

                    b.HasOne("CountryHolidaySolution.Domain.Models.ToDate", "ToDate")
                        .WithMany()
                        .HasForeignKey("ToDateId");

                    b.Navigation("FromDate");

                    b.Navigation("ToDate");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.SupportedCountry", b =>
                {
                    b.Navigation("HolidayTypes");

                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}
