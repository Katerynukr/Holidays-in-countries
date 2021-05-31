﻿// <auto-generated />
using System;
using CountryHolidaySolution.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CountryHolidaySolution.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210531062554_maxHolidayLength")]
    partial class maxHolidayLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.CountryDayStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int?>("DayTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayTypeId");

                    b.ToTable("DayStatuses");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DateId")
                        .HasColumnType("int");

                    b.Property<string>("HolidayType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SupportedCountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.HasIndex("SupportedCountryId");

                    b.ToTable("Holiday");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.HolidayDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HolidayDate");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.HolidayName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HolidayId")
                        .HasColumnType("int");

                    b.Property<int>("Lang")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HolidayId");

                    b.ToTable("HolidayName");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.HolidayPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Country")
                        .HasColumnType("int");

                    b.Property<int>("MaxHolidayLength")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HolidayPeriods");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.SupportedCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<int>("FromDateId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HolidayTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToDateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.WorkDayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsWorkDay")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("WorkDayType");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.CountryDayStatus", b =>
                {
                    b.HasOne("CountryHolidaySolution.Domain.Models.WorkDayType", "DayType")
                        .WithMany()
                        .HasForeignKey("DayTypeId");

                    b.Navigation("DayType");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.Holiday", b =>
                {
                    b.HasOne("CountryHolidaySolution.Domain.Models.HolidayDate", "Date")
                        .WithMany()
                        .HasForeignKey("DateId");

                    b.HasOne("CountryHolidaySolution.Domain.Models.SupportedCountry", null)
                        .WithMany("Holidays")
                        .HasForeignKey("SupportedCountryId");

                    b.Navigation("Date");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.HolidayName", b =>
                {
                    b.HasOne("CountryHolidaySolution.Domain.Models.Holiday", null)
                        .WithMany("Name")
                        .HasForeignKey("HolidayId");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.SupportedCountry", b =>
                {
                    b.OwnsOne("CountryHolidaySolution.Domain.Models.FromDate", "FromDate", b1 =>
                        {
                            b1.Property<int>("SupportedCountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Day")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<int>("Month")
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .HasColumnType("int");

                            b1.HasKey("SupportedCountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("SupportedCountryId");
                        });

                    b.OwnsOne("CountryHolidaySolution.Domain.Models.ToDate", "ToDate", b1 =>
                        {
                            b1.Property<int>("SupportedCountryId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Day")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<int>("Month")
                                .HasColumnType("int");

                            b1.Property<int>("Year")
                                .HasColumnType("int");

                            b1.HasKey("SupportedCountryId");

                            b1.ToTable("Countries");

                            b1.WithOwner()
                                .HasForeignKey("SupportedCountryId");
                        });

                    b.Navigation("FromDate");

                    b.Navigation("ToDate");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.Holiday", b =>
                {
                    b.Navigation("Name");
                });

            modelBuilder.Entity("CountryHolidaySolution.Domain.Models.SupportedCountry", b =>
                {
                    b.Navigation("Holidays");
                });
#pragma warning restore 612, 618
        }
    }
}
