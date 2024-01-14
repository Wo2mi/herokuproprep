﻿// <auto-generated />
using System;
using FinalGTAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalGTAPI.Migrations
{
    [DbContext(typeof(FinalGTDbContext))]
    [Migration("20240110080113_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinalGTAPI.Models.Quiz", b =>
                {
                    b.Property<int>("QuizID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuizID"));

                    b.Property<int>("Answer")
                        .HasColumnType("integer");

                    b.Property<string>("Option1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Option2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Option3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Option4")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuizContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("QuizDiffId")
                        .HasColumnType("integer");

                    b.Property<int?>("QuizDifficultyQuizDiffId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("quizCreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("quizUpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("QuizID");

                    b.HasIndex("QuizDifficultyQuizDiffId");

                    b.HasIndex("SubjectID");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("FinalGTAPI.Models.QuizDifficulty", b =>
                {
                    b.Property<int>("QuizDiffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuizDiffId"));

                    b.Property<string>("QuizDiff")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuizDiffId");

                    b.ToTable("QuizDifficulties");
                });

            modelBuilder.Entity("FinalGTAPI.Models.Result", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ResultID"));

                    b.Property<double>("AvgScore")
                        .HasColumnType("double precision");

                    b.Property<int>("SubjectID")
                        .HasColumnType("integer");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<double>("highestScore")
                        .HasColumnType("double precision");

                    b.Property<int>("testMade")
                        .HasColumnType("integer");

                    b.HasKey("ResultID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("FinalGTAPI.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubjectID"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("FinalGTAPI.Models.TestResult", b =>
                {
                    b.Property<int>("TestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TestID"));

                    b.Property<DateTime>("DateTest")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("SubjectID")
                        .HasColumnType("integer");

                    b.Property<double>("TestScore")
                        .HasColumnType("double precision");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("TestID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("UserID");

                    b.ToTable("TestResults");
                });

            modelBuilder.Entity("FinalGTAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinalGTAPI.Models.Quiz", b =>
                {
                    b.HasOne("FinalGTAPI.Models.QuizDifficulty", "QuizDifficulty")
                        .WithMany()
                        .HasForeignKey("QuizDifficultyQuizDiffId");

                    b.HasOne("FinalGTAPI.Models.Subject", "Subject")
                        .WithMany("Quiz")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuizDifficulty");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("FinalGTAPI.Models.Result", b =>
                {
                    b.HasOne("FinalGTAPI.Models.Subject", "Subjects")
                        .WithMany("Result")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalGTAPI.Models.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subjects");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinalGTAPI.Models.TestResult", b =>
                {
                    b.HasOne("FinalGTAPI.Models.Subject", "Subject")
                        .WithMany("TestResults")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalGTAPI.Models.User", "User")
                        .WithMany("TestResults")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinalGTAPI.Models.Subject", b =>
                {
                    b.Navigation("Quiz");

                    b.Navigation("Result");

                    b.Navigation("TestResults");
                });

            modelBuilder.Entity("FinalGTAPI.Models.User", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("TestResults");
                });
#pragma warning restore 612, 618
        }
    }
}
