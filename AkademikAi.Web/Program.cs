using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Data.Repositories;
using AkademikAi.Data.Seed;
using AkademikAi.Entity.Entites;
using AkademikAi.Service.AutoMapper.Exams;

using AkademikAi.Service.IServices;
using AkademikAi.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Register Services with AutoMapper from Service Layer
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(ExamProfile).Assembly);
});

// Repository kayıtları - Generic Repository için tüm entity'ler
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IAppRoleRepository, AppRoleRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IQuestionOptionsRepository, QuestionOptionsRepository>();
builder.Services.AddScoped<IQuestionTopicRepository, QuestionTopicRepository>();
builder.Services.AddScoped<IUserRecommendationRepository, UserRecommendationRepository>();
builder.Services.AddScoped<IUserPerformanceSummariesRepository, UserPerformanceSummariesRepository>();
builder.Services.AddScoped<IUserNotificationsRepository, UserNotificationsRepository>();
builder.Services.AddScoped<IUserAnswersRepository, UserAnswerRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();

// UnitOfWork kayıt
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Service kayıtları
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IAppRoleService, AppRoleService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IUserAnswerService, UserAnswerService>();
builder.Services.AddScoped<IUserPerformanceSummaryService, UserPerformanceSummaryService>();
builder.Services.AddScoped<IUserRecommendationService, UserRecommendationService>();
builder.Services.AddScoped<IUserNotificationService, UserNotificationService>();

var app = builder.Build();

// Seed database
DatabaseSeeder.SeedDatabase(app.Services);

// Seed Identity data
await IdentityDataSeeder.SeedIdentityDataAsync(app.Services);



app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Hata detaylarını gösterir
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Swagger UI'ın hangi endpoint'i kullanacağını belirtir. Genellikle /swagger/v1/swagger.json olur.
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AkademikAi API V1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
