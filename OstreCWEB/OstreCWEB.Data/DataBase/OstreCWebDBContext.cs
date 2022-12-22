using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.Repository.StoryModels;
using OstreCWEB.Data.Repository.StoryModels.Properties;

namespace OstreCWEB.Data.DataBase
{
    public class OstreCWebContext : DbContext
    {
        //User

        //Story
        public DbSet<Story> Stories { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<FightProp> FightProps { get; set; }
        public DbSet<TestProp> TestProps { get; set; }
        public DbSet<DialogProp> DialogProps { get; set; }
        public DbSet<ShopkeeperProp> ShopkeeperProps { get; set; }
        public DbSet<EnemyInParagraph> EnemyInParagraphs { get; set; }

        //Character

        //Combat

        public OstreCWebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            { //Story
                builder.Entity<Story>()
                    .HasMany(x => x.Paragraphs)
                    .WithOne(x => x.Story)
                    .HasForeignKey(x => x.StoryId);
            } // Story

            { // Paragraph
                //Fight
                builder.Entity<Paragraph>()
                    .HasOne(x => x.FightProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<FightProp>(x => x.ParagraphId);

                //Dialog
                builder.Entity<Paragraph>()
                    .HasOne(x => x.DialogProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<DialogProp>(x => x.ParagraphId);

                //Shopkeeper
                builder.Entity<Paragraph>()
                    .HasOne(x => x.ShopkeeperProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<ShopkeeperProp>(x => x.ParagraphId);

                //Test
                builder.Entity<Paragraph>()
                    .HasOne(x => x.TestProp)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey<TestProp>(x => x.ParagraphId);

                builder.Entity<Paragraph>()
                    .HasMany(x => x.Choices)
                    .WithOne(x => x.Paragraph)
                    .HasForeignKey(x => x.ParagraphId);
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