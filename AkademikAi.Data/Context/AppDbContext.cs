using AkademikAi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AkademikAi.Data.Seed;
using Microsoft.IdentityModel.Tokens;
using AkademikAi.Entity.Enums;



namespace AkademikAi.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole, Guid>
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
         {
        }
       public DbSet<Questions> Questions { get; set; }
       public DbSet<QuestionsOptions> QuestionsOptions { get; set; }
       public DbSet<Topics> Topics { get; set; }
       public DbSet<QuestionsTopic> QuestionsTopics { get; set; }
       public DbSet<UserAnswers> UserAnswers { get; set; }
       public DbSet<UserNotifications> UserNotifications { get; set; }
       public DbSet<UserRecommendation> UserRecommendations { get; set; }
       public DbSet<UserPerformanceSummaries> UserPerformanceSummaries { get; set; }

       public DbSet<Exam> Exams { get; set; }
       public DbSet<ExamQuestions> ExamQuestions { get; set; }
       public DbSet<ExamParticipant> ExamParticipants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureExamEntities(modelBuilder);

            // Seed data'yı ekle
            DataSeeder.SeedData(modelBuilder);

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(q => q.Id);
                entity.Property(q => q.QuestionText).IsRequired();
                entity.Property(q => q.SolutionText);
                entity.Property(q => q.DifficultyLevel).IsRequired();
                entity.Property(q => q.Source).HasMaxLength(100);
                entity.Property(q => q.IsActive).HasDefaultValue(true);

                entity.HasOne(q => q.GeneratedForUser)
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
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
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

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Surname).HasMaxLength(100);
                entity.Property(u => u.CreatedAt).IsRequired();
                entity.Property(u => u.UserRole).IsRequired();
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

                entity.HasOne(ua => ua.Exam)
                      .WithMany(e => e.UserAnswers)
                      .HasForeignKey(ua => ua.ExamId)
                      .IsRequired(false)

                      .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<UserNotifications>(entity =>
            {
                entity.HasKey(un => un.Id);
                entity.Property(un => un.Message).IsRequired().HasMaxLength(250);
                entity.Property(un => un.NotificationType);
                entity.Property(un => un.CreatedAt);

                entity.HasOne(un => un.User)
                      .WithMany(u => u.UserNotifications)
                      .HasForeignKey(un => un.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserRecommendation>(entity =>
            {
                entity.HasKey(ur => ur.Id);
                entity.Property(ur => ur.RecommendationType).IsRequired();
                entity.Property(ur => ur.Description).IsRequired().HasMaxLength(500);
                entity.Property(ur => ur.CreatedAt).IsRequired();

                entity.HasOne(ur => ur.User)
                      .WithMany(u => u.UserRecommendations)
                      .HasForeignKey(ur => ur.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ur => ur.Topic)
                      .WithMany()
                      .HasForeignKey(ur => ur.RelatedTopicId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserPerformanceSummaries>(entity =>
            {
                entity.HasKey(ups => ups.Id);
                entity.HasIndex(ups => new { ups.UserId, ups.TopicId }).IsUnique();

                entity.Property(ups => ups.TotalQuestionsAnswered).IsRequired();
                entity.Property(ups => ups.CorrectAnswers).IsRequired();

                entity.HasOne(ups => ups.User)
                      .WithMany(u => u.UserPerformanceSummaries)
                      .HasForeignKey(ups => ups.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ups => ups.Topic)
                      .WithMany()
                      .HasForeignKey(ups => ups.TopicId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
        


             private void ConfigureExamEntities(ModelBuilder modelBuilder)
            {
                 modelBuilder.Entity<Exam>(entity =>
                {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.EndTime).IsRequired();
                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<ExamQuestions>(entity =>
            {
                entity.HasKey(eq => new { eq.ExamId, eq.QuestionId });

                entity.HasOne(eq => eq.Exam)
                      .WithMany(e => e.ExamQuestions)
                      .HasForeignKey(eq => eq.ExamId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(eq => eq.Question)
                      .WithMany(q => q.ExamQuestions) // Yazım hatası düzeltildi: ExamQuestion -> ExamQuestions
                      .HasForeignKey(eq => eq.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ExamParticipant>(entity =>
            {
                entity.HasKey(ep => new { ep.UserId, ep.ExamId });

                entity.HasOne(ep => ep.User)
                      .WithMany(u => u.ExamParticipants)
                      .HasForeignKey(ep => ep.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ep => ep.Exam)
                      .WithMany(e => e.Participants)
                      .HasForeignKey(ep => ep.ExamId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

    
}

