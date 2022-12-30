using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.Repository.Characters.CharacterModels;
using OstreCWEB.Data.Repository.Characters.MetaTags;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Properties;
using System.Reflection.Emit;

namespace OstreCWEB.Data.DataBase
{
    public class OstreCWebContext : DbContext
    {
        //Relations many to many

       internal DbSet<ActionCharacter> actionCharactersRelation { get; set; }
        internal DbSet<ItemCharacter> ItemsCharactersRelation { get; set; }


        //User
        internal DbSet<User> Users { get; set; }
        //Characters
        internal DbSet<PlayableCharacter> PlayableCharacters { get; set; }
        internal DbSet<Enemy> Enemies { get; set; }
        internal DbSet<PlayableClass> PlayableCharacterClasses { get; set; }
        internal DbSet<PlayableRace> PlayableCharacterRaces { get; set; }
        internal DbSet<Item> Items { get; set; }
        internal DbSet<Status> Statuses { get; set; }

        internal DbSet<CharacterAction> CharacterActions { get; set; }



        //Story

        //public DbSet<Story> Stories { get; set; }
        //public DbSet<Paragraph> Paragraphs { get; set; }
        //public DbSet<NextParagraph> NextParagraphs { get; set; }
        //public DbSet<FightProp> FightProps { get; set; }
        //public DbSet<TestProp> TestProps { get; set; }
        //public DbSet<DialogProp> DialogProps { get; set; }
        //public DbSet<ShopkeeperProp> ShopkeeperProps { get; set; }
        //public DbSet<EnemyInParagraph> EnemyInParagraphs { get; set; }


        //Combat


        public OstreCWebContext() { 
        
        }
        public OstreCWebContext(DbContextOptions<OstreCWebContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            UserConfiguration(builder);
            ConfigureCharacters(builder);
            ConfigureActions(builder);
           
        }
         
        private void ConfigureActions(ModelBuilder builder)
        {
            //builder.Entity<ActionCharacter>().HasKey(sc => new { sc.CharacterActionId, sc.CharacterId});
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

            builder.Entity<User>()
                    .HasMany(x => x.CharactersCreated)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);
        }
        private void ConfigureCharacters(ModelBuilder builder)
        {
            

            builder.Entity<PlayableCharacter>()
                .HasOne(r => r.Race)
                .WithMany(p => p.PlayableCharacter)
                .HasForeignKey(x => x.RaceId); 
            builder.Entity<PlayableCharacter>()
                .HasOne(c => c.CharacterClass)
                .WithMany(p => p.PlayableCharacter);

            builder.Entity<ItemCharacter>()
                .HasKey(x => new { x.ItemId, x.CharacterId });

            builder.Entity<ItemCharacter>()
                .HasOne(x => x.Item)
                .WithMany(x => x.ItemCharacter)
                .HasForeignKey(x => x.ItemId);

            builder.Entity<ItemCharacter>()
              .HasOne(x => x.Character)
              .WithMany(x => x.ItemCharacter)
              .HasForeignKey(x => x.CharacterId);

        }
        private void ConfigureStories( ModelBuilder builder)
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
