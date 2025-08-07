using AkademikAi.Service.IServices;
using AkademikAi.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection; 
using AutoMapper;
namespace AkademikAi.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceLayerDependencies(this IServiceCollection services)
        {
            // AutoMapper kayd�n� da buraya ta��mak en temiz y�ntemdir.
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppRoleService, AppRoleService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IExamService, ExamService>();

            // --- HATA VEREN EKS�K SERV�SLER�N KAYDI ---
            services.AddScoped<IUserAnswerService, UserAnswerService>();
            services.AddScoped<IUserPerformanceSummaryService, UserPerformanceSummaryService>();
            services.AddScoped<IUserRecommendationService, UserRecommendationService>();
            services.AddScoped<IUserNotificationService, UserNotificationService>(); // Bu da muhtemelen eksiktir

            return services;
        }
    }
}