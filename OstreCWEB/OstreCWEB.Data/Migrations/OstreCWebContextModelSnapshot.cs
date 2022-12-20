﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OstreCWEB.Data.DataBase;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    [DbContext(typeof(OstreCWebContext))]
    partial class OstreCWebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DialogPropId")
                        .HasColumnType("int");

                    b.Property<int?>("FightPropId")
                        .HasColumnType("int");

                    b.Property<int>("ParagraphType")
                        .HasColumnType("int");

                    b.Property<int?>("ShopkeeperPropId")
                        .HasColumnType("int");

                    b.Property<string>("StageDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoryId")
                        .HasColumnType("int");

                    b.Property<int?>("TestPropId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DialogPropId")
                        .IsUnique()
                        .HasFilter("[DialogPropId] IS NOT NULL");

                    b.HasIndex("FightPropId")
                        .IsUnique()
                        .HasFilter("[FightPropId] IS NOT NULL");

                    b.HasIndex("ShopkeeperPropId")
                        .IsUnique()
                        .HasFilter("[ShopkeeperPropId] IS NOT NULL");

                    b.HasIndex("StoryId");

                    b.HasIndex("TestPropId")
                        .IsUnique()
                        .HasFilter("[TestPropId] IS NOT NULL");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChoiceText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NextParagraphId")
                        .HasColumnType("int");

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.DialogProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DialogProps");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.EnemyInParagraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AmountOfEnemy")
                        .HasColumnType("int");

                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FightPropId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FightPropId");

                    b.ToTable("EnemyInParagraphs");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.FightProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FightProps");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.ShopkeeperProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ShopkeeperProps");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.TestProp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.Property<int>("Skill")
                        .HasColumnType("int");

                    b.Property<int>("TestDifficulty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TestProps");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirstParagraphId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Paragraph", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Properties.DialogProp", "DialogProp")
                        .WithOne("Paragraph")
                        .HasForeignKey("OstreCWEB.Data.Repository.StoryModels.Paragraph", "DialogPropId");

                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Properties.FightProp", "FightProp")
                        .WithOne("Paragraph")
                        .HasForeignKey("OstreCWEB.Data.Repository.StoryModels.Paragraph", "FightPropId");

                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Properties.ShopkeeperProp", "ShopkeeperProp")
                        .WithOne("Paragraph")
                        .HasForeignKey("OstreCWEB.Data.Repository.StoryModels.Paragraph", "ShopkeeperPropId");

                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Story", "Story")
                        .WithMany("Paragraphs")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Properties.TestProp", "TestProp")
                        .WithOne("Paragraph")
                        .HasForeignKey("OstreCWEB.Data.Repository.StoryModels.Paragraph", "TestPropId");

                    b.Navigation("DialogProp");

                    b.Navigation("FightProp");

                    b.Navigation("ShopkeeperProp");

                    b.Navigation("Story");

                    b.Navigation("TestProp");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.Choice", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Paragraph", "Paragraph")
                        .WithMany("Choices")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paragraph");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.EnemyInParagraph", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.StoryModels.Properties.FightProp", "FightProp")
                        .WithMany("ParagraphEnemies")
                        .HasForeignKey("FightPropId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FightProp");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Paragraph", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.DialogProp", b =>
                {
                    b.Navigation("Paragraph")
                        .IsRequired();
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.FightProp", b =>
                {
                    b.Navigation("Paragraph")
                        .IsRequired();

                    b.Navigation("ParagraphEnemies");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.ShopkeeperProp", b =>
                {
                    b.Navigation("Paragraph")
                        .IsRequired();
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Properties.TestProp", b =>
                {
                    b.Navigation("Paragraph")
                        .IsRequired();
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.StoryModels.Story", b =>
                {
                    b.Navigation("Paragraphs");
                });
#pragma warning restore 612, 618
        }
    }
}
