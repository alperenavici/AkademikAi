using AkademikAi.Service.IServices;
using AkademikAi.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AkademikAi.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAkademikAiServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IUserAnswerService, UserAnswerService>();
            services.AddScoped<IUserPerformanceSummaryService, UserPerformanceSummaryService>();
            services.AddScoped<IUserRecommendationService, UserRecommendationService>();
            services.AddScoped<IUserNotificationService, UserNotificationService>();

            return services;
        }
    }
} 