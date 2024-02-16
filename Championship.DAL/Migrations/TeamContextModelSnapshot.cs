﻿// <auto-generated />
using System;
using Championship.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Championship.DAL.Migrations
{
    [DbContext(typeof(TeamContext))]
    partial class TeamContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Championship.DAL.Matches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoalsScoredByTeam1")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScoredByTeam2")
                        .HasColumnType("int");

                    b.Property<int?>("Team1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Team2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Championship.DAL.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Championship.DAL.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Defeats")
                        .HasColumnType("int");

                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<int>("GoalsConceded")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Championship.DAL.Matches", b =>
                {
                    b.HasOne("Championship.DAL.Team", "Team1")
                        .WithMany()
                        .HasForeignKey("Team1Id");

                    b.HasOne("Championship.DAL.Team", "Team2")
                        .WithMany()
                        .HasForeignKey("Team2Id");

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("Championship.DAL.Player", b =>
                {
                    b.HasOne("Championship.DAL.Team", null)
                        .WithMany("players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Championship.DAL.Team", b =>
                {
                    b.Navigation("players");
                });
#pragma warning restore 612, 618
        }
    }
}
