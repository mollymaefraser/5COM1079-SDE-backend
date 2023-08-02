﻿// <auto-generated />
using System;
using Meditelligence.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meditelligence.DataAccess.Migrations
{
    [DbContext(typeof(MeditelligenceDBContext))]
    partial class MeditelligenceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Meditelligence.Models.History", b =>
                {
                    b.Property<int>("LogID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PredictedDiagnosisID")
                        .HasColumnType("INTEGER");

                    b.HasKey("LogID");

                    b.HasIndex("PredictedDiagnosisID");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("Meditelligence.Models.HistorySymptom", b =>
                {
                    b.Property<int>("RefLogID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RefSymptomID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RefLogID", "RefSymptomID");

                    b.HasIndex("RefSymptomID");

                    b.ToTable("UserLogToSymptoms");
                });

            modelBuilder.Entity("Meditelligence.Models.Illness", b =>
                {
                    b.Property<int>("IllnessID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Advice")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("IllnessID");

                    b.ToTable("Illnesses");

                    b.HasData(
                        new
                        {
                            IllnessID = 1,
                            Advice = "Speak to your GP for further information regarding this",
                            Description = "This is a test disease that will be later removed",
                            Name = "Test disease 1"
                        },
                        new
                        {
                            IllnessID = 2,
                            Advice = "Speak to a specialist re. this condition, as it could be severe",
                            Description = "This is another test disease that will be later removed",
                            Name = "Test disease 2"
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.IllnessToSymptom", b =>
                {
                    b.Property<int>("IllnessRefID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SymptomRefID")
                        .HasColumnType("INTEGER");

                    b.HasKey("IllnessRefID", "SymptomRefID");

                    b.HasIndex("SymptomRefID");

                    b.ToTable("IllnessToSymptoms");

                    b.HasData(
                        new
                        {
                            IllnessRefID = 1,
                            SymptomRefID = 1
                        },
                        new
                        {
                            IllnessRefID = 1,
                            SymptomRefID = 2
                        },
                        new
                        {
                            IllnessRefID = 1,
                            SymptomRefID = 3
                        },
                        new
                        {
                            IllnessRefID = 2,
                            SymptomRefID = 3
                        },
                        new
                        {
                            IllnessRefID = 2,
                            SymptomRefID = 4
                        },
                        new
                        {
                            IllnessRefID = 2,
                            SymptomRefID = 5
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("NameOfFacility")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telephone")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationID = 1,
                            Address = "11, Ely, England",
                            EmailAddress = "ElyHospital@MIC.com",
                            Latitude = 52.41603480972924,
                            Longitude = 0.30389581535149041,
                            NameOfFacility = "Ely East Hospital",
                            Telephone = "017373432732"
                        },
                        new
                        {
                            LocationID = 2,
                            Address = "Alcester Rd, Stratford-upon-Avon CV37 9DD",
                            EmailAddress = "StratfordPractice@MIC.com",
                            Latitude = 52.195169205297645,
                            Longitude = -1.7250158764978769,
                            NameOfFacility = "Stratford Practice",
                            Telephone = "017373434563"
                        },
                        new
                        {
                            LocationID = 3,
                            Address = "59 Kirby Rd, Leicester LE3 6BD",
                            EmailAddress = "KirbyCareLeicester@MIC.com",
                            Latitude = 52.633896958220689,
                            Longitude = -1.1555297596794039,
                            NameOfFacility = "Kirby Care Leicester",
                            Telephone = "017373437632"
                        },
                        new
                        {
                            LocationID = 4,
                            Address = "37-1 Rosedale Ave, Leicester LE4 7AW",
                            EmailAddress = "MeditechOrthoLeicester@MIC.com",
                            Latitude = 52.655561677473628,
                            Longitude = -1.1058214758058622,
                            NameOfFacility = "Meditech Orthopaedics Leicester",
                            Telephone = "01737368576"
                        },
                        new
                        {
                            LocationID = 5,
                            Address = "Mapperley, Nottingham NG3 6AR",
                            EmailAddress = "MediTechNotts@MIC.com",
                            Latitude = 52.984436846989418,
                            Longitude = -1.1159675166183596,
                            NameOfFacility = "Meditech Notts Facility",
                            Telephone = "017373437656"
                        },
                        new
                        {
                            LocationID = 6,
                            Address = "2 Ellison Pl, Newcastle upon Tyne NE1 8ST",
                            EmailAddress = "MediTechNewcastle@MIC.com",
                            Latitude = 54.977379383321349,
                            Longitude = -1.6091152090172132,
                            NameOfFacility = "Meditech Newcastle Hospital",
                            Telephone = "017373432002"
                        },
                        new
                        {
                            LocationID = 7,
                            Address = "53 Cardigan Ln, Burley, Leeds LS4 2LE",
                            EmailAddress = "MediTechLeeds@MIC.com",
                            Latitude = 53.806123966089132,
                            Longitude = -1.5704154834281872,
                            NameOfFacility = "Meditech Leeds Facility",
                            Telephone = "017373431001"
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.LocationToService", b =>
                {
                    b.Property<int>("RefLocationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RefServiceID")
                        .HasColumnType("INTEGER");

                    b.HasKey("RefLocationID", "RefServiceID");

                    b.HasIndex("RefServiceID");

                    b.ToTable("LocationToServices");

                    b.HasData(
                        new
                        {
                            RefLocationID = 1,
                            RefServiceID = 2
                        },
                        new
                        {
                            RefLocationID = 1,
                            RefServiceID = 1
                        },
                        new
                        {
                            RefLocationID = 1,
                            RefServiceID = 3
                        },
                        new
                        {
                            RefLocationID = 2,
                            RefServiceID = 1
                        },
                        new
                        {
                            RefLocationID = 2,
                            RefServiceID = 2
                        },
                        new
                        {
                            RefLocationID = 2,
                            RefServiceID = 4
                        },
                        new
                        {
                            RefLocationID = 5,
                            RefServiceID = 5
                        },
                        new
                        {
                            RefLocationID = 6,
                            RefServiceID = 4
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceID = 1,
                            Description = "GP facilities are available at this location.",
                            Name = "GP"
                        },
                        new
                        {
                            ServiceID = 2,
                            Description = "Cosmetic and functional plastic surgeries performed here",
                            Name = "Plastic Surgery"
                        },
                        new
                        {
                            ServiceID = 3,
                            Description = "Services related to those of cardiovascular conditions",
                            Name = "Cardiology"
                        },
                        new
                        {
                            ServiceID = 4,
                            Description = "Urgent services for accidents and emergencies",
                            Name = "A&E"
                        },
                        new
                        {
                            ServiceID = 5,
                            Description = "MSK services for issues relating to muscular and skeletel co-ordination",
                            Name = "Physiotherapy"
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.Symptom", b =>
                {
                    b.Property<int>("SymptomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("SymptomID");

                    b.ToTable("Symptoms");

                    b.HasData(
                        new
                        {
                            SymptomID = 1,
                            Description = "High fever",
                            Name = "Symptom 1"
                        },
                        new
                        {
                            SymptomID = 2,
                            Description = "Short bursts of giggling",
                            Name = "Symptom 2"
                        },
                        new
                        {
                            SymptomID = 3,
                            Description = "Seeing hallucinations",
                            Name = "Symptom 3"
                        },
                        new
                        {
                            SymptomID = 4,
                            Description = "Extreme fits of anger",
                            Name = "Symptom 4"
                        },
                        new
                        {
                            SymptomID = 5,
                            Description = "No description",
                            Name = "Symptom 5"
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "admin@testAdmin.com",
                            FirstName = "Admin",
                            IsAdmin = true,
                            LastName = "User",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("Meditelligence.Models.History", b =>
                {
                    b.HasOne("Meditelligence.Models.User", null)
                        .WithMany("Logs")
                        .HasForeignKey("LogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meditelligence.Models.Illness", "AssociatedIllness")
                        .WithMany("LogList")
                        .HasForeignKey("PredictedDiagnosisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedIllness");
                });

            modelBuilder.Entity("Meditelligence.Models.HistorySymptom", b =>
                {
                    b.HasOne("Meditelligence.Models.History", "RefLog")
                        .WithMany()
                        .HasForeignKey("RefLogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meditelligence.Models.Symptom", "RefSymptom")
                        .WithMany("HistorySymptoms")
                        .HasForeignKey("RefSymptomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefLog");

                    b.Navigation("RefSymptom");
                });

            modelBuilder.Entity("Meditelligence.Models.IllnessToSymptom", b =>
                {
                    b.HasOne("Meditelligence.Models.Illness", "IllnessRecord")
                        .WithMany("SymptomList")
                        .HasForeignKey("IllnessRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meditelligence.Models.Symptom", "SymptomRecord")
                        .WithMany("IllnessList")
                        .HasForeignKey("SymptomRefID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IllnessRecord");

                    b.Navigation("SymptomRecord");
                });

            modelBuilder.Entity("Meditelligence.Models.LocationToService", b =>
                {
                    b.HasOne("Meditelligence.Models.Location", "RefLocation")
                        .WithMany("locationServices")
                        .HasForeignKey("RefLocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meditelligence.Models.Service", "RefService")
                        .WithMany("locationServices")
                        .HasForeignKey("RefServiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RefLocation");

                    b.Navigation("RefService");
                });

            modelBuilder.Entity("Meditelligence.Models.Illness", b =>
                {
                    b.Navigation("LogList");

                    b.Navigation("SymptomList");
                });

            modelBuilder.Entity("Meditelligence.Models.Location", b =>
                {
                    b.Navigation("locationServices");
                });

            modelBuilder.Entity("Meditelligence.Models.Service", b =>
                {
                    b.Navigation("locationServices");
                });

            modelBuilder.Entity("Meditelligence.Models.Symptom", b =>
                {
                    b.Navigation("HistorySymptoms");

                    b.Navigation("IllnessList");
                });

            modelBuilder.Entity("Meditelligence.Models.User", b =>
                {
                    b.Navigation("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
