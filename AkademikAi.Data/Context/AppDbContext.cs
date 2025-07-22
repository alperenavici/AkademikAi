using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace AkademikAi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
         {
        }
       public DbSet<Questions> Questions { get; set; }
       public DbSet<QuestionsOptions> QuestionsOptions { get; set; }
       public DbSet<Topics> Topics { get; set; }
       public DbSet<QuestionsTopic> QuestionsTopics { get; set; }
       public DbSet<UserAnswers> UserAnswers { get; set; }
       public DbSet<Users> Users { get; set; }
       public DbSet<UserNotifications> UserNotifications { get; set; }
       public DbSet<UserRecommendation> UserRecommendations { get; set; }
       public DbSet<UserPerformanceSummaries> UserPerformanceSummaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(q => q.Id);
                entity.Property(q => q.QuestionText).IsRequired();
                entity.Property(q => q.SolutionText);
                entity.Property(q => q.DifficultyLevel).IsRequired();
                entity.Property(q => q.Source).HasMaxLength(100);
                entity.Property(q => q.IsActive).HasDefaultValue(true);

                entity.HasOne<Users>()
                      .WithMany()
                      .HasForeignKey(q => q.GeneratedForUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(q => q.QuestionsOptions)
                      .WithOne(o => o.Question)
                      .HasForeignKey(o => o.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(q => q.QuestionsTopics)
                      .WithOne(qt => qt.Question)
                      .HasForeignKey(qt => qt.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            
            modelBuilder.Entity<QuestionsOptions>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.OptionText).IsRequired();
                entity.Property(o => o.Label).IsRequired().HasMaxLength(1);
                entity.Property(o => o.IsCorrect).IsRequired();
            });

            
            modelBuilder.Entity<Topics>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.TopicName).IsRequired().HasMaxLength(100);

                entity.HasOne<Topics>()
                      .WithMany()
                      .HasForeignKey(t => t.ParentTopicId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<QuestionsTopic>(entity =>
            {
                entity.HasKey(qt => new { qt.QuestionId, qt.TopicId });

                entity.HasOne(qt => qt.Question)
                      .WithMany(q => q.QuestionsTopics)
                      .HasForeignKey(qt => qt.QuestionId);

                entity.HasOne(qt => qt.Topic)
                      .WithMany(t => t.QuestionsTopics)
                      .HasForeignKey(qt => qt.TopicId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Surname).HasMaxLength(100);
                entity.Property(u => u.Phone).HasMaxLength(20);
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.CreatedAt).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<UserAnswers>(entity =>
            {
                entity.HasKey(ua => ua.Id);
                entity.Property(ua => ua.AnsweredAt).IsRequired();

                entity.HasOne(ua => ua.User)
                      .WithMany(u => u.UserAnswers)
                      .HasForeignKey(ua => ua.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ua => ua.Question)
                      .WithMany(q => q.UserAnswers)
                      .HasForeignKey(ua => ua.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserNotifications>(entity =>
            {
                entity.HasKey(un => un.Id);
                entity.Property(un => un.Message).IsRequired().HasMaxLength(250);
                entity.Property(un => un.NotificationType);
                entity.Property(un => un.CreatedAt);

                entity.HasOne(un => un.User)
                      .WithMany(u => u.UserNotifications)
                      .HasForeignKey(un => un.UserId);
            });

            modelBuilder.Entity<UserRecommendation>(entity =>
            {
                entity.HasKey(ur => ur.Id);
                entity.Property(ur => ur.RecommendationType).IsRequired();
                entity.Property(ur => ur.Description).IsRequired().HasMaxLength(500);
                entity.Property(ur => ur.CreatedAt).IsRequired();

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRecommendations)
                      .HasForeignKey(ur => ur.UserId);

                entity.HasOne(ur => ur.Topic)
                      .WithMany()
                      .HasForeignKey(ur => ur.RelatedTopicId);
            });

            modelBuilder.Entity<UserPerformanceSummaries>(entity =>
            {
                entity.HasKey(ups => ups.Id);
                entity.HasIndex(ups => new { ups.UserId, ups.TopicId }).IsUnique();

                entity.Property(ups => ups.TotalAnsweredQuestions).IsRequired();
                entity.Property(ups => ups.CorrectAnswers).IsRequired();

                entity.HasOne(ups => ups.User)
                      .WithMany(u => u.UserPerformanceSummaries)
                      .HasForeignKey(ups => ups.UserId);

                entity.HasOne(ups => ups.Topic)
                      .WithMany()
                      .HasForeignKey(ups => ups.TopicId);
            });
        }

    }
}
