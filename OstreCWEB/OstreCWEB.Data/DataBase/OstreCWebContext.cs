﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Properties;

namespace OstreCWEB.Data.DataBase
{
    public class OstreCWebContext : IdentityDbContext<User>
    {
        //Relations many to many

        public DbSet<ActionCharacter> actionCharactersRelation { get; set; }
        public DbSet<ItemCharacter> ItemsCharactersRelation { get; set; }


        //User
        public DbSet<User> Users { get; set; }
        //Characters
        public DbSet<PlayableCharacter> PlayableCharacters { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<PlayableClass> PlayableCharacterClasses { get; set; }
        public DbSet<PlayableRace> PlayableCharacterRaces { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<CharacterAction> CharacterActions { get; set; } // Action is a keyword..
        //Story 
        public DbSet<Story> Stories { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<NextParagraph> NextParagraphs { get; set; }
        public DbSet<FightProp> FightProps { get; set; }
        public DbSet<TestProp> TestProps { get; set; }
        public DbSet<DialogProp> DialogProps { get; set; }
        public DbSet<ShopkeeperProp> ShopkeeperProps { get; set; }
        public DbSet<EnemyInParagraph> EnemyInParagraphs { get; set; }

        //GameSessions

        //Combat


        public OstreCWebContext()
        {

        }
        public OstreCWebContext(DbContextOptions<OstreCWebContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            UserConfiguration(builder);
            ConfigureCharacters(builder);
            ConfigureActions(builder);
            ConfigureItems(builder);
        }

        private void ConfigureItems(ModelBuilder builder)
        {

            builder.Entity<Item>().Navigation(e => e.ActionToTrigger).AutoInclude();

            builder.Entity<ItemCharacter>()
             .HasKey(x => new { x.ItemId, x.CharacterId });


            builder.Entity<ItemCharacter>()
                           .HasOne(x => x.Item)
                           .WithMany(x => x.LinkedCharacters)
                           .HasForeignKey(x => x.ItemId);


            builder.Entity<ItemCharacter>()
             .HasOne(x => x.Character)
             .WithMany(x => x.LinkedItems)
             .HasForeignKey(x => x.CharacterId);

        }
        private void ConfigureActions(ModelBuilder builder)
        {

            builder.Entity<CharacterAction>().Navigation(e => e.Status).AutoInclude();

            builder.Entity<ActionCharacter>()
            .HasKey(x => new { x.CharacterId, x.CharacterActionId });

            builder.Entity<ActionCharacter>()
                    .HasOne(pt => pt.Character)
                    .WithMany(p => p.LinkedActions)
                    .HasForeignKey(pt => pt.CharacterId);

            builder.Entity<ActionCharacter>()
                .HasOne(pt => pt.CharacterAction)
                .WithMany(t => t.LinkedCharacter)
                .HasForeignKey(pt => pt.CharacterActionId);
        }
        private void UserConfiguration(ModelBuilder builder)
        {

        }
        private void ConfigureCharacters(ModelBuilder builder)
        {
            builder.Entity<PlayableCharacter>().Navigation(e => e.CharacterClass).AutoInclude();
            builder.Entity<PlayableCharacter>().Navigation(e => e.Race).AutoInclude();
            builder.Entity<PlayableCharacter>().Navigation(e => e.LinkedActions).AutoInclude();
            builder.Entity<PlayableCharacter>().Navigation(e => e.LinkedItems).AutoInclude();

            builder.Entity<PlayableCharacter>()
                .HasOne(r => r.Race)
                .WithMany(p => p.PlayableCharacter)
                .HasForeignKey(x => x.RaceId);
            builder.Entity<PlayableCharacter>()
                .HasOne(c => c.CharacterClass)
                .WithMany(p => p.PlayableCharacter);
        }
        private void ConfigureStories(ModelBuilder builder)
        {
            { //Story
                builder.Entity<Story>()
                    .HasMany(x => x.Paragraphs)
                    .WithOne(x => x.Story)
                    .HasForeignKey(x => x.StoryId);
            } // Story

            { // Paragraph
                builder.Entity<Paragraph>()
                    .HasOne(x => x.FightProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<Paragraph>(x => x.FightPropId);

                builder.Entity<Paragraph>()
                    .HasOne(x => x.TestProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<Paragraph>(x => x.TestPropId);

                builder.Entity<Paragraph>()
                    .HasOne(x => x.DialogProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<Paragraph>(x => x.DialogPropId);

                builder.Entity<Paragraph>()
                    .HasOne(x => x.ShopkeeperProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<Paragraph>(x => x.ShopkeeperPropId);
            } // Paragraph

            { // ParagraphFight
                builder.Entity<FightProp>()
                    .HasMany(x => x.ParagraphEnemies)
                    .WithOne(x => x.FightProp)
                    .HasForeignKey(x => x.FightPropId);
            } // ParagraphFight
        }


    }
}

