﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using f7Race_API.Data;

#nullable disable

namespace f7Race_API.Migrations
{
    [DbContext(typeof(F7Db))]
    partial class F7DbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("f7Race_API.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BrandId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPodiums")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("integer");

                    b.Property<int>("TotalWins")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("BrandId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("f7Race_API.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RaceId"));

                    b.Property<string>("FlagRace")
                        .HasColumnType("text");

                    b.Property<string>("ImageCircuit")
                        .HasColumnType("text");

                    b.Property<int>("Laps")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RaceId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("f7Race_API.Models.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeasonId"));

                    b.Property<int>("Edition")
                        .HasColumnType("integer");

                    b.Property<int?>("SecondId")
                        .HasColumnType("integer");

                    b.Property<int?>("ThirdId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("integer");

                    b.HasKey("SeasonId");

                    b.HasIndex("SecondId");

                    b.HasIndex("ThirdId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("f7Race_API.Models.SeasonBrand", b =>
                {
                    b.Property<int>("SeasonBrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeasonBrandId"));

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<int>("SeasonId")
                        .HasColumnType("integer");

                    b.HasKey("SeasonBrandId");

                    b.ToTable("SeasonBrands");
                });

            modelBuilder.Entity("f7Race_API.Models.SeasonRace", b =>
                {
                    b.Property<int>("SeasonRaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SeasonRaceId"));

                    b.Property<int>("EighthPosition")
                        .HasColumnType("integer");

                    b.Property<int>("FifthPosition")
                        .HasColumnType("integer");

                    b.Property<int>("FirstPosition")
                        .HasColumnType("integer");

                    b.Property<string>("FlagRace")
                        .HasColumnType("text");

                    b.Property<int>("FourthPosition")
                        .HasColumnType("integer");

                    b.Property<string>("ImageCircuit")
                        .HasColumnType("text");

                    b.Property<int>("Laps")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("NinthPosition")
                        .HasColumnType("integer");

                    b.Property<int>("SeasonId")
                        .HasColumnType("integer");

                    b.Property<int>("SecondPosition")
                        .HasColumnType("integer");

                    b.Property<int>("SeventhPosition")
                        .HasColumnType("integer");

                    b.Property<int>("SixthPosition")
                        .HasColumnType("integer");

                    b.Property<int>("TenthPosition")
                        .HasColumnType("integer");

                    b.Property<int>("ThirdPosition")
                        .HasColumnType("integer");

                    b.HasKey("SeasonRaceId");

                    b.ToTable("SeasonRaces");
                });

            modelBuilder.Entity("f7Race_API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("f7Race_API.Models.Brand", b =>
                {
                    b.HasOne("f7Race_API.Models.Season", null)
                        .WithMany("Brands")
                        .HasForeignKey("SeasonId");
                });

            modelBuilder.Entity("f7Race_API.Models.Race", b =>
                {
                    b.HasOne("f7Race_API.Models.Season", null)
                        .WithMany("Races")
                        .HasForeignKey("SeasonId");
                });

            modelBuilder.Entity("f7Race_API.Models.Season", b =>
                {
                    b.HasOne("f7Race_API.Models.Brand", "Second")
                        .WithMany()
                        .HasForeignKey("SecondId");

                    b.HasOne("f7Race_API.Models.Brand", "Third")
                        .WithMany()
                        .HasForeignKey("ThirdId");

                    b.HasOne("f7Race_API.Models.Brand", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Second");

                    b.Navigation("Third");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("f7Race_API.Models.Season", b =>
                {
                    b.Navigation("Brands");

                    b.Navigation("Races");
                });
#pragma warning restore 612, 618
        }
    }
}
