﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoboFan.Data.EFCore;

namespace RoboFan.Data.EFCore.Migrations
{
    [DbContext(typeof(RoboFanContext))]
    partial class RoboFanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("RoboFan.Domain.Entities.LeagueTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Conference")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("LeagueTeam");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/atlantaunitedfc.gif",
                            Name = "Atlanta United FC"
                        },
                        new
                        {
                            Id = 2,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/chicagofire.gif",
                            Name = "Chicago Fire"
                        },
                        new
                        {
                            Id = 3,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/coloradorapids.gif",
                            Name = "Colorado Rapids"
                        },
                        new
                        {
                            Id = 4,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/columbuscrewsc.gif",
                            Name = "Columbus Crew SC"
                        },
                        new
                        {
                            Id = 5,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/dcunited.gif",
                            Name = "D.C. United"
                        },
                        new
                        {
                            Id = 6,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/fccincinnati.gif",
                            Name = "FC Cincinnati"
                        },
                        new
                        {
                            Id = 7,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/fcdallas.gif",
                            Name = "FC Dallas"
                        },
                        new
                        {
                            Id = 8,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/houstondynamo.gif",
                            Name = "Houston Dynamo"
                        },
                        new
                        {
                            Id = 9,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/lagalaxy.gif",
                            Name = "LA Galaxy"
                        },
                        new
                        {
                            Id = 10,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/losangelesfc.gif",
                            Name = "Los Angeles FC"
                        },
                        new
                        {
                            Id = 11,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/minnesotaunitedfc.gif",
                            Name = "Minnesota United FC"
                        },
                        new
                        {
                            Id = 12,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/montrealimpact.gif",
                            Name = "Montreal Impact"
                        },
                        new
                        {
                            Id = 13,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/newenglandrevolution.gif",
                            Name = "New England Revolution"
                        },
                        new
                        {
                            Id = 14,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/newyorkcityfc.gif",
                            Name = "New York City FC"
                        },
                        new
                        {
                            Id = 15,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/newyorkredbulls.gif",
                            Name = "New York Red Bulls"
                        },
                        new
                        {
                            Id = 16,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/orlandocitysc.gif",
                            Name = "Orlando City SC"
                        },
                        new
                        {
                            Id = 17,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/philadelphiaunion.gif",
                            Name = "Philadelphia Union"
                        },
                        new
                        {
                            Id = 18,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/portlandtimbers.gif",
                            Name = "Portland Timbers"
                        },
                        new
                        {
                            Id = 19,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/realsaltlake.gif",
                            Name = "Real Salt Lake"
                        },
                        new
                        {
                            Id = 20,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/sanjoseearthquakes.gif",
                            Name = "San Jose Earthquakes"
                        },
                        new
                        {
                            Id = 21,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/seattlesoundersfc.gif",
                            Name = "Seattle Sounders FC"
                        },
                        new
                        {
                            Id = 22,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/sportingkansascity.gif",
                            Name = "Sporting Kansas City"
                        },
                        new
                        {
                            Id = 23,
                            Conference = "Eastern",
                            ImageUrl = "~/images/teams/torontofc.gif",
                            Name = "Toronto FC"
                        },
                        new
                        {
                            Id = 24,
                            Conference = "Western",
                            ImageUrl = "~/images/teams/vancouverwhitecapsfc.gif",
                            Name = "Vancouver Whitecaps FC"
                        });
                });

            modelBuilder.Entity("RoboFan.Domain.Entities.RoboFan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("BirthDate")
                        .HasColumnType("DateTime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<Guid>("GuidId");

                    b.Property<byte[]>("Image");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int?>("PrimaryTeamId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("PrimaryTeamId");

                    b.ToTable("RoboFan");
                });

            modelBuilder.Entity("RoboFan.Domain.Entities.RoboFanTeamRanking", b =>
                {
                    b.Property<int>("RobotFanId");

                    b.Property<int>("LeagueTeamId");

                    b.Property<int>("Ranking");

                    b.HasKey("RobotFanId", "LeagueTeamId");

                    b.HasIndex("LeagueTeamId");

                    b.ToTable("RoboFanTeamRanking");
                });

            modelBuilder.Entity("RoboFan.Domain.Entities.RoboFan", b =>
                {
                    b.HasOne("RoboFan.Domain.Entities.LeagueTeam", "PrimaryTeam")
                        .WithMany("RobotFans")
                        .HasForeignKey("PrimaryTeamId");
                });

            modelBuilder.Entity("RoboFan.Domain.Entities.RoboFanTeamRanking", b =>
                {
                    b.HasOne("RoboFan.Domain.Entities.LeagueTeam", "LeagueTeam")
                        .WithMany("FanRankings")
                        .HasForeignKey("LeagueTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RoboFan.Domain.Entities.RoboFan", "RobotFan")
                        .WithMany("FanRankings")
                        .HasForeignKey("RobotFanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
