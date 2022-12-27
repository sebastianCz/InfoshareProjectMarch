﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OstreCWEB.Data.DataBase;

#nullable disable

namespace OstreCWEB.Data.Migrations
{
    [DbContext(typeof(OstreCWebContext))]
    [Migration("20221227051702_Characters_Db_Update")]
    partial class Characters_Db_Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CharacterModels.Item", b =>
                {
                    b.Property<int?>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ItemId"), 1L, 1);

                    b.Property<int>("ActionToTriggerCharacterActionId")
                        .HasColumnType("int");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("int");

                    b.Property<string>("ArmorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("ActionToTriggerCharacterActionId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.CharacterAction", b =>
                {
                    b.Property<int>("CharacterActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterActionId"), 1L, 1);

                    b.Property<string>("ActionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<bool>("AggressiveAction")
                        .HasColumnType("bit");

                    b.Property<int?>("EnemyCharacterId")
                        .HasColumnType("int");

                    b.Property<int>("Flat_Dmg")
                        .HasColumnType("int");

                    b.Property<int>("Hit_Dice_Nr")
                        .HasColumnType("int");

                    b.Property<bool>("InflictsStatus")
                        .HasColumnType("bit");

                    b.Property<int>("Max_Dmg")
                        .HasColumnType("int");

                    b.Property<int?>("PlayableCharacterCharacterId")
                        .HasColumnType("int");

                    b.Property<string>("PossibleTargets")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SavingThrowPossible")
                        .HasColumnType("bit");

                    b.Property<int>("StatForTest")
                        .HasColumnType("int");

                    b.Property<int>("UsesLeftBeforeRest")
                        .HasColumnType("int");

                    b.Property<int>("UsesMax")
                        .HasColumnType("int");

                    b.Property<int>("UsesMaxBeforeRest")
                        .HasColumnType("int");

                    b.HasKey("CharacterActionId");

                    b.HasIndex("EnemyCharacterId");

                    b.HasIndex("PlayableCharacterCharacterId");

                    b.ToTable("CharacterAction");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.Enemy", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"), 1L, 1);

                    b.Property<string>("Alignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("CombatId")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHealthPoints")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealthPoints")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.Property<int>("Wisdom")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacter", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"), 1L, 1);

                    b.Property<string>("Alignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharacterClassID")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Charisma")
                        .HasColumnType("int");

                    b.Property<int>("CombatId")
                        .HasColumnType("int");

                    b.Property<int>("Constitution")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHealthPoints")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("MaxHealthPoints")
                        .HasColumnType("int");

                    b.Property<int>("PlayableClassId")
                        .HasColumnType("int");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wisdom")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("CharacterClassID");

                    b.HasIndex("RaceId");

                    b.HasIndex("UserId");

                    b.ToTable("PlayableCharacters");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacterClass", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlayableCharacterId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("PlayableCharacterClass");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableRace", b =>
                {
                    b.Property<int>("PlayableRaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayableRaceId"), 1L, 1);

                    b.Property<int>("AmountOfSkillsToChoose")
                        .HasColumnType("int");

                    b.Property<string>("RaceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayableRaceId");

                    b.ToTable("PlayableRace");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<int>("CharacterActionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.HasIndex("CharacterActionId")
                        .IsUnique();

                    b.ToTable("Status");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.MetaTags.ItemCharacter", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("PlayableCharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("EnemyCharacterId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "PlayableCharacterId");

                    b.HasIndex("EnemyCharacterId");

                    b.HasIndex("PlayableCharacterId");

                    b.ToTable("ItemCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActiveStoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("DamageDealt")
                        .HasColumnType("int");

                    b.Property<int>("DamageReceived")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoriesCompletedTotal")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CharacterModels.Item", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.CharacterAction", "ActionToTrigger")
                        .WithMany()
                        .HasForeignKey("ActionToTriggerCharacterActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActionToTrigger");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.CharacterAction", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.Enemy", null)
                        .WithMany("DefaultActions")
                        .HasForeignKey("EnemyCharacterId");

                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacter", null)
                        .WithMany("DefaultActions")
                        .HasForeignKey("PlayableCharacterCharacterId");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacter", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacterClass", "CharacterClass")
                        .WithMany("PlayableCharacter")
                        .HasForeignKey("CharacterClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableRace", "Race")
                        .WithMany("PlayableCharacter")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OstreCWEB.Data.Repository.Identity.User", "User")
                        .WithMany("CharactersCreated")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterClass");

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.Status", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.CharacterAction", "CharacterActions")
                        .WithOne("Status")
                        .HasForeignKey("OstreCWEB.Data.Repository.Characters.CoreClasses.Status", "CharacterActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterActions");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.MetaTags.ItemCharacter", b =>
                {
                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.Enemy", null)
                        .WithMany("ItemCharacter")
                        .HasForeignKey("EnemyCharacterId");

                    b.HasOne("OstreCWEB.Data.Repository.Characters.CharacterModels.Item", "Item")
                        .WithMany("ItemCharacter")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacter", "PlayableCharacter")
                        .WithMany("ItemCharacter")
                        .HasForeignKey("PlayableCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("PlayableCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CharacterModels.Item", b =>
                {
                    b.Navigation("ItemCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.CharacterAction", b =>
                {
                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.Enemy", b =>
                {
                    b.Navigation("DefaultActions");

                    b.Navigation("ItemCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacter", b =>
                {
                    b.Navigation("DefaultActions");

                    b.Navigation("ItemCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableCharacterClass", b =>
                {
                    b.Navigation("PlayableCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Characters.CoreClasses.PlayableRace", b =>
                {
                    b.Navigation("PlayableCharacter");
                });

            modelBuilder.Entity("OstreCWEB.Data.Repository.Identity.User", b =>
                {
                    b.Navigation("CharactersCreated");
                });
#pragma warning restore 612, 618
        }
    }
}
