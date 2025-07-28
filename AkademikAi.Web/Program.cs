using AkademikAi.Data.Context;
using AkademikAi.Data.IRepositories;
using AkademikAi.Data.Repositories;
using AkademikAi.Service.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IQuestionOptionsRepository, QuestionOptionsRepository>();
builder.Services.AddScoped<IQuestionTopicRepository, QuestionTopicRepository>();
builder.Services.AddScoped<IUserAnswersRepository, UserAnswerRepository>();
builder.Services.AddScoped<IUserPerformanceSummariesRepository, UserPerformanceSummariesRepository>();
builder.Services.AddScoped<IUserRecommendationRepository, UserRecommendationRepository>();
builder.Services.AddScoped<IUserNotificationsRepository, UserNotificationsRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Register Services
builder.Services.AddAkademikAiServices();

var app = builder.Build();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
